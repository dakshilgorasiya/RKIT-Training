$(async () => {
    const employees = [
        { id: 1, name: "Amit Patel", age: 28, department: "IT", city: "Ahmedabad", salary: 60000, experience: 3 },
        { id: 1, name: "Amit Patel", age: 18, department: "IT", city: "Ahmedabad", salary: 60000, experience: 3 },
        { id: 1, name: "Amit Patel", age: 38, department: "IT", city: "Ahmedabad", salary: 60000, experience: 3 },
        { id: 2, name: "Riya Shah", age: 32, department: "HR", city: "Mumbai", salary: 55000, experience: 6 },
        { id: 3, name: "Karan Mehta", age: 26, department: "IT", city: "Pune", salary: 50000, experience: 2 },
        { id: 4, name: "Sneha Joshi", age: 35, department: "Finance", city: "Delhi", salary: 75000, experience: 10 },
        { id: 5, name: "Rahul Verma", age: 29, department: "Marketing", city: "Bangalore", salary: 62000, experience: 4 },
        { id: 6, name: "Neha Kapoor", age: 31, department: "HR", city: "Delhi", salary: 58000, experience: 5 },
        { id: 7, name: "Arjun Nair", age: 27, department: "IT", city: "Chennai", salary: 54000, experience: 3 },
        { id: 8, name: "Priya Singh", age: 30, department: "Finance", city: "Mumbai", salary: 72000, experience: 7 },
        { id: 9, name: "Vikram Desai", age: 40, department: "Management", city: "Ahmedabad", salary: 90000, experience: 15 },
        { id: 10, name: "Anjali Gupta", age: 24, department: "Marketing", city: "Pune", salary: 48000, experience: 1 },
        { id: 11, name: "Rohit Sharma", age: 33, department: "IT", city: "Bangalore", salary: 67000, experience: 8 },
        { id: 12, name: "Meera Iyer", age: 29, department: "Finance", city: "Chennai", salary: 61000, experience: 4 },
        { id: 13, name: "Sahil Khan", age: 36, department: "Management", city: "Delhi", salary: 88000, experience: 12 },
        { id: 14, name: "Pooja Patel", age: 25, department: "HR", city: "Ahmedabad", salary: 45000, experience: 2 },
        { id: 15, name: "Aditya Jain", age: 34, department: "Marketing", city: "Mumbai", salary: 70000, experience: 9 }
    ];

    const query = new DevExpress.data.query(employees);
    const count = await query.count();

    console.log("Count : ", count);

    const maxAge = await query.max("age");
    console.log("MaxAge : ", maxAge);

    const higestExperienceInIT = await query.filter(["department", "=", "IT"]).max("experience");
    console.log("higestExperienceInIT: ", higestExperienceInIT);

    const sortedByNameThenAge = await query.sortBy("name").thenBy("age").toArray();
    console.log("sortedByNameThenAge : ", sortedByNameThenAge);

    const step = function (total, itemData) {
        // "total" is an accumulator value that should be changed on each iteration
        // "itemData" is the item to which the function is being applied
        return total + itemData.salary;
    }

    const finalize = function (total) {
        // "total" is the resulting accumulator value
        return total;
    }

    const totalSalary = await query.aggregate(0, step, finalize);
    console.log("TotalSalary : ", totalSalary);

    $("#grid").dxDataGrid({
        dataSource: employees,
    });
});
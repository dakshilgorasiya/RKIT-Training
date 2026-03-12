$(() => {
    const employees = [
        { id: 1, name: "Amit Patel", age: 28, department: "IT", city: "Ahmedabad", salary: 60000, experience: 3 },
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

    const filteredData1 = new DevExpress.data.query(employees).filter(function (data) {
        if (data.experience >= 10) {
            return true;
        } else {
            return false;
        }
    }).toArray();

    // Operator: <, >, <=, >=, =, <>, startswith, endswith, contains, notcontains, !, and, or

    // employee who are in it and have less than 5 years of experience
    const filteredData2 = new DevExpress.data.query(employees).filter([["department", "=", "IT"], "and", ["experience", "<=", 5]]).toArray();

    // find sum of salary
    new DevExpress.data.query(employees).sum("salary").done((result) => {
        console.log("Cost: ", result);
    });

    new DevExpress.data.query(employees).avg("salary").done((result) => {
        console.log("Avg: ", result)
    })

    // Other function
    // aggregate
    // avg
    // count
    // enumerate
    // filter
    // groupby
    // max
    // min
    // slice(skip, take)
    // sortBy(selector, desc)
    // sum
    // thenBy(selector) // Sorts data items by one more selector
    // toArray

    $("#grid").dxDataGrid({
        dataSource: filteredData2,
    });
});
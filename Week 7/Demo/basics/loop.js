let arr = ["a", "b", "c", "d", "e"];

// For loop
console.log("For loop:");
for (let i = 0; i < arr.length; i++) {
  console.log(`Index: ${i}, Value: ${arr[i]}`);
}

// For...of loop
console.log("For...of loop:");
for (let value of arr) {
  console.log(`Value: ${value}`);
}

// For...in loop
console.log("For...in loop:");
for (let index in arr) {
  console.log(`Index: ${index}, Value: ${arr[index]}`);
}

// forEach method
console.log("forEach method:");
arr.forEach((value, index) => {
  console.log(`Index: ${index}, Value: ${value}`);
});

// map
console.log("map method:");
let upperArr = arr.map((value) => console.log(value));

let obj = {
  name: "John",
  age: 30,
  city: "New York",
};

console.log("Object iteration using for...in:");
for (let key in obj) {
  console.log(`Key: ${key}, Value: ${obj[key]}`);
}

console.log("Object iteration using Object.keys and forEach:");
Object.keys(obj).forEach((key) => {
  console.log(`Key: ${key}, Value: ${obj[key]}`);
});

console.log("Object iteration using Object.entries and for...of:");
for (let [key, value] of Object.entries(obj)) {
  console.log(`Key: ${key}, Value: ${value}`);
}

let count = 0;

// While loop
console.log("While loop:");
while (count < 5) {
  console.log(`Count: ${count}`);
  count++;
}

// Do...while loop
console.log("Do...while loop:");
let num = 0;
do {
  console.log(`Number: ${num}`);
  num++;
} while (num < 5);

// Using break and continue
console.log("Using break and continue:");
for (let i = 0; i < 10; i++) {
  if (i % 2 === 0) {
    continue; // Skip even numbers
  }
  console.log(`Odd Number: ${i}`);
  if (i === 7) {
    break; // Exit loop when i is 7
  }
}

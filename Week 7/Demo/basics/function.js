// hosting example
console.log(add(2, 3)); // 5
// console.log(sub(5, 2)); // Error: Cannot access 'sub' before initialization
// console.log(mul(2, 3)); // Error: Cannot access 'mul' before initialization

// three ways to declare a function
// 1. function declaration
function add(a, b) {
  return a + b;
}

// 2. function expression
let sub = function (a, b) {
  return a - b;
};

// 3. arrow function
let mul = (a, b) => {
  return a * b;
};

console.log(add(2, 3)); // 5
console.log(sub(5, 2)); // 3
console.log(mul(2, 3)); // 6

// IIFE - Immediately Invoked Function Expression
(function () {
  console.log("IIFE function executed");
})();

// Scope
function outer() {
  let outerVar = "I am from outer function";

  function inner() {
    console.log(outerVar); // Accessing outer function variable
  }

  return inner;
}

let innerFunc = outer();
innerFunc(); // Logs: I am from outer function

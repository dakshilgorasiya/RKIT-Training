console.log(a); // Output: undefined
console.log(window.a); // Output: undefined  (referencing global variable 'a')
// console.log(b); // ReferenceError: Cannot access 'b' before initialization
// console.log(c); // ReferenceError: c is not defined

fun1(); // Output: "Inside fun1"
// fun2(); // ReferenceError: fun2 is not defined

var a = 10;
let b = 20;
c = 30; // Implicitly creates a global variable (not recommended)

function fun1() {
  console.log("Inside fun1");
}

fun2 = function () {
  console.log("Inside fun2");
};

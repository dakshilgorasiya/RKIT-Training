class StaticExample {
  static staticProperty = "I am a static property";

  static staticMethod() {
    return "I am a static method";
  }

  instanceMethod() {
    return "I am an instance method";
  }
}

// Accessing static property and method without creating an instance
console.log(StaticExample.staticProperty); // Output: I am a static property
console.log(StaticExample.staticMethod()); // Output: I am a static method
// Creating an instance to access instance method
const instance = new StaticExample();
console.log(instance.instanceMethod()); // Output: I am an instance method

console.log(instance)

// Equivalent ES5 code:

// function StaticExample() {}
// StaticExample.staticProperty = "I am a static property";
// StaticExample.staticMethod = function () {
//   return "I am a static method";
// };
// StaticExample.prototype.instanceMethod = function () {
//   return "I am an instance method";
// };
// // Accessing static property and method without creating an instance
// console.log(StaticExample.staticProperty); // Output: I am a static property
// console.log(StaticExample.staticMethod()); // Output: I am a static method
// // Creating an instance to access instance method
// var instance = new StaticExample();
// console.log(instance.instanceMethod()); // Output: I am an instance method

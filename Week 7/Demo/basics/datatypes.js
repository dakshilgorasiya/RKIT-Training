// primitive datatype

// 1. Number
let a = 10;
let b = 10.2;

// 2. String
let c = "abc";
let d = "abc";
let e = `abc${a}`; // String interpolation

// 3. Boolean
let f = false;

// 4. Undefined
// value not defined
let g;

// 5. Null
// Represent intensional empty value
let h = null;

// 6. BigInt
let i = 9007199254740991n;

// 7. Symbox
let j = Symbol("id");

// non-primitive data type

// Object
let k = {
  name: "dakshil",
  college: "bvm",
};

// Array
let l = [1, 2, 3];

// Function
let m = function () {
  console.log("FUNCTION");
};

// memory allocation
let name = "a";
let anotherName = name;
anotherName = "b";
console.log(name); // a
console.log(anotherName); // b

let ob = {
  name: "a",
};

let anotherOb = ob;

anotherOb.name = "b";

console.log(ob); // {name: b}
console.log(anotherOb); // {name: b}

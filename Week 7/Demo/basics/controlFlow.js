const balance = 1000;

// if block include only first statement, second statement will be executed always
if (balance > 500) console.log("test"), console.log("test2");

// switch case syntax
// switch (key) {
//     case value:

//         break;

//     default:
//         break;
// }

const month = 3;

switch (month) {
  case 1:
    console.log("January");
    break;
  case 2:
    console.log("February");
    break;
  case 3:
    console.log("March");
    break;
  case 4:
    console.log("April");
    break;
  default:
    console.log("Default");
    break;
}

//truthi falsi value
/*
false : 0, -0, 0n(BigInt), "", null, undefined, Nan

true : "0", 'false', " ", [](emptyArray), {}(emptyObject), function(){}(emptyFunction)
Anything inside string is true
*/

const userEmail = [];

if (userEmail.length === 0) {
  console.log("Array is empty");
}

const emptyObj = {};

if (Object.keys(emptyObj).length === 0) {
  console.log("Object is empty");
}

// Nullish Coalescing Operator (??): null undefined
// ?? use to stay safe from null and undefined value it will assign first value from left to right which is not null nor undefined

let val1;
val1 = 5 ?? 10; // 5
val1 = null ?? 10; // 10
val1 = undefined ?? 15; // 15

val1 = null ?? 10 ?? 20; // 10
val1 = null ?? undefined ?? 11; // 11

console.log(val1);


// Logical OR Operator (||): falsy values
// || use to stay safe from falsy values it will assign first value from left to right which is not falsy
val1 = 5 || 10; // 5
val1 = 0 || 10; // 10
val1 = "" || 15; // 15
val1 = null || 10 || 20; // 10
val1 = undefined || 0 || 11; // 11

// Terniary Operator
// condition ? true : false

const iceTeaPrice = 100;

iceTeaPrice <= 80 ? console.log("Less then 80") : console.log("More than 80");

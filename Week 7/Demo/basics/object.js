const mySyn = Symbol("key1");

const user = {
  name: "dakshil",
  "full name": "gorasiya dakshil r",
  [mySyn]: "mykey1", // if we write mySyn = "mykey1" than it will take mySyn as string not as symbol
  age: 18,
  location: "anand",
  isLoggedIn: false,
  lastLoginDays: ["Monday", "Saturday"],
};

console.log(user.name); // dakshil
console.log(user["full name"]); // gorasiya dakshil r
console.log(user[mySyn]); // mykey1
console.log(user.lastLoginDays[0]); // Monday

Object.freeze(user);
user.name = "abc"; // will not work as object is freezed

console.log(user.name); // dakshil

user.greeting = function () {
  console.log("hello user");
};

const ob = new Object();
ob.fun = function () {
  console.log("hello from ob");
};
ob.fun();

const obj1 = {
  1: "a",
  2: "b",
};

const obj2 = {
  3: "a",
  4: "b",
};

const obj3 = Object.assign({}, obj1, obj2);
console.log(obj3); // {1: 'a', 2: 'b', 3: 'a', 4: 'b'}

const obj4 = { ...obj1, ...obj2 };
console.log(obj4); // {1: 'a', 2: 'b', 3: 'a', 4: 'b'}

console.log(Object.keys(obj3)); // [ '1', '2', '3', '4' ]
console.log(Object.values(obj3)); // [ 'a', 'b', 'a', 'b' ]
console.log(Object.entries(obj3)); // [ [ '1', 'a' ], [ '2', 'b' ], [ '3', 'a' ], [ '4', 'b' ] ]
console.log(obj3.hasOwnProperty("1")); // true

// Object destructuring
const { 1: firstProp, 2: secondProp } = obj1;
console.log(firstProp); // a
console.log(secondProp); // b

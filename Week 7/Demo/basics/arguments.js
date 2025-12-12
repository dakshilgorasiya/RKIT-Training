// pass by value
function fun1(x) {
  x = 50;
  console.log("Inside function : ", x);
}
x = 10;
fun1();
console.log("Outside function : ", x);

// pass by reference
function fun2(ob) {
  ob.name = "a";
  console.log("Inside function : ", ob.name);
}
ob = { name: "b" };
fun2(ob);
console.log("Outside function : ", ob.name);

// Default argument
function greet(name = "Guest") {
  console.log("Hello ", name);
}
greet();
greet("user");

// Rest parameter
function sum(...args) {
  ans = 0;
  for (i of args) {
    ans += i;
  }
  return ans;
}
console.log(sum(1, 2, 3, 4));

// Argument object
function show() {
  console.log(arguments[0]);
  console.log(arguments);
}
show(1, 2, 3);

// Named argument using object
function createUser({ name, age, city }) {
  console.log(name, age, city);
}
createUser({ name: "dakshil", age: 21, city: "Bhanvanagar" });

// Passing function as arguments (callback function)
function process(cb) {
  cb();
}
process(() => console.log("Hello"));

// Call, apply, bind
function intro(age, city) {
  console.log(this.name, age, city);
}
const user = { name: "dakshil" };
intro.call(user, 21, "anand");
intro.apply(user, [21, "anand"]);
fn = intro.bind(user, 21, "anand");
fn();

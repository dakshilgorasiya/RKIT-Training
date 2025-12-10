// 3 ways to declare a variable in JavaScript

// 1. Using var (globally-scoped or function-scoped)
var name = "Alice";
console.log("Using var:", name); // alice

// 2. Using let (block-scoped)
let age = 25;
console.log("Using let:", age); // 25

{
  let age = 30; // This 'age' is different from the one outside the block
  console.log("Using let inside block:", age); // 30

  var name = "Bob"; // This 'name' will overwrite the outer 'name'
  console.log("Using var inside block:", name); // Bob
}

console.log("Using var outside block after reassignment:", name); // Bob
console.log("Using let outside block:", age); // 25

// 3. Using const (block-scoped, cannot be reassigned)
const country = "USA";
console.log("Using const:", country);

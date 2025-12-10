const myArr = [1, 2, 3, "dakshil", false];

console.log(myArr[1]); // 2

const myArr2 = new Array(1, 2, 3);
console.log(myArr2); // [1, 2, 3]

// methods
myArr.push("pushed");
console.log(myArr); // [1, 2, 3, "dakshil", false, "pushed"]
console.log(myArr.pop()); // pushed (if array is empty return undefined)

const s = myArr.join(", ");
console.log(s); // 1, 2, 3, dakshil, false

// Does not modify original array
const my1 = myArr.slice(2, 3); // [3]
console.log(my1);

// modify original array
// Removes elements from an array and, if necessary, inserts new elements in their place, returning the deleted elements.
// start, deletecount, ...new items
const my2 = myArr.splice(2, 3, "new1", "new2");
console.log(my2); // [3, 'dakshil', false]
console.log(myArr); // [1, 2, 'new1', 'new2']

const l1 = [1, 2, 3];
const l2 = [4, 5, 6];

// concat two array without modifying it
let l3 = l1.concat(l2);
console.log(l3); // [1,2,3,4,5,6]

// spead operator
let l4 = [...l1, ...l2];
console.log(l4); // [1,2,3,4,5,6]

const nestedArray = [1, 2, 3, [4, [5, [6, 7, 8]], 9]];
const flattenArray = nestedArray.flat(Infinity); // depth
console.log(flattenArray); // [1,2,3,4,5,6,7,8,9]

console.log(Array.isArray(nestedArray));
console.log(Array.from("dakshil")); //  ['d', 'a', 'k', 's', 'h', 'i', 'l']
console.log(Array.of(1, 2, 3, 4)); // [1,2,3,4]

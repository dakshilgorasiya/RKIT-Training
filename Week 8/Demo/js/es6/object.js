const ob1 = { a: 1, b: 2 };
const ob2 = { b: 3, c: 4 };

//! Static Methods of Object

// assign() method
// Copy properties from source objects to target object
const assignedObj = Object.assign({}, ob1, ob2);
console.log(assignedObj); // { a: 1, b: 3, c: 4 }

// create() method
// Create a new object with the specified prototype object and properties
const proto = {
  greet() {
    console.log("Hello!");
  },
};
const obj = Object.create(proto);
obj.greet(); // "Hello!"
console.log(Object.getPrototypeOf(obj) === proto); // true

// to create a null prototype object
const nullProtoObj = Object.create(null);
console.log(Object.getPrototypeOf(nullProtoObj)); // null

// defineProperty() method
// Define a new property directly on an object, or modify an existing property
const person = {};

// accessor descriptor
Object.defineProperty(person, "name", {
  value: "Alice",
  writable: false, // cannot be changed
  enumerable: false, // will not show up in for...in loops
  configurable: false, // cannot be deleted or reconfigured
});
console.log(person.name); // undefined

// data descriptor
Object.defineProperty(person, "age", {
  get() {
    return this.ageValue || 30;
  },
  set(value) {
    console.log(`Setting age to ${value}`);
    this.ageValue = value;
  },
});
console.log(person.age); // 30
person.age = 31; // "Setting age to 31"
console.log(person.age); // 31

// defineProperties() method
// Define multiple properties on an object
Object.defineProperties(person, {
  gender: {
    value: "female",
    writable: true,
    enumerable: true,
    configurable: true,
  },
  country: {
    value: "USA",
    writable: false,
    enumerable: true,
    configurable: false,
  },
});
console.log(person.gender); // "female"
console.log(person.country); // "USA"

// entries() method
for (const [key, value] of Object.entries(person)) {
  console.log(`${key}: ${value}`);
}

// freeze() method
// Freeze an object to make it immutable
const frozenObj = { x: 10, y: 20 };
Object.freeze(frozenObj);
frozenObj.x = 15; // Fails silently in non-strict mode // Throws error in strict mode
console.log(frozenObj.x); // 10

// fromentries() method
const entries = [
  ["name", "Bob"],
  ["age", 25],
];
const fromEntriesObj = Object.fromEntries(entries);
console.log(fromEntriesObj); // { name: 'Bob', age: 25 }

// getOwnPropertyDescriptor() method
// Get the property descriptor for a specific property
const descriptor = Object.getOwnPropertyDescriptor(person, "gender");
console.log(descriptor);

// getOwnPropertyDescriptors() method
// Get all property descriptors of an object
const allDescriptors = Object.getOwnPropertyDescriptors(person);
console.log(allDescriptors);

// getOwnPropertyNames() method
// Get all own property names of an object
const propNames = Object.getOwnPropertyNames(person);
console.log(propNames); // ['name', 'age', 'ageValue', 'gender', 'country']

// getOwnPropertySymbols() method
// Get all own property symbols of an object
const sym1 = Symbol("sym1");
const sym2 = Symbol("sym2");
const symbolObj = {
  [sym1]: "value1",
  [sym2]: "value2",
};
const propSymbols = Object.getOwnPropertySymbols(symbolObj);
console.log(propSymbols); // [ Symbol(sym1), Symbol(sym2) ]

// getPrototypeOf() method
// Get the prototype of an object
const prototype = Object.getPrototypeOf(ob1);
console.log(prototype == Object.prototype); // true

// groupBy() method
// Group elements of an array based on a callback function
const inventory = [
  { name: "asparagus", type: "vegetables", quantity: 9 },
  { name: "bananas", type: "fruit", quantity: 5 },
  { name: "goat", type: "meat", quantity: 23 },
  { name: "cherries", type: "fruit", quantity: 12 },
  { name: "fish", type: "meat", quantity: 22 },
];
const result = Object.groupBy(inventory, ({ quantity }) =>
  quantity < 6 ? "restock" : "sufficient"
);
console.log(result);

// hasOwn() method
// Check if an object has a specific property as its own property (not inherited)
console.log(Object.hasOwn(ob1, "a")); // true
console.log(Object.hasOwn(ob1, "toString")); // false because it's inherited not own
console.log(Object.hasOwn(ob1, "c")); // false

// is() method
// Determine whether two values are the same value
console.log(Object.is(NaN, NaN)); // true

// isExtensible() method
// Check if an object is extensible (can have new properties added)
const extensibleObj = { a: 1 };
console.log("IsExtensible output : ");
console.log(Object.isExtensible(extensibleObj)); // true
Object.preventExtensions(extensibleObj);
console.log(Object.isExtensible(extensibleObj)); // false

// isFrozen() method
// Check if an object is frozen (immutable)
const frozenCheckObj = { b: 2 };
Object.freeze(frozenCheckObj);
console.log(Object.isFrozen(frozenCheckObj)); // true

// isSealed() method
// Check if an object is sealed (no new properties can be added and existing properties cannot be deleted)
const sealedObj = { c: 3 };
Object.seal(sealedObj);
console.log(Object.isSealed(sealedObj)); // true

// keys() method
// Get all own enumerable property names of an object
const keys = Object.keys(person);
console.log(keys); // ['ageValue', 'gender', 'country']

// preventExtensions() method
// The Object.preventExtensions() static method prevents new properties from ever being added to an object (i.e., prevents future extensions to the object). It also prevents the object's prototype from being re-assigned.
const nonExtensibleObj = { d: 4 };
Object.preventExtensions(nonExtensibleObj);
nonExtensibleObj.e = 5; // Fails silently in non-strict mode // Throws error in strict mode
console.log(nonExtensibleObj.e); // undefined

// seal() method
// The Object.seal() static method seals an object. Sealing an object prevents extensions and makes existing properties non-configurable. A sealed object has a fixed set of properties: new properties cannot be added, existing properties cannot be removed, their enumerability and configurability cannot be changed, and its prototype cannot be re-assigned. Values of existing properties can still be changed as long as they are writable.
const sealedObj2 = { f: 6 };
Object.seal(sealedObj2);
sealedObj2.f = 7; // Allowed because the property is writable
console.log(sealedObj2.f); // 7
delete sealedObj2.f; // Fails silently in non-strict mode // Throws error in strict mode
console.log(sealedObj2.f); // 7

// setPrototypeOf() method
// Set the prototype (i.e., the internal [[Prototype]] property) of a specified object to another object or null
const newProto = {
  sayHi() {
    console.log("Hi!");
  },
};
const obj2 = {};
Object.setPrototypeOf(obj2, newProto);
obj2.sayHi(); // "Hi!"

// values() method
// Get all own enumerable property values of an object
const values = Object.values(person);
console.log(values); // [31, 'female', 'USA']

//! Instance Methods of Object

const instanceObj = {
  x: 10,
  y: 20,
};

// hasOwnProperty() method
console.log(instanceObj.hasOwnProperty("x")); // true
console.log(instanceObj.hasOwnProperty("toString")); // false because it's inherited

// isPrototypeOf() method
// Check if an object exists in another object's prototype chain
const protoObj = {
  greet() {
    console.log("Hello from protoObj!");
  },
};
const childObj = Object.create(protoObj);
console.log(protoObj.isPrototypeOf(childObj)); // true
console.log(Object.prototype.isPrototypeOf(childObj)); // true

// propertyIsEnumerable() method
// Check if a property is enumerable and is the object's own property
console.log(instanceObj.propertyIsEnumerable("x")); // true

// toLocaleString() method
// This method is intended to be overridden by derived objects for locale-specific purposes.
// Return a string representation of the object, localized based on the host environment's current locale
console.log(instanceObj.toLocaleString()); // "[object Object]"

// toString() method
// This method is intended to be overridden by derived objects for a more meaningful string representation.
// Return a string representation of the object
console.log(instanceObj.toString()); // "[object Object]"

// valueOf() method
// This method is intended to be overridden by derived objects to provide a primitive value representation.
// Return the primitive value of the specified object
console.log(instanceObj.valueOf() === instanceObj); // true

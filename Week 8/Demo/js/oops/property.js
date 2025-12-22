class propertyDemo {
  #name; // private field
  #age;
  constructor(name, age) {
    this.#name = name;
    this.#age = age;
  }
  get name() {
    return this.#name;
  }
  set name(newName) {
    this.#name = newName;
  }
  get age() {
    return this.#age;
  }
}

let propObj = new propertyDemo("Initial Name", 20);
console.log("Initial Name via getter:", propObj.name);
propObj.name = "Updated Name";
console.log("Updated Name via getter:", propObj.name);
console.log("Age via getter:", propObj.age);
console.log(propObj);
propObj.age = 25; // This will not work as there is no setter for age
console.log(
  "Age after trying to set directly (should be unchanged):",
  propObj.age
);

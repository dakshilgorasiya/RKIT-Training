class privateExample {
  #privateField;
  constructor(value) {
    this.#privateField = value;
  }
  getPrivateField() {
    return this.#privateField;
  }
}

let privateObj = new privateExample("Secret Value");
console.log(
  "Accessing private field via method:",
  privateObj.getPrivateField()
);

// Trying to access the private field directly will result in an error
// console.log(privateObj.#privateField);  // SyntaxError
console.log(privateObj);

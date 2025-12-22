// Import the BankAccount class from Account.js
import BankAccount from "./Account.js";

// Example usage
const user1 = new BankAccount("Alice");
user1.deposit(1000);

const user2 = new BankAccount("Bob");
user2.deposit(500);

// transaction
user1.withdraw(200);
user2.deposit(200);

console.log(`${user1.accountHolder} Balance: ${user1.getBalance()}`); // Alice Balance: 800
console.log(`${user2.accountHolder} Balance: ${user2.getBalance()}`); // Bob Balance: 700

console.log(BankAccount.info()); // Bank System v1.0

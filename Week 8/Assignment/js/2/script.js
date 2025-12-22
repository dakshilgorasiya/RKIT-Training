/// BankAccount class to manage user accounts
class BankAccount {
  /// Constructor to initialize account holder and balance
  /// <param name="accountHolder" type="string">Name of the account holder</param>
  constructor(accountHolder) {
    // Initialize account holder to the provided name
    this.accountHolder = accountHolder;

    // Initialize balance to zero
    this.balance = 0;
  }

  /// Method to deposit money into the account
  /// <param name="amount" type="number">Amount to deposit</param>
  deposit(amount) {
    // Add amount to balance
    this.balance += amount;
  }

  /// Method to withdraw money from the account
  /// <param name="amount" type="number">Amount to withdraw</param>
  withdraw(amount) {
    // Check for sufficient balance
    if (amount <= this.balance) {
      // Deduct amount from balance
      this.balance -= amount;
    } else {
      // Log insufficient funds message
      console.log("Insufficient funds");
    }
  }

  /// Method to get the current balance
  getBalance() {
    return this.balance;
  }

  /// Static method to get bank system info
  static info() {
    return "Bank System v1.0";
  }
}

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

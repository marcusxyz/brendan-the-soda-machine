using System;
using static System.Console;

using BrendanTheSodaMachine;
using System.Collections;
/************

Implement vending machine:

- User should have a name and some money
- Create some sort of dialog between user and vending machine
- Display a menu for purchase, current balance, withdrawal and purchase history
- Select item to dispense
- Payment

*************/

// Get randon int to insert into Bank Account
Random random = new Random();
int randomInt = random.Next(0, 50);

var account = new BankAccount("Mr.Silverhand", randomInt);
Stack transactionLog = new Stack();
var brendan = new VendingMachine("Brendan", account, transactionLog);
brendan.Start();
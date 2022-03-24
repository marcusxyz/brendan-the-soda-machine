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
Random r = new Random();
int rInt = r.Next(0, 50);

var account = new BankAccount("Mr.Silverhand", rInt);
Stack transactionLog = new Stack();
var brendan = new VendingMachine("Brendan", 80, account, transactionLog);
brendan.Start();
using System;
using static System.Console;

using BrendanTheSodaMachine;
/************

Implement vending machine:

- User should have a name and some money
- Create some sort of dialog between user and vending machine
- Display a menu for purchase, current balance, withdrawal and purchase history
- Select item to dispense
- Payment

*************/

var account = new BankAccount("Mr.Silverhand", 1000);
var brendan = new VendingMachine("Brendan", 80, account);
brendan.Start();
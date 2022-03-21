using System;
using static System.Console;

namespace BrendanTheSodaMachine;
/************

Implement vending machine:

- User should have a name and some money
- Create some sort of dialog between user and vending machine
- Display a menu for purchase, current balance, withdrawal and purchase history
- Select item to dispense
- Payment

*************/

class Program
{
    static void Main(string[] args)
    {
    var brendan = new VendingMachine("Brendan", 80);
    brendan.Start();
    }
}
using System;
using static System.Console;

namespace BrendanTheSodaMachine;

class BankAccount
{
	public string Owner { get; }
	private int Balance { get; set; } = 250;

	public BankAccount(string name, int balance)
	{
		Owner = name;
		Balance = balance;
	}

	public int GetBalance()
	{
		return Balance;
	}
}

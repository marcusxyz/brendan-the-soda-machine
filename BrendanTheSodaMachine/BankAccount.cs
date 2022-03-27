using System;
using static System.Console;

namespace BrendanTheSodaMachine;

public class BankAccount
{
	public string Owner { get; }
	public int Balance { get; set; }

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

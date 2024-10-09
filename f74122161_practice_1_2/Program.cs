using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace F74122161_practice_1_2
{
    internal class Program
    {
        static int CheckInput()
        {
            string input = Console.ReadLine();
            if (input == null) return -1;
            int amount;
            try
            {
                amount = Int32.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("plz input an integer\n\n");
                return -1;
            }
            catch (OverflowException)
            {
                Console.WriteLine("too large\n\n");
                return -1;
            }
            return amount;
        }

        static void InitializeAccount(Dictionary<int, int> account)
        {
            for (int i = 0; i < 10; i++)
            {
                account.Add(10000 + 1000 * i, 10000);
            }
        }
        static void Main(string[] args)
        {
            Dictionary<int, int> accounts = new Dictionary<int, int>();
            List<KeyValuePair<int, int>> history = new List<KeyValuePair<int, int>>();
            InitializeAccount(accounts);
            Console.WriteLine("Welcome to NiCKU ATM\n");
            int account;
            int donation = 0;
            while (true)
            {
                Console.WriteLine("Please enter your account number : ");
                int accountNumber = CheckInput();
                if (accountNumber == -1)
                {
                    Console.WriteLine("Not a number\n\n");
                    continue;
                }
                else if (accounts.ContainsKey(accountNumber))
                {
                    Console.WriteLine("Account number already exists, please try another\n\n");
                }
                else if (accountNumber < 10000 || accountNumber > 99999)
                {
                    Console.WriteLine("Account number should be five digits\n\n");
                }
                else
                {
                    accounts.Add(accountNumber, 10000);
                    account = accountNumber;
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("\b\b(0)Check balance");
                Console.WriteLine("\b\b(1)Withdraw money");
                Console.WriteLine("\b\b(2)Desposit money");
                Console.WriteLine("\b\b(3)Trasfer money");
                Console.WriteLine("\b\b(4)Donate");
                Console.WriteLine("\b\b(5)History");
                Console.WriteLine("\b\b(8)Exit");

                int option = CheckInput();
                switch (option)
                {
                    case 0:
                        Console.WriteLine($"Balance : {accounts[account]}\n\n");
                        continue;

                    case 1:
                        Console.Write("Enter amout : ");
                        int amount = CheckInput();
                        if (amount == -1)
                        {
                            continue;
                        }
                        else if (amount < 0 || amount > accounts[account] || amount > 100000)
                        {
                            Console.WriteLine("Exceed the valid amount\n\n");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("SUccessfully withdraw");
                            accounts[account] -= amount;
                            Console.WriteLine($"Balance : {accounts[account]}\n\n");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter amout : ");
                        amount = CheckInput();
                        if (amount == -1)
                        {
                            continue;
                        }
                        else if (amount < 0 || amount > 100000)
                        {
                            Console.WriteLine("Exceed the valid amount\n\n");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Successfully withdraw");
                            accounts[account] += amount;
                            Console.WriteLine($"Balance : {accounts[account]}\n\n");
                        }
                        break;

                    case 3:
                        Console.WriteLine();
                        Console.Write("Enter transfer account : ");
                        int transferAccount;
                        transferAccount = CheckInput();
                        if (transferAccount == -1) continue;
                        else if (transferAccount < 10000 || transferAccount > 99999)
                        {
                            Console.WriteLine("Account number should be five digits\n\n");
                            continue;
                        }
                        else if (transferAccount == account)
                        {
                            Console.WriteLine("Cannot transfer to the same account\n\n");
                            continue;
                        }
                        else if (!accounts.ContainsKey(transferAccount))
                        {
                            Console.WriteLine("Account does not exist, do you want to create one? (y/n)");
                            string input = Console.ReadLine();
                            if (input == "y")
                            {
                                accounts.Add(transferAccount, 0);
                            }
                            else if (input == "n")
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input\n\n");
                                continue;
                            }
                        }
                        Console.Write("Enter amount : ");
                        amount = CheckInput();
                        if (amount == -1) continue;
                        else
                        {
                            if (donation / 1000 >= 1)
                            {
                                Console.WriteLine($"You have {donation / 1000} donation points, do you want to use them? (y/n)");
                                string input = Console.ReadLine();
                                if (input == "y")
                                {
                                    donation -= 1000;
                                    Console.WriteLine("Successfully use donation points");
                                    Console.WriteLine($"Final cost = {amount}");
                                    if (amount < 0 || amount > accounts[account])
                                    {
                                        Console.WriteLine("Final cost should > 0 and < account balance");
                                    }
                                    Console.WriteLine("Successfully withdraw");
                                    accounts[account] -= amount;
                                    accounts[transferAccount] += amount;
                                    Console.WriteLine($"Balance : {accounts[account]}\n\n");
                                }
                                else if (input == "n")
                                {
                                    Console.WriteLine($"Final cost (+10%) = {amount * 1.1}");
                                    if (amount < 0 || amount * 1.1 > accounts[account])
                                    {
                                        Console.WriteLine("Final cost should > 0 and < account balance");
                                    }
                                    Console.WriteLine("Successfully withdraw");
                                    accounts[account] -= (int)(amount * 1.1);
                                    accounts[transferAccount] += amount;
                                    Console.WriteLine($"Balance : {accounts[account]}\n\n");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input\n\n");
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Final cost (+10%) = {amount * 1.1}");
                                if (amount < 0 || amount * 1.1 > accounts[account])
                                {
                                    Console.WriteLine("Final cost should > 0 and < account balance");
                                }
                                Console.WriteLine("Successfully withdraw");
                                accounts[account] -= (int)(amount * 1.1);
                                accounts[transferAccount] += amount;
                                Console.WriteLine($"Balance : {accounts[account]}\n\n");
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter amount to donate : ");
                        amount = CheckInput();
                        if (amount == -1)
                        {
                            continue;
                        }
                        else if (amount < 0 || amount > accounts[account])
                        {
                            Console.WriteLine("Amount should > 0 and < account balance");
                        }
                        else
                        {
                            Console.WriteLine("Successfully donate");
                            accounts[account] -= amount;
                            donation += amount;
                            Console.WriteLine($"Balance : {accounts[account]}\n\n");
                        }
                        break;

                    case 5:
                        for (int i = 0; i < history.Count; i++)
                        {
                            Console.WriteLine($"Option : {history[i].Key}, Amount : {history[i].Value}");
                        }
                        break;

                    case 8:
                        Console.WriteLine("Exit\n\n");
                        return;

                    case 65304:
                        Console.WriteLine("Welcome to the backend system\n\n");
                        Console.WriteLine("All accounts : ");
                        foreach (var acc in accounts)
                        {
                            Console.WriteLine($"Account : {acc.Key} - {acc.Value}");
                        }
                        break;

                    default:
                        Console.WriteLine("not an option\n\n");
                        break;
                }
                history.Add(new KeyValuePair<int, int>(option, accounts[account]));
            }
        }
    }
}
using System;
using System.Security.Principal;

namespace F74122161_practice_1_1
{
    internal class Program
    {

        static int CheckInput (string input)
        {
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
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to NiCKU ATM\n");
            int balance = 10000;
            while (true)
            {
                // choice
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("\b\b(0)Check balance");
                Console.WriteLine("\b\b(1)WIthdraw money");
                Console.WriteLine("\b\b(2)Desposit money");
                Console.WriteLine("\b\b(3)Trasfer money");
                Console.WriteLine("\b\b(8)Exit");

                // input
                string input;
                input = Console.ReadLine();

                int option, amount;
                option = CheckInput(input);
                if (option == -1) continue;
                else if (option == 0)
                {
                    Console.WriteLine($"Balance : {balance}\n\n");
                }
                else if (option == 1)
                {

                    Console.Write("Enter amout : ");
                    input = Console.ReadLine();
                    amount = CheckInput(input);
                    if (amount == -1)
                    {
                        continue;
                    }
                    else if (amount < 0 || amount > balance || amount > 100000)
                    {
                        Console.WriteLine("Exceed the valid amount\n\n");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("SUccessfully withdraw");
                        balance -= amount;
                        Console.WriteLine($"Balance : {balance}\n\n");
                    }
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter amout : ");
                    input = Console.ReadLine();
                    amount = CheckInput(input);
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
                        Console.WriteLine("SUccessfully withdraw");
                        balance += amount;
                        Console.WriteLine($"Balance : {balance}\n\n");
                    }
                }
                else if (option == 3)
                {
                    Console.WriteLine();
                    Console.Write("Enter transfer account : ");
                    int account;

                    input = Console.ReadLine();
                    account = CheckInput(input);
                    if (account == -1)
                    {
                        continue;
                    }
                    
                    Console.Write("Enter amount : ");
                    input = Console.ReadLine();
                    amount = CheckInput(input);
                    if (amount == -1)
                    {
                        continue;
                    }
                    else if (amount < 0 || amount * 1.1 > balance)
                    {
                        Console.WriteLine("Amount should > 0 and < account balance");
                    }
                    else
                    {
                        Console.WriteLine($"Final cost (+10%) = {amount * 1.1}");
                        Console.WriteLine("Successfully withdraw");
                        balance -= (int)(amount * 1.1);
                        Console.WriteLine($"Balance : {balance}\n\n");
                    }
                }
                else if (option == 8)
                {
                    System.Console.WriteLine("Exit\n\n");
                    break;
                }
                else
                {
                    Console.WriteLine("not an option\n\n");
                    continue;
                }
            }
            return;
        }
    }
}
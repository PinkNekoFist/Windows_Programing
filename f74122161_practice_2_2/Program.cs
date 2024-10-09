using System.Collections;
using System.Numerics;

namespace f74122161_practice_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("Welcome to the NCKU kirpy shop system!");
            Product[] products = null;
            Dictionary<string, int> customerNumber = new Dictionary<string, int>();
            List<Customer> customers = new List<Customer>();
            int income = 0;
            while (true)
            {
                Console.WriteLine("======================================");
                Console.WriteLine("(1) open the shop");
                Console.WriteLine("(2) add a new offer");
                Console.WriteLine("(3) check the stock");
                Console.WriteLine("(4) check total income");
                Console.WriteLine("(5) calculate the popularity rank of each product");
                Console.WriteLine("(6) close the shop");
                Console.WriteLine("======================================");
                Console.Write("Please enter your choice: ");
                string choice = Console.ReadLine();
                try
                {
                    int.Parse(choice);
                }
                catch
                {
                    Console.WriteLine("Invalid choice, please input number 1-6.");
                    continue;
                }
                switch (choice)
                {
                    case "1":
                        OpenShop(ref products);
                        break;
                    case "2":
                        AddOffer(products, ref income, customerNumber, customers);
                        break;
                    case "3":
                        CheckStock(products);
                        break;
                    case "4":
                        CheckIncome(products, income);
                        break;
                    case "5":
                        CalculatePopularityRank(products);
                        break;
                    case "6":
                        Console.WriteLine("The shop is closed.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please input number 1-6.");
                        break;
                }
            }
        }

        static void OpenShop(ref Product[] products)
        {
            int n;
            while (true)
            {
                Console.WriteLine("How many kinds of products do you have?");
                string input = Console.ReadLine();
                if (int.TryParse(input, out n) && n > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }

            products = new Product[n];
            Console.WriteLine("Input success! You have " + n + " kinds of products.");

            string[] names;
            while (true)
            {
                names = GetInputArray("Please input products' names.", n, false);
                if (names != null && names.All(name => !string.IsNullOrWhiteSpace(name)) && names.Count() == names.Distinct().Count())
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter valid product names(can't have same name).");
            }

            string[] prices;
            while (true)
            {
                prices = GetInputArray("Please input products' prices.", n, true);
                if (prices != null && prices.All(price => int.TryParse(price, out int p) && p > 0))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter valid product prices.");
            }

            string[] stocks;
            while (true)
            {
                stocks = GetInputArray("Please input products' stocks.", n, true);
                if (stocks != null && stocks.All(stock => int.TryParse(stock, out int s) && s >= 0))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter valid product stocks.");
            }

            for (int i = 0; i < n; i++)
            {
                products[i] = new Product
                {
                    Name = names[i],
                    Price = int.Parse(prices[i]),
                    Stock = int.Parse(stocks[i]),
                    Sold = 0
                };
            }
            Console.WriteLine("The shop is opened.");
        }

        static void AddOffer(Product[] products, ref int income, Dictionary<string, int> customerNumber, List<Customer> customers)
        {
            {
                if (products == null || products.Length == 0)
                {
                    Console.WriteLine("The shop is not open yet.");
                    return;
                }

                string[] numbers = GetInputArray("Please input a list of quantities of the items you want to buy.", products.Length);
                if (numbers == null) return;

                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i].Stock < int.Parse(numbers[i]))
                    {
                        Console.WriteLine("Sorry, the stock of " + products[i].Name + " is not enough.");
                        return;
                    }
                }

                int total = 0;
                for (int i = 0; i < products.Length; i++)
                {
                    products[i].Stock -= int.Parse(numbers[i]);
                    products[i].Sold += int.Parse(numbers[i]);
                    total += products[i].Price * int.Parse(numbers[i]);
                }
                Console.WriteLine("The total price is " + total + ".");
                // randomize a number between 1-9 for discount
                if (total >= 1000)
                {
                    Random random = new Random();
                    int discount = random.Next(1, 10);
                    Console.WriteLine("You get a " + discount + "0% discount.");
                    total = total * (10 - discount) / 10;
                    Console.WriteLine("The total price after discount is " + total + ".");
                }
                bool fail = false;
                while (true)
                {
                    Console.WriteLine("Please pay the bill, enter the money you want to pay.");
                    string pay = Console.ReadLine();
                    if (pay == "-1" && fail)
                    {
                        Console.WriteLine("The offer has been canceled.");
                        // Revert the stock and sold quantities
                        for (int i = 0; i < products.Length; i++)
                        {
                            products[i].Stock += int.Parse(numbers[i]);
                            products[i].Sold -= int.Parse(numbers[i]);
                        }
                        return;
                    }
                    if (int.TryParse(pay, out int payment) && payment >= total)
                    {
                        Console.WriteLine("The change is " + (payment - total) + ".");
                        income += total;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The money is not enough or invalid input, please try again, or enter -1 to cancel the offer.");
                        fail = true;
                    }
                }

                // please input your name
                Console.WriteLine("Please input your name.");
                string name = Console.ReadLine();
                // name should only contain english letters or spaces, otherwise try again
                while (!name.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.WriteLine("Invalid name, please input your name again.");
                    name = Console.ReadLine();
                }

                if (!customerNumber.ContainsKey(name))
                {
                    customerNumber.Add(name, customerNumber.Count);
                    customers.Add(new Customer
                    {
                        Name = name,
                        Purchases = new List<int>()
                    });
                }
                customers[customerNumber[name]].Purchases.Add(total);
                // print the maximum purchase
                Console.WriteLine("The maximum purchase is " + customers[customerNumber[name]].Purchases.Max() + ".");

                // print recent 3 purchases
                Console.WriteLine("Recent 3 purchases:");
                if (customers[customerNumber[name]].Purchases.Count > 3)
                {
                    for (int i = customers[customerNumber[name]].Purchases.Count - 3; i < customers[customerNumber[name]].Purchases.Count; i++)
                    {
                        Console.WriteLine(customers[customerNumber[name]].Purchases[i]);
                    }
                }
                else
                {
                    // if less than 3 purchases, use 0 to fill the gap
                    foreach (var item in customers[customerNumber[name]].Purchases)
                    {
                        Console.WriteLine(item);
                    }
                    for (int i = 0; i < 3 - customers[customerNumber[name]].Purchases.Count; i++)
                    {
                        Console.WriteLine(0);
                    }
                }
            }
        }

        static void CheckStock(Product[] products)
        {
            if (products == null || products.Length == 0)
            {
                Console.WriteLine("The shop is not open yet.");
                return;
            }

            bool notEnough = false;
            foreach (var product in products)
            {
                if (product.Stock <= 5) notEnough = true;
                Console.WriteLine(product.Name + " : " + product.Stock);
            }
            if (notEnough) Console.WriteLine("Some products are in low stock.");
            else Console.WriteLine("All products are in sufficient stock.");
        }

        static void CheckIncome(Product[] products, int income)
        {
            if (products == null || products.Length == 0)
            {
                Console.WriteLine("The shop is not open yet.");
                return;
            }
            Console.WriteLine("The total income is " + income + ".");
        }

        static void CalculatePopularityRank(Product[] products)
        {
            if (products == null || products.Length == 0)
            {
                Console.WriteLine("The shop is not open yet.");
                return;
            }

            // copy the array
            Product[] productsCopy = new Product[products.Length];
            for (int i = 0; i < products.Length; i++)
            {
                productsCopy[i] = new Product
                {
                    Name = products[i].Name,
                    Price = products[i].Price,
                    Stock = products[i].Stock,
                    Sold = products[i].Sold
                };
            }
            // sort the copy array by sold quantity
            Array.Sort(productsCopy, (a, b) => b.Sold.CompareTo(a.Sold));
            for (int i = 1; i <= productsCopy.Length; i++)
            {
                Console.WriteLine(i + ". " + productsCopy[i - 1].Name + " : " + productsCopy[i - 1].Sold);
            }
        }

        static string[] GetInputArray(string prompt, int expectedLength)
        {
            string[] result;
            bool fail = false;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                input = input.Trim();
                if (input == "-1" && fail) return null;
                result = input.Split(' ');
                if (result.Length == expectedLength)
                {
                    bool valid = true;
                    foreach (var item in result)
                    {
                        if (!int.TryParse(item, out _))
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (valid) break;
                }
                Console.WriteLine("Invalid input. Please enter " + expectedLength + " valid integers separated by spaces, or input -1 to cancel the offer.");
                fail = true;
            }
            return result;
        }

        static string[] GetInputArray(string prompt, int expectedLength, bool isInt)
        {
            string[] result;
            if (isInt)
            {
                while (true)
                {
                    Console.WriteLine(prompt);
                    string input = Console.ReadLine();
                    input = input.Trim();
                    result = input.Split(' ');
                    if (result.Length == expectedLength)
                    {
                        bool valid = true;
                        foreach (var item in result)
                        {
                            if (!int.TryParse(item, out _))
                            {
                                valid = false;
                                break;
                            }
                        }
                        if (valid) break;
                    }
                    Console.WriteLine("Invalid input. Please enter " + expectedLength + " valid integers separated by spaces, please try again.");
                }
            }
            else
            {
                while (true)
                {
                    Console.WriteLine(prompt);
                    string input = Console.ReadLine();
                    input = input.Trim();
                    result = input.Split(' ');
                    if (result.Length == expectedLength)
                    {
                        bool valid = true;
                        foreach (var item in result)
                        {
                            // can't have same name
                            if (result.Count(x => x == item) > 1)
                            {
                                valid = false;
                                break;
                            }
                        }
                        if (valid) break;
                    }
                    Console.WriteLine("Invalid input. Please enter " + expectedLength + " valid strings separated by spaces and can't be same, please try again.");
                }
            }
            return result;
        }

        class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public int Stock { get; set; }
            public int Sold { get; set; }
        }

        class Customer
        {
            public string Name { get; set; }
            public List<int> Purchases { get; set; }
        }
    }
}
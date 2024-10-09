namespace f74122161_practice_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("Welcome to the NCKU kirpy shop system!");
            Product[] products = null;
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
                switch (choice)
                {
                    case "1":
                        OpenShop(ref products);
                        break;
                    case "2":
                        AddOffer(products, ref income);
                        break;
                    case "3":
                        CheckStock(products);
                        break;
                    case "4":
                        CheckIncome(income);
                        break;
                    case "5":
                        CalculatePopularityRank(products);
                        break;
                    case "6":
                        Console.WriteLine("The shop is closed.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void OpenShop(ref Product[] products)
        {
            Console.WriteLine("how many kinds of products do you have?");
            string input = Console.ReadLine();
            int n = int.Parse(input);
            products = new Product[n];
            Console.WriteLine("Input success! You have " + n + " kinds of products.");
            Console.WriteLine("Please input products' names.");
            string namestr = Console.ReadLine();
            string[] names = namestr.Split(' ');
            Console.WriteLine("Please input products' prices.");
            string pricestr = Console.ReadLine();
            string[] prices = pricestr.Split(' ');
            Console.WriteLine("Please input products' stocks.");
            string stockstr = Console.ReadLine();
            string[] stocks = stockstr.Split(' ');
            for (int i = 0; i < n; i++)
            {
                products[i] = new Product();
                products[i].Name = names[i];
                products[i].Price = int.Parse(prices[i]);
                products[i].Stock = int.Parse(stocks[i]);
                products[i].Sold = 0;
            }
            Console.WriteLine("The shop is opened.");
            return;
        }
        static void AddOffer(Product[] products, ref int income)
        {
            Console.WriteLine("Please input a list of quantities of the items you want to buy.");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
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
            while (true)
            {
                Console.WriteLine("Please pay the bill, enter the money you want to pay (enter -1 to cancel the offer).");
                string pay = Console.ReadLine();
                if (pay == "-1")
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
                if (int.Parse(pay) < total)
                {
                    Console.WriteLine("The money is not enough, please try again.");
                    continue;
                }
                else
                {
                    Console.WriteLine("The change is " + (int.Parse(pay) - total) + ".");
                    break;
                }
            }
            income += total;
            return;
        }

        static void CheckStock(Product[] products)
        {
            bool notEnough = false;
            foreach (var product in products)
            {
                if (product.Stock <= 5) notEnough = true;
                Console.WriteLine(product.Name + " : " + product.Stock);
            }
            if (notEnough) Console.WriteLine("Some products are in low stock.");
            else Console.WriteLine("All products are in sufficient stock.");
            return;
        }

        static void CheckIncome(int income)
        {
            Console.WriteLine("The total income is " + income + ".");
            return;
        }

        static void CalculatePopularityRank(Product[] products)
        {
            // copy the array
            Product[] productsCopy = new Product[products.Length];
            for (int i = 0; i < products.Length; i++)
            {
                productsCopy[i] = new Product();
                productsCopy[i].Name = products[i].Name;
                productsCopy[i].Price = products[i].Price;
                productsCopy[i].Stock = products[i].Stock;
                productsCopy[i].Sold = products[i].Sold;
            }
            // sort the copy array by sold quantity
            Array.Sort(productsCopy, (a, b) => b.Sold.CompareTo(a.Sold));
            for (int i = 1; i <= productsCopy.Length; i++)
            {
                Console.WriteLine(i + ". " + productsCopy[i - 1].Name + " : " + productsCopy[i - 1].Sold);
            }
        }

        class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public int Stock { get; set; }
            public int Sold { get; set; }
        }
    }
}

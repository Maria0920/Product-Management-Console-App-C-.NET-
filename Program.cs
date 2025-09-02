using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ProductStoreApplication
{

    public class Product
    {
        public static string[] categoryCodes = { "a-", "b-", "f-", "t-", "o-" };
        public static string[] categoryNames = { "Apparel", "Books", "Foods", "Toys", "Others" };

        private string productID;
        private string productCategoryName;

        public string ProductID
        {
            get { return productID; }
            set
            {
                if (IsValidCategory(value))
                {
                    productID = value;
                    productCategoryName = GetCategoryName(value);
                }
                else
                {
                    if (value.Length >= 4)
                    {
                        productID = "o-" + value[2] + value[3];
                    }
                    else
                    {
                        productID = "o-" + value;
                    }
                    productCategoryName = "Others";
                }
            }
        }

        public string ProductCategoryName
        {
            get { return productCategoryName; }
        }

        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }

        public Product()
        {
        }

        public Product(string id, string name, int quantity, double price)
        {
            ProductID = id;
            ProductName = name;
            ProductQuantity = quantity;
            ProductPrice = price;
        }

        public override string ToString()
        {
            return $"Product ID: {ProductID}\nProduct Name: {ProductName}\nCategory: {ProductCategoryName}\nQuantity: {ProductQuantity}\nPrice: {ProductPrice:C}\n";
        }

        private bool IsValidCategory(string id)
        {
            foreach (string code in categoryCodes)
            {
                bool isMatch = true;
                for (int i = 0; i < code.Length; i++)
                {
                    if (i >= id.Length || id[i] != code[i])
                    {
                        isMatch = false;
                        break;
                    }
                }

                if (isMatch)
                {
                    return true;
                }
            }

            return false;
        }

        private string GetCategoryName(string id)
        {
            for (int i = 0; i < categoryCodes.Length; i++)
            {
                bool isMatch = true;
                for (int j = 0; j < categoryCodes[i].Length; j++)
                {
                    if (j >= id.Length || id[j] != categoryCodes[i][j])
                    {
                        isMatch = false;
                        break;
                    }
                }

                if (isMatch)
                {
                    return categoryNames[i];
                }
            }

            return null;
        }
    }


    public class Program
    {
        public static void Main()
        {
            DisplayIntroduction();

            Console.WriteLine("\nPlease enter an integer which is in the range of 1 and 30 >>");
            int numProducts = InputValue(1, 30);

            Product[] products = new Product[numProducts];

            GetProductData(products);
            Console.WriteLine("****************************************************************");
            Console.WriteLine("\nInformation of all products:");

            DisplayAllProducts(products);

            GetProductLists(products);
        }
        public static void DisplayIntroduction()
        {
            Console.WriteLine("****************************************************************");
            Console.WriteLine("****************************************************************");
            Console.WriteLine("*                      N11794615 Saki Endo                     *");
            Console.WriteLine("*       This program will determine how much the book is       *");
            Console.WriteLine("*           You will be asked to enter product ID              *");
            Console.WriteLine("****************************************************************");
            Console.WriteLine("****************************************************************");
        }

        public static int InputValue(int min, int max)
        {
            int value;
            string input;
            bool isValidInput;

            do
            {
                input = Console.ReadLine();
                isValidInput = int.TryParse(input, out value);

                if (isValidInput && value >= min && value <= max)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Please re-enter a valid number between {0} and {1}.", min, max);
                }
            } while (true);
        }

        public static bool CheckString(string id)
        {
            char[] lowercaseLetters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'o', 'p', 'q', 'r', 's', 't', 'u', 'w', 'y', 'z' };

            if (id.Length != 4)
            {
                return false;
            }

            bool isFirstCharLowercase = false;
            foreach (char letter in lowercaseLetters)
            {
                if (id[0] == letter)
                {
                    isFirstCharLowercase = true;
                    break;

                }
            }

            if (!isFirstCharLowercase || id[1] != '-')
            {
                return false;
            }
            if (!(id[2] >= '0' && id[2] <= '9') || !(id[3] >= '0' && id[3] <= '9'))
            {
                return false;
            }

            return true;
        }

        private static void GetProductData(Product[] products)
        {
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine("****************************************************************");
                Console.WriteLine($"Enter Product{i + 1} name >>:");
                string name = Console.ReadLine();

                Console.WriteLine("Products category codes are");
                Console.WriteLine("a-     Apparel");
                Console.WriteLine("b-     Books");
                Console.WriteLine("f-     Food");
                Console.WriteLine("t-     Toys");
                Console.WriteLine("o-     Others");


                Console.Write("Enter product id which starts with a category code and ends with a 2-digit number >> ");
                string id = Console.ReadLine();

                while (!CheckString(id))
                {
                    Console.WriteLine("Invalid format. Please re-enter a valid product ID.");
                    Console.Write("Product ID: ");
                    id = Console.ReadLine();
                }

                Console.Write("Product Name: ");

                Console.Write("Product Quantity: ");
                int quantity = InputValue(1, int.MaxValue);

                Console.Write("Product Price: ");
                double price = InputValue(1, int.MaxValue);

                products[i] = new Product(id, name, quantity, price);
            }
        }


        public static void DisplayAllProducts(Product[] products)
        {
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("****************************************************************");
        }

        private static void GetProductLists(Product[] products)
        {
            Console.WriteLine("\nEnter a category code to see the list of product in the category");

            for (int i = 0; i < Product.categoryCodes.Length; i++)
            {
                Console.WriteLine("{0} - {1}", Product.categoryCodes[i], Product.categoryNames[i]);
            }

            while (true)
            {
                Console.Write("\nEnter a category code or Z to quit: ");
                string input = Console.ReadLine();

                if (input == "Z" || input == "z")
                {
                    break;
                }

                bool foundCategory = false;
                string categoryName = "";

                for (int i = 0; i < Product.categoryCodes.Length; i++)
                {
                    if (Product.categoryCodes[i] == input)
                    {
                        foundCategory = true;
                        categoryName = Product.categoryNames[i];
                        break;
                    }
                }

                if (foundCategory)
                {
                    Console.WriteLine($"\nProducts in Category {categoryName}:");
                    foreach (Product product in products)
                    {
                        if (product.ProductCategoryName == categoryName)
                        {
                            Console.WriteLine(product);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid category code. Please re-enter a valid code or Z to quit.");
                }
            }
        }

    }

}





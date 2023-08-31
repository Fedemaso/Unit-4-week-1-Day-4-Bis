
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleRestaurant
{
    class Program
    {
        static List<string> menu = new List<string>
        {
            "Coca Cola 150 ml (E 2.50)",
            "Insalata di pollo (E 5.20)",
            "Pizza Margherita (E 10.00)",
            "Pizza 4 Formaggi (E 12.50)",
            "Pz patatine fritte (E 3.50)",
            "Insalata di riso (E 8.00)",
            "Frutta di stagione (E 5.00)",
            "Pizza fritta (E 5.00)",
            "Piadina vegetariana (E 6.00)",
            "Panino Hamburger (E 7.90)"
        };

        static void CalculateAndPrintBill(List<int> selectedItems)
        {
            Console.WriteLine(" ");
            Console.WriteLine("==============CONTO==============");
            Console.WriteLine(" ");
            double totalCost = 0.0;

            foreach (int itemIndex in selectedItems)
            {
                Console.WriteLine(menu[itemIndex]);
                string menuItem = menu[itemIndex];
                int startIndex = menuItem.IndexOf('E') + 1;
                int endIndex = menuItem.IndexOf(')');
                string priceString = menuItem.Substring(startIndex, endIndex - startIndex);
                double itemPrice = Convert.ToDouble(priceString.Trim(), CultureInfo.InvariantCulture);
                totalCost += itemPrice;
            }

            totalCost += 3.0; 


            Console.WriteLine(" ");
            Console.WriteLine($"Costo totale (compreso di coperto: E 3 ): E {totalCost:F2}");
            Console.WriteLine(" ");
            Console.WriteLine("==============CONTO==============");

            Console.WriteLine("Premi un tasto per uscire...");
            Console.ReadKey(); 
        }

        static void Main(string[] args)
        {
            List<int> selectedItems = new List<int>();

            while (true)
            {
                Console.WriteLine(" ");
                Console.WriteLine("==============MENU==============");
                Console.WriteLine(" ");
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {menu[i]}");
                }
                Console.WriteLine("11: Stampa conto finale e conferma");
                Console.WriteLine(" ");
                Console.WriteLine("==============MENU==============");
                Console.WriteLine(" ");
                Console.Write("Seleziona un numero dal menu: ");
                Console.WriteLine(" ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice >= 1 && choice <= 10)
                {
                    selectedItems.Add(choice - 1);
                }
                else if (choice == 11)
                {
                    CalculateAndPrintBill(selectedItems);
                    break;
                }
                else
                {
                    Console.WriteLine("Scelta non valida. Riprova.");
                }
            }
        }
    }
}


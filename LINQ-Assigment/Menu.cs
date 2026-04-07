namespace LINQ_Assigment
{
    internal class Menu
    {

        public static void ShowMenu()
        {
            Console.WriteLine("Välkommen till Admin för Online Store!");

            var menu = new Services();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nVälj ett alternativ:");
                Console.WriteLine("1. Visa alla elektronikprodukter");
                Console.WriteLine("2. Visa leverantörer med låg lagerstatus");
                Console.WriteLine("3. Visa total försäljning för förra månaden");
                Console.WriteLine("4. Visa de 3 mest sålda produkterna");
                Console.WriteLine("5. Produkter per kategori");
                Console.WriteLine("6. Ordrar över 1000 kr");
                Console.WriteLine("0. Avsluta program");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        menu.GetElectronicsProducts();
                        break;
                    case "2":
                        menu.GetSuppliersLowStock();
                        break;
                    case "3":
                        menu.GetTotalLastMonth();
                        break;
                    case "4":
                        menu.GetTopProducts();
                        break;
                    case "5":
                        menu.GetProductsPerCategory();
                        break;
                    case "6":
                        menu.GetOrdersOver1000();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Avslutar program...");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }

                Console.WriteLine("\n Tryck på valfri tanget");
                Console.ReadKey();

            }
        }
    }
}

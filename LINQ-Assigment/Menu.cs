namespace LINQ_Assigment
{
    internal class Menu
    {

        public void ShowMenu()
        {
            Console.WriteLine("Välkommen till Admin för Online Store!");

            var service = new Services();

            bool running = true;

            while (running)
            {
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("1. Visa alla elektronikprodukter");
                Console.WriteLine("2. Visa leverantörer med låg lagerstatus");
                Console.WriteLine("3. Visa total försäljning för förra månaden");
                Console.WriteLine("4. Visa de 3 mest sålda produkterna");
                Console.WriteLine("5. Produkter per kategori");
                Console.WriteLine("6. Ordrar över 1000 kr");
                Console.WriteLine("0. Avsluta program");

                var choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        service.GetElectronicsProducts();
                        break;
                    case "2":
                        service.GetSuppliersLowStock();
                        break;
                    case "3":
                        service.GetTotalLastMonth();
                        break;
                    case "4":
                        service.GetTopProducts();
                        break;
                    case "5":
                        service.GetProductsPerCategory();
                        break;
                    case "6":
                        service.GetOrdersOver1000();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Avslutar program...");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }

                Console.WriteLine("\nTryck på valfri tanget");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}

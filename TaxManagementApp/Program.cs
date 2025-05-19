using System;
using TaxManagementApp.Repositories; // Import the repository interface and implementation
using TaxManagementApp.Services; // Import the TaxManager service

namespace TaxManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
             // Initialize repository (in-memory for now) and pass it to the tax manager service
            var repo = new InMemoryTaxRepository();       
            var taxManager = new TaxManager(repo);

            Console.WriteLine("Welcome to the Municipality Tax Checker!");

            bool repeat = true;
            while (repeat)
            {
                // Present menu options to the user
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Check tax rate");
                Console.WriteLine("2. Add new tax record");
                Console.Write("Enter option number (1 or 2): ");
                string option = Console.ReadLine();
                // Option 1: Get the tax rate for a municipality on a specific date
                if (option == "1")
                {
                    Console.Write("Enter municipality name: ");
                    string municipality = Console.ReadLine();
                   // Check if the municipality exists in the records
                    if (!taxManager.MunicipalityExists(municipality))
                    {
                        Console.WriteLine($"Municipality '{municipality}' not found. Please try again.\n");
                        continue; // Prompt user again
                    }

                    DateTime date; // Get a valid date from the user
                    while (true)
                    {
                        Console.Write("Enter date (YYYY-MM-DD): ");
                        string dateInput = Console.ReadLine();

                        if (DateTime.TryParse(dateInput, out date))
                            break;

                        Console.WriteLine("Invalid date format. Please use YYYY-MM-DD.\n");
                    }

                    // Retrieve and display tax rate for given municipality and date
                    double rate = taxManager.GetTaxRate(municipality, date);
                    Console.WriteLine($"Tax rate for {municipality} on {date.ToShortDateString()} is: {rate}\n");
                }
                // Option 2: Add a new tax record
                else if (option == "2")
                {
                    Console.Write("Enter municipality name: ");
                    string municipality = Console.ReadLine();

                    DateTime startDate, endDate;
                    while (true)
                    {
                        Console.Write("Enter start date (YYYY-MM-DD): ");
                        if (DateTime.TryParse(Console.ReadLine(), out startDate)) break;
                        Console.WriteLine("Invalid format. Try again.");
                    }
                    // Get valid end date from user
                    while (true)
                    {
                        Console.Write("Enter end date (YYYY-MM-DD): ");
                        if (DateTime.TryParse(Console.ReadLine(), out endDate)) break;
                        Console.WriteLine("Invalid format. Try again.");
                    }

                    double rate; // Get valid rate from user
                    while (true)
                    {
                        Console.Write("Enter tax rate (e.g., 0.2 for 20%): ");
                        if (double.TryParse(Console.ReadLine(), out rate)) break;
                        Console.WriteLine("Invalid rate. Try again.");
                    }

                    taxManager.AddTaxRecord(municipality, startDate, endDate, rate);  // Add the new tax record to the system
                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter 1 or 2.\n");
                    continue;
                }

                Console.Write("Do you want to perform another action? (Y/N): ");
                string again = Console.ReadLine()?.Trim().ToUpper();
                repeat = again == "Y";
                Console.WriteLine();
            }

            Console.WriteLine("Thank you for using the Tax Checker. Bye");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public interface IUI
    {
        void ShowMenu();
        void HandleUserInput();
    }

    public class ConsoleUI : IUI
    {
        private readonly IHandler handler;

        public ConsoleUI(IHandler handler)
        {
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler)); // Kontrollera att handler inte är null
        }

        public void ShowMenu()
        {
            Console.WriteLine("1. Create Garage");
            Console.WriteLine("2. Park Vehicle");
            Console.WriteLine("3. Remove Vehicle");
            Console.WriteLine("4. List All Vehicles");
            Console.WriteLine("5. Search Vehicles");
            Console.WriteLine("6. Exit");
        }

        public void HandleUserInput()
        {
            bool exit = false;
            while (!exit)
            {
                ShowMenu();
                string? input = Console.ReadLine(); // Kan returnera null
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter garage capacity:");
                        if (int.TryParse(Console.ReadLine(), out int capacity))
                        {
                            handler.CreateGarage(capacity);
                        }
                        else
                        {
                            Console.WriteLine("Invalid capacity.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Enter vehicle type (Bus, Car, Motorcycle): ");
                        string? type = Console.ReadLine()?.ToLower(); // Försäkra oss om att vi har en giltig sträng
                        if (string.IsNullOrEmpty(type))
                        {
                            Console.WriteLine("Invalid vehicle type.");
                            break;
                        }

                        Console.WriteLine("Enter registration number: ");
                        string? regNumber = Console.ReadLine();
                        if (string.IsNullOrEmpty(regNumber))
                        {
                            Console.WriteLine("Invalid registration number.");
                            break;
                        }

                        Console.WriteLine("Enter color: ");
                        string? color = Console.ReadLine();
                        if (string.IsNullOrEmpty(color))
                        {
                            Console.WriteLine("Invalid color.");
                            break;
                        }

                        Console.WriteLine("Enter number of wheels: ");
                        if (!int.TryParse(Console.ReadLine(), out int numberOfWheels))
                        {
                            Console.WriteLine("Invalid number of wheels.");
                            break;
                        }

                        IVehicle? vehicle = null;

                        switch (type)
                        {
                            case "bus":
                                Console.WriteLine("Enter number of seats: ");
                                if (int.TryParse(Console.ReadLine(), out int seats))
                                {
                                    vehicle = new Bus(regNumber, color, numberOfWheels, seats);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid number of seats.");
                                }
                                break;

                            case "car":
                                Console.WriteLine("Enter fuel type (Bensin/Diesel): ");
                                string? fuelType = Console.ReadLine();
                                if (string.IsNullOrEmpty(fuelType))
                                {
                                    Console.WriteLine("Invalid fuel type.");
                                }
                                else
                                {
                                    vehicle = new Car(regNumber, color, numberOfWheels, fuelType);
                                }
                                break;

                            case "motorcycle":
                                Console.WriteLine("Enter cylinder volume (cc): ");
                                if (int.TryParse(Console.ReadLine(), out int cylinderVolume))
                                {
                                    vehicle = new Motorcycle(regNumber, color, numberOfWheels, cylinderVolume);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid cylinder volume.");
                                }
                                break;

                            default:
                                Console.WriteLine("Unknown vehicle type.");
                                break;
                        }

                        if (vehicle != null)
                        {
                            handler.ParkVehicle(vehicle);
                        }
                        break;

                    case "3":
                        Console.WriteLine("Enter registration number to remove:");
                        string? regToRemove = Console.ReadLine();
                        if (!string.IsNullOrEmpty(regToRemove))
                        {
                            handler.RemoveVehicle(regToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Invalid registration number.");
                        }
                        break;

                    case "4":
                        handler.ListAllVehicles();
                        break;

                    case "5":
                        // Inmatning för sökning
                        Console.WriteLine("Enter color to search:");
                        string? searchColor = Console.ReadLine();

                        Console.WriteLine("Enter number of wheels to search:");
                        if (int.TryParse(Console.ReadLine(), out int searchWheels))
                        {
                            if (!string.IsNullOrEmpty(searchColor))
                            {
                                handler.SearchVehicles(searchColor, searchWheels); // Skickar med både färg och antal hjul
                            }
                            else
                            {
                                Console.WriteLine("Invalid color.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid number of wheels.");
                        }
                        break;

                    case "6":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}

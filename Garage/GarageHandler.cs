using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public interface IHandler
    {
        void CreateGarage(int capacity);
        void ParkVehicle(IVehicle vehicle);
        void RemoveVehicle(string regNumber);
        void ListAllVehicles();
        void SearchVehicles(string color, int numberOfWheels);
    }

    public class GarageHandler : IHandler
    {
        private Garage<IVehicle>? garage;

        public void CreateGarage(int capacity)
        {
            garage = new Garage<IVehicle>(capacity);
            Console.WriteLine($"Garage created with capacity {capacity}");
        }

        public void ParkVehicle(IVehicle vehicle)
        {
            if (garage == null)
            {
                Console.WriteLine("Garage has not been created yet.");
                return;
            }

            if (garage.ParkVehicle(vehicle))
            {
                Console.WriteLine("Vehicle parked.");
            }
            else
            {
                Console.WriteLine("Garage is full.");
            }
        }

        public void RemoveVehicle(string regNumber)
        {
            if (garage == null)
            {
                Console.WriteLine("Garage has not been created yet.");
                return;
            }

            if (garage.RemoveVehicle(regNumber))
            {
                Console.WriteLine("Vehicle removed.");
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        public void ListAllVehicles()
        {
            if (garage == null)
            {
                Console.WriteLine("Garage has not been created yet.");
                return;
            }

            if (!garage.Any())
            {
                Console.WriteLine("Garage is empty.");
                return;
            }

            foreach (var vehicle in garage)
            {
                vehicle?.DisplayInfo();
            }
        }

        public void SearchVehicles(string color, int numberOfWheels)
        {
            if (garage == null)
            {
                Console.WriteLine("Garage has not been created yet.");
                return;
            }

            var foundVehicles = garage.Where(v => v != null && v.Color.Equals(color, StringComparison.OrdinalIgnoreCase) && v.NumberOfWheels == numberOfWheels);

            if (!foundVehicles.Any())
            {
                Console.WriteLine("No vehicles found matching the criteria.");
                return;
            }

            foreach (var vehicle in foundVehicles)
            {
                vehicle?.DisplayInfo();
            }
        }
    }
}

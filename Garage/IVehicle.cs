using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    // Interface för fordon
    public interface IVehicle
    {
        string RegistrationNumber { get; set; }
        string Color { get; set; } 
        int NumberOfWheels { get; set; } 


        void DisplayInfo(); // Visar information om fordonet
    }

    // Abstrakt klass som implementerar IVehicle
    public abstract class Vehicle(string regNumber, string color, int numberOfWheels) : IVehicle
    {
        public string RegistrationNumber { get; set; } = regNumber;
        public string Color { get; set; } = color;
        public int NumberOfWheels { get; set; } = numberOfWheels;


        // Abstrakt metod för att visa information, implementeras i subklasser
        public abstract void DisplayInfo();
    }

    // Subklasser
    public class Car : Vehicle
    {
        public string FuelType { get; set; }

        public Car(string regNumber, string color, int numberOfWheels, string fuelType)
            : base(regNumber, color, numberOfWheels)
        {
            FuelType = fuelType;
        }

        // Implementera DisplayInfo för att visa bilens detaljer
        public override void DisplayInfo()
        {
            Console.WriteLine($"Car: {RegistrationNumber}, Color: {Color}, Wheels: {NumberOfWheels}, Fuel: {FuelType}");
        }
    }

    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(string regNumber, string color, int numberOfWheels, int numberOfSeats)
            : base(regNumber, color, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        // Implementera DisplayInfo för att visa bussens detaljer
        public override void DisplayInfo()
        {
            Console.WriteLine($"Bus: {RegistrationNumber}, Color: {Color}, Wheels: {NumberOfWheels}, Seats: {NumberOfSeats}");
        }
    }

    public class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; set; }

        public Motorcycle(string regNumber, string color, int numberOfWheels, int cylinderVolume)
            : base(regNumber, color, numberOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }

        // Implementera DisplayInfo för att visa motorcykelns detaljer
        public override void DisplayInfo()
        {
            Console.WriteLine($"Motorcycle: {RegistrationNumber}, Color: {Color}, Wheels: {NumberOfWheels}, Cylinder Volume: {CylinderVolume}cc");
        }
    }
}

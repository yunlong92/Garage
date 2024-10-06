using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Garage<T>(int capacity) : IEnumerable<T> where T : IVehicle
    {
        private T[] vehicles = new T[capacity];
        private int count = 0;

        // Implementera IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return vehicles[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Logik för att parkera fordon
        public bool ParkVehicle(T vehicle)
        {
            if (count < capacity)
            {
                vehicles[count++] = vehicle;
                return true;
            }
            return false;
        }

        // Logik för att ta bort fordon
        public bool RemoveVehicle(string removeRegNumber)
        {
            for (int i = 0; i < count; i++)
            {
                if (vehicles[i].RegistrationNumber.Equals(removeRegNumber, StringComparison.OrdinalIgnoreCase))
                {
                    // Flytta sista fordonet till den tomma platsen
                    vehicles[i] = vehicles[count - 1];
                    vehicles[count - 1] = default;
                    count--;
                    return true;
                }
            }
            return false;
        }
    }
}

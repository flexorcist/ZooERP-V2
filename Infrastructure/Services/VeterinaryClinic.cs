﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Animals;

namespace Infrastructure.Services
{
    public class VeterinaryClinic : IVeterinaryClinic
    {
        private static readonly Random _random = new Random();

        public bool Examine(Animal animal)
        {
            if (!animal.IsHealthy)
            {
                Console.WriteLine($"{animal.Name} is not healthy.");
                return false;
            }

            // С 10% шансом клиника может найти болезнь
            if (_random.Next(0, 100) < 10)
            {
                Console.WriteLine($"Illness was found in {animal.Name}!");
                return false;
            }
            return true;
        }
    }
}

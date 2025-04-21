using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Animals;

namespace Infrastructure.Services
{
    public interface IVeterinaryClinic
    {
        bool Examine(Animal animal);
    }
}

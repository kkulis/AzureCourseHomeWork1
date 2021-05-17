using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursAzureZad1.Entities.Models
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Distance { get; set; }
        public int Minutes { get; set; }
    }
}

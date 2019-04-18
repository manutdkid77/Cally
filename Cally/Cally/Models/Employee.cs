using System;
using System.Collections.Generic;
using System.Text;

namespace Cally.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Schedule Schedule { get; set; }
    }
}

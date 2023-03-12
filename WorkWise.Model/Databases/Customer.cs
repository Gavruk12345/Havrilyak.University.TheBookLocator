using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWise.Model.Databases
{
    public class Customer : DbItem
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
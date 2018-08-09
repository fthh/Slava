using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Entities
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Pasword { get; set; }
    }
}

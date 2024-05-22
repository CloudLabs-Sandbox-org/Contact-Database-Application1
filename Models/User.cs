using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_application_2.Models
{
    public class User
    {
        internal int Age;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
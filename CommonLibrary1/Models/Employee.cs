using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary1.Models
{
    public class Employee : Person
    {
        public int Id { get; set; }
        public string CareerPost { get; set; }
        public int EmpId { get; set; }

    }
}

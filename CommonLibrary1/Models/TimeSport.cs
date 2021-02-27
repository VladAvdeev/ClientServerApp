using CommonLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class TimeSport : BaseEntity
    {
        public int Id { get; set; }
        public string FromTo { get; set; }
        public int TimeForClub { get; set; }
        public TypeSport TypeSport { get; set; }
        public Employee Employee { get; set; }
        public Gym Gym { get; set; }
    }
    public class TypeSport : BaseEntity
    {
        public int Id { get; set; }
        public string SportName { get; set; }
    }
}

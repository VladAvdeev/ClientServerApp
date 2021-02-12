using CommonLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class Client : Person
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int GymTickettId { get; set; }
        public DateTime GymTicketPeriod { get; set; }
        public DateTime GymTicketBestBefore { get; set; }
    }
}

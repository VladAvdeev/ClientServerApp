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
        public int ClubClientId { get; set; }
        public string TicketType { get; set; }
        public string TicketUseful { get; set; }
        //public DateTime GymTicketBestBefore { get; set; }
    }
}

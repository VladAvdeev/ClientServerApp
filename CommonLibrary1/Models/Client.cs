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
        public int GymTicketId { get; set; }
        public int ClubClientId { get; set; }
        public string TicketType { get; set; }
        public string TicketUseful { get; set; }
        //public DateTime GymTicketBestBefore { get; set; }
    }
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketName { get; set; }
        public string TicketPeriod { get; set; }
    }
}

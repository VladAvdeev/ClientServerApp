using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymClientServer.ViewDB
{
    public class ClientsView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ClientId { get; set; }
        public int GymTickettId { get; set; }
        public int ClubClientId { get; set; }
        public string TicketName { get; set; }
        public string TicketUseful { get; set; }
    }
}

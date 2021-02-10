using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary
{
    public class Client : Person
    {
        public int Id { get; set; }
        public int AbonementId { get; set; }
        public DateTime AbonementPeriod { get; set; }
        public DateTime AbonementBestBefore { get; set; }

    }
}

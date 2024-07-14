using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class Client
    {
        public Client()
        {
            CarOrders = new HashSet<CarOrder>();
            ClientNumberPlates = new HashSet<ClientNumberPlate>();
            ClientServices = new HashSet<ClientService>();
        }

        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public string? NoId { get; set; }

        public virtual ClientAccount? ClientAccount { get; set; }
        public virtual ICollection<CarOrder> CarOrders { get; set; }
        public virtual ICollection<ClientNumberPlate> ClientNumberPlates { get; set; }
        public virtual ICollection<ClientService> ClientServices { get; set; }
    }
}

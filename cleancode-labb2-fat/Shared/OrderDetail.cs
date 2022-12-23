using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }

    }
}

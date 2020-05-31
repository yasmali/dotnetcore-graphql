using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQlMaster.ServiceFoundation.Models
{
    public class PurchaseHistory
    {
        public int Id { get; set; }
        public Material Material { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
    }
}

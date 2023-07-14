using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RST_WebApi.Models.Dto
{
    public class OrderHeaderUpdateDTO
    {
        public int OrderHeaderId { get; set; }
        public string PickupName { get; set; }
        public string PickupPhoneNumber { get; set; }
        public string PickupEmail { get; set; }

        public string StripePaymentIntentID { get; set; }
        public string Status { get; set; }

    }
}
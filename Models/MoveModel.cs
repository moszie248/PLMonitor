using System;
using System.Collections.Generic;   
using System.Linq;   
using System.Web;   

namespace Pallet.Models
{
    public class DamageModel
    {
        public string BillID { get; set; }

        public string NumPallet { get; set; }

        public string Customer { get; set; }

        public string Branch { get; set; }

        public string CarLicense { get; set; }

        public string Driver { get; set; }

        public string Date { get; set; }

    }

    public class InvoiceModel
    {
        public string InvoiceID { get; set; }

        public string NumPallet { get; set; }

        public string Customer { get; set; }

        public string Status { get; set; }

        public string Branch { get; set; }

        public string CarLicense { get; set; }

        public string Driver { get; set; }

        public string ReciveDate { get; set; }

    }

    public class BillModel
    {
        public string BillID { get; set; }

        public string NumPallet { get; set; }

        public string Customer { get; set; }

        public string Status { get; set; }

        public string Branch { get; set; }

        public string CarLicense { get; set; }

        public string Driver { get; set; }

        public string ReturnDate { get; set; }

    }    
}

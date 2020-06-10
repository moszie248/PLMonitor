using System;
using System.Collections.Generic;   
using System.Linq;   
using System.Web;   

namespace Pallet.Models
{
    public class PalletModel
    {
        public string Invoice { get; set; }

        public string Damage { get; set; }

        public string BuyDate { get; set; }

        public string ExpDate { get; set; }

        public string PalletID { get; set; }

        public string RFIDID { get; set; }

        public string Status { get; set; }

        public string DamageDate { get; set; }

        public string Desc { get; set; }
    }

    public class PruchaseModel
    {
        public string PurchaseID { get; set; }

        public string BuyDate { get; set; }

        public string Seller { get; set; }

        public string Deadline { get; set; }

        public string Address { get; set; }

        public string Fax { get; set; }

        public string ContactName { get; set; }

        public string Tel { get; set; }

        public string List { get; set; }

        public string Number { get; set; }

        public string Price { get; set; }

        public string Total { get; set; }

        public string Status { get; set; }

        public string ReciveID { get; set; }

        public string Piece { get; set; }

        public string ReciveDate { get; set; }
    }
    public class RFIDModel
    {
        public string Invoice { get; set; }

        public string Damage { get; set; }

        public string BuyDate { get; set; }

        public string ExpDate { get; set; }

        public string RFIDID { get; set; }

        public string Desc { get; set; }

    }


    
}

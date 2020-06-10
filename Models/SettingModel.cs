using System;
using System.Collections.Generic;   
using System.Linq;   
using System.Web;   

namespace Pallet.Models
{
    public class DmgListModel
    {
        public string List { get; set; }//
        public string Desc { get; set; }
        public string Status { get; set; }


    }

    public class BranchListModel
    {
        public string ID { get; set; }
        public string CompanyName { get; set; }
        public string BranchName { get; set; }
        public string Contact { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
    }

    public class CompanyListModel
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactName { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string Note { get; set; }

    }

    public class EquipmentListModel
    {
        public string Equip { get; set; }
        public string Desc { get; set; }
        public string Status { get; set; }

    }

    public class StatusPalletListModel
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Status { get; set; }

    }

    public class StatusRFIDListModel
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Status { get; set; }

    }

    public class PositionListModel
    {
        public string PosID { get; set; }
        public string PosName { get; set; }
        public string CompanyName { get; set; }
        public string BranchName { get; set; }
        public string Desc { get; set; }
        public string Status { get; set; }


    }
    
}

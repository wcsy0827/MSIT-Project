//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace F1005.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fund
    {
        public int SerialNumber { get; set; }
        public Nullable<int> STID { get; set; }
        public string UserID { get; set; }
        public string FundName { get; set; }
        public Nullable<bool> BuyOrSell { get; set; }
        public Nullable<double> Fee { get; set; }
        public Nullable<double> Units { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<double> NAV { get; set; }
        public Nullable<double> CashFlow { get; set; }
        public bool RelateCash { get; set; }
    
        public virtual SummaryTable SummaryTable { get; set; }
        public virtual UsersData UsersData { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace F1005.Areas.Stock.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StockHistory
    {
        public int stockTradeID { get; set; }
        public int STId { get; set; }
        public string stockID { get; set; }
        public Nullable<decimal> stockPirce { get; set; }
        public Nullable<int> stockAmount { get; set; }
        public Nullable<decimal> stockTP { get; set; }
        public Nullable<int> stockFee { get; set; }
        public Nullable<int> stockTax { get; set; }
        public Nullable<int> stockNetincom { get; set; }
        public string stockNote { get; set; }
    
        public virtual StockIDList StockIDList { get; set; }
        public virtual SummaryTable SummaryTable { get; set; }
    }
}

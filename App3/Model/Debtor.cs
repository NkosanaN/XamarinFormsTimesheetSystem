using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Model
{
    public class Debtor
    {
        //[JsonProperty("coyCode")]
        public string CoyCode { get; set; }
        //[JsonProperty("debtorCode")]
        public string DebtorCode { get; set; }
        //[JsonProperty("debtorName")]
        public string DebtorName { get; set; }
        //[JsonProperty("DebtorCreditLimit")]
        public decimal DebtorCreditLimit { get; set; }
        //[JsonProperty("debtorTaxNr")]
        public string DebtorTaxNr { get; set; }
        //[JsonProperty("debtorRegNr")]
        public string DebtorRegNr { get; set; }
        //[JsonProperty("statusCode")]
        public string StatusCode { get; set; }
        //[JsonProperty("debtorGroupCode")]
        public string DebtorGroupCode { get; set; }
        //[JsonProperty("termsCode")]
        public string TermsCode { get; set; }
        public string InvoiceCurrency { get; set; }
        //[JsonProperty("termsName")]
        public string TermsName { get; set; }
        //[JsonProperty("actualDays")]
        public int ActualDays { get; set; }
        //[JsonProperty("openItemAccount")]
        public bool OpenItemAccount { get; set; }
        //[JsonProperty("emailStatements")]
        public bool EmailStatements { get; set; }
        //[JsonProperty("statementEmailAddress")]
        public string StatementEmailAddress { get; set; }
        //[JsonProperty("hasTran")]
        public bool HasTran { get; set; }
        //[JsonProperty("excludeFromAutoReminders")]
        public bool ExcludeFromAutoReminders { get; set; }
        //[JsonProperty("salesRegionCode")]
        public string SalesRegionCode { get; set; }
    }
}
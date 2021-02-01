using Accounting_DataLayer.Context;
using Acounting_ViewModel_.Accounting;
using Acounting_ViewModel_.Customer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_Bussiness_
{
    public class Account
    {
        public static AccountingBalance ReportMainForm()
        {
            AccountingBalance dn = new AccountingBalance();
            using (UnitOfWork un = new UnitOfWork())
            {
                PersianCalendar pc = new PersianCalendar();
                DateTime Value = DateTime.Now;

                DateTime Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 20);

                var test = un.AccountingRepository.Get().Select(a => a.DateTitle);
                var Income = un.AccountingRepository.Get(a => a.TypeID == 1 && a.DateTitle>= Start && a.DateTitle <= End).Select(a => a.Amount).ToList();
                var Outcome = un.AccountingRepository.Get(a => a.TypeID == 2 && a.DateTitle >= Start && a.DateTitle <= End).Select(a => a.Amount).ToList();

                dn.recive = Income.Sum();
                dn.Pay = Outcome.Sum();
                dn.Balance = dn.recive - dn.Pay;
            }
            return dn;
        }
    }
}

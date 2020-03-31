using App3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3.Viewmodel
{
    public class CommonViewModel : ViewModelBase
    {
        public static ObservableCollection<Debtor> dbtors = new ObservableCollection<Debtor>();

        public static ObservableCollection<TimeCodes> tc = new ObservableCollection<TimeCodes>();

        private static ChiliDataClient client;
        public CommonViewModel()
        {
            client = Settings.GetClient();
        }

        public async Task<List<Debtor>> GetDebtorList()
        {
            try
            {
                var items = client.GetDebtors("T", "nkosana@datasaint.com");

                foreach (var item in items)
                {
                    dbtors.Add(new Debtor
                    {
                        CoyCode = item.CoyCode,
                        DebtorCode = item.DebtorCode,
                        DebtorName = item.DebtorName,

                    });
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return dbtors.ToList();
        }

        //public async Task<List<Employee>> GetEmployeeList()
        //{
        //    try
        //    {
        //        var items = client.get("T", "nkosana@datasaint.com");

        //        foreach (var item in items)
        //        {
        //            dbtors.Add(new Debtor
        //            {
        //                CoyCode = item.CoyCode,
        //                DebtorName = item.DebtorName,

        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Write(ex.Message);
        //    }

        //    return dbtors.ToList();
        //}
        public async Task<List<TimeCodes>> GetTimeCodeList()
        {
            try
            {
                var items = client.GetTimeCodes("T", "nkosana@datasaint.com");

                foreach (var item in items)
                {
                    tc.Add(new TimeCodes
                    {
                        CoyCode = item.CoyCode,
                        DefaultVAT = item.DefaultVAT,
                        TimeCode = item.TimeCode,
                        TimeCodeChargeRate = item.TimeCodeChargeRate,
                        TimeCodeDescription = item.TimeCodeDescription
                    });
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return tc.ToList();
        }
    }
}
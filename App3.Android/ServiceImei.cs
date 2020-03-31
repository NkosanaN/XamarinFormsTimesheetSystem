//using Android.App;
//using Android.Content;
//using Android.Telephony;
//using ChiliMobile.Droid;
//using ChiliMobile.Helper;
//using System;

//[assembly: Xamarin.Forms.Dependency(typeof(ServiceImei))]
//namespace ChiliMobile.Droid
//{

//    public class ServiceImei : IServiceImei
//    {

//        public string imie { get; set; }

//        [Obsolete]
//        public void GetImei()
//        {

//            TelephonyManager manager = (TelephonyManager)Application.Context.GetSystemService(Context.TelephonyService);
//            var ActiveNetworkInfo = manager.Imei;
//            if (ActiveNetworkInfo != null && ActiveNetworkInfo.Length > 0)
//            {
//                imie = manager.Imei;

//            }
//            else
//            {
//                imie = string.Empty;

//            }

//        }
//    }
//}
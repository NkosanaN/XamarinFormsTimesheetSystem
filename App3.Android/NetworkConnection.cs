
//using Android.App;
//using Android.Content;
//using Android.Net;
//using App3.Droid;
//using App3.Helpers;

//[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection))]
//namespace ChiliMobile.Droid
//{
//    public class NetworkConnection : INetworkConnection
//    {
//        public bool IsConnected { get; set; }

//        public void checkNetworkConnection()
//        {
//            var ConnectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
//            var ActiveNetworkInfo = ConnectivityManager.ActiveNetworkInfo;
//            if (ActiveNetworkInfo != null && ActiveNetworkInfo.IsConnectedOrConnecting)
//            {
//                IsConnected = true;
//            }
//            else
//            {
//                IsConnected = false;
//            }
//            //throw new NotImplementedException();
//        }
//    }
//}
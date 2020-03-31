//using ChiliMobile.Droid;
//using ChiliMobile.Helper;
//using System.IO;
//using Xamarin.Forms;

//[assembly: Dependency(typeof(SQLiteAndroid))]

//namespace ChiliMobile.Droid
//{
//    public class SQLiteAndroid : ISQLite
//    {
//        public SQLiteAndroid() { }
//        public SQLite.SQLiteConnection GetConnection()
//        {
//            //var sqliteFileName = "AccessDb.db3";

//            //var documentpathname = Path.Combine(System.Environment.
//            //  GetFolderPath(System.Environment.
//            //  SpecialFolder.Personal), sqliteFileName);
//            //var path = Path.Combine(documentpathname,sqliteFileName);
//            //var conn = new SQLite.SQLiteConnection(path);
//            //return conn;

//            var dbName = "FriendsDb.db3";
//            var path = Path.Combine(System.Environment.
//              GetFolderPath(System.Environment.
//              SpecialFolder.Personal), dbName);
//            var conn = new SQLite.SQLiteConnection(path);
//            return conn;

//        }
//    }
//}


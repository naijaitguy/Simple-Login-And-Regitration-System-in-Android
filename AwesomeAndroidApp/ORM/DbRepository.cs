using SQLite;
using Android.Util;
using System.Collections.Generic;

namespace AwesomeAndroidApp.ORM
{
    class DbRepository
    {

        // cdeate path to db file 
         string Path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CreateTable() {

            try {

                //open databas connection 
                using (var Connection = new SQLiteConnection(System.IO.Path.Combine(Path, "Users.db")))

                {

                    Connection.CreateTable<Users>();
                    return true;

                }
  
            }


            catch(SQLiteException Ex) {

                Log.Info("SQLiteEx", Ex.Message);
                return false;
              
            }



        }


        public bool InsertRecord( Users Model)
        
{

            try
            {
                using (var Connection = new SQLiteConnection(System.IO.Path.Combine(Path, "Users.db")))

                {
                    Connection.Insert(Model);


                    return true;
                }


            }
            catch ( SQLiteException Ex) {
                Log.Info("", Ex.Message);
                return false;


            }


        }


        public bool UpdateRecord(Users Model) {

            try {
                using (var Connection = new SQLiteConnection(System.IO.Path.Combine(Path, "Users.db")))
                {
                    Connection.Query<Users>("Update Users set UserName= ?, Password= ? where Id = ?, Model.UserName,Model.Password");

                    return true;
                }

                
            }

            catch (SQLiteException Ex) { Log.Info("SQLiteEx" +
                "", Ex.Message); return false; }




        }


        public List<Users> GetAllUsers()
        {
            try {
                using (var Connection = new SQLiteConnection(System.IO.Path.Combine(Path, "Users.db")))
                {
                 return   Connection.Table<Users>().ToList();

                }


            }

            catch(SQLiteException Ex) { Log.Info("SQLiteEx", Ex.Message); return null; }


        }

        public Users GetUserById( int Id)
        {
            try {
                using (var Connection = new SQLiteConnection(System.IO.Path.Combine(Path, "Users.db")))
                {

                    return Connection.Table<Users>().FirstOrDefault(m =>m.Id == Id);
                }
           }

            catch (SQLiteException Ex) { Log.Info("SQLiteEx", Ex.Message); return null; }



        }

        public int Add_New_User(Users Model ) {
            try {
                using (var Connection = new SQLiteConnection(System.IO.Path.Combine(Path, "Users.db")))

                {
                    var data = Connection.Table<Users>();

                    var Result = data.Where(m => m.UserName.Equals(Model.UserName) || m.Email.Equals(Model.Email)).FirstOrDefault();

                    if (Result == null)
                    {
                        Connection.Insert(Model);
                        return 1;
                    }
                    else { return 2; }

                   
                }
                    }
            catch (SQLiteException EX) { Log.Info("SQLite", EX.Message); return 0; }



        }


        public bool Login_User(string User_Name, string Password)
        {
            try {

                using (var Connection = new SQLiteConnection(System.IO.Path.Combine(Path, "Users.db")))
                {
                    var Data = Connection.Table<Users>();

                    var Result = Data.Where(m => m.UserName == User_Name && m.Password == Password).FirstOrDefault();
                    if (Result != null) {

                        return true;
                    }
                    else { return false; }

                }
            }
            catch (SQLiteException Ex) { Log.Info( "SQLiteEx",Ex.Message); return false; }
        }
    }
}
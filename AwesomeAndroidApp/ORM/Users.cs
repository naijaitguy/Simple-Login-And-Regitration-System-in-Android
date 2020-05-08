using SQLite;
namespace AwesomeAndroidApp.ORM
{
    class Users
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public string Confirm_Password { get; set; }

        public string Email { get; set; }

        public string Phone_Number { get; set; }


    }
}
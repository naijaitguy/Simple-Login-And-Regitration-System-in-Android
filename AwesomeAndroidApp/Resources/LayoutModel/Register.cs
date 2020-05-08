
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using AwesomeAndroidApp.Resources.LayoutModel;
using AwesomeAndroidApp.ORM;
using SQLite;
using Android.App;
using Android.Text;

namespace AwesomeAndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class Register : AppCompatActivity
    {

        Users users = new Users();
        DbRepository db = new DbRepository();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);
            db.CreateTable();
            // Create your application here

            Button Register_Btn = FindViewById<Button>(Resource.Id.btnReg);
            var text = FindViewById<TextView>(Resource.Id.textLogin);
            text.Click += Text_Click;

            Register_Btn.Click += Register_Btn_ClickAsync;

        }

        private void Text_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private  void Register_Btn_ClickAsync(object sender, System.EventArgs e)
        {
            
            var Name = FindViewById<EditText>(Resource.Id.Name);
            var Email = FindViewById<EditText>(Resource.Id.Email);
            var Phone = FindViewById<EditText>(Resource.Id.Phone);
            var User_Name = FindViewById<EditText>(Resource.Id.UserName);
            var Password = FindViewById<EditText>(Resource.Id.Txt_Pass);
            var Confirm_Password = FindViewById<EditText>(Resource.Id.Txt_Password_Con);

            bool Validate_Email = Android.Util.Patterns.EmailAddress.Matcher(Email.Text).Matches();
            if ((string.IsNullOrWhiteSpace(Email.Text)) || (string.IsNullOrWhiteSpace(Phone.Text)) ||
                (string.IsNullOrWhiteSpace(Name.Text)) || (string.IsNullOrWhiteSpace(User_Name.Text)) ||
                (string.IsNullOrWhiteSpace(Password.Text)) || (string.IsNullOrWhiteSpace(Confirm_Password.Text)))
            {
                ///////////////////////////////
                Android.App.AlertDialog.Builder alertDiag = new Android.App.AlertDialog.Builder(this);
                alertDiag.SetTitle(Html.FromHtml("<font color='#FF0000'>All Fields are required  </font>"));
                alertDiag.SetNeutralButton("OK", (c, ev) =>   {   });
                alertDiag.Show();
                ///////////////////////////////////////
             


            }/////////check if the tow password match 
            else if (!string.Equals(Password.Text, Confirm_Password.Text)) {
                Android.App.AlertDialog.Builder alertDiag = new Android.App.AlertDialog.Builder(this);

                alertDiag.SetTitle(Html.FromHtml("<font color='#FF0000'>Pssword do Not Match </font>"));

                alertDiag.SetNeutralButton("OK", (c, ev) =>
                {
                });

                alertDiag.Show();
                Password.Text = string.Empty;
                Confirm_Password.Text = string.Empty;
            }
            else if ( Validate_Email  == false) {
                Android.App.AlertDialog.Builder alertDiag = new Android.App.AlertDialog.Builder(this);
                alertDiag.SetTitle(Html.FromHtml("<font color='#FF0000'>Invalid Email Address </font>"));
                alertDiag.SetNeutralButton("OK", (c, ev) =>
                {
                });

                alertDiag.Show();
                
                Email.SetSelectAllOnFocus(true);
            }
           
            
            ///do if all requiremwnt are met ---------------
            else {
                users.UserName = User_Name.Text;
                users.Name = Name.Text;
                users.Password = Password.Text;
                users.Phone_Number = Phone.Text;
                users.Email = Email.Text;
                users.Confirm_Password = Confirm_Password.Text;
                int Result = db.Add_New_User(users);

                switch (Result) {

                    case 1:
                        ///////////////////////////////
                        Android.App.AlertDialog.Builder alertDiag = new Android.App.AlertDialog.Builder(this);
                        alertDiag.SetTitle(Html.FromHtml("<font color='#32CD32'>Registration Successful  </font>"));
                        alertDiag.SetNeutralButton("OK", (c, ev) => { });
                        alertDiag.Show();
                        ///////////////////////////////////////

                        StartActivity(typeof(HomeActivity));

                        break;


                    case 2:
                        Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);

                        alert.SetTitle(Html.FromHtml("<font color='#FF0000'>Email/UserName Already Exist  </font>"));

                        alert.SetNeutralButton("OK", (c, ev) =>
                        {
                        });

                        alert.Show();
                        break;


                    case 0:
                        Toast.MakeText(this, "Could not Add users ", ToastLength.Long).Show();

                        break;


                }


            }

        }
    }
}
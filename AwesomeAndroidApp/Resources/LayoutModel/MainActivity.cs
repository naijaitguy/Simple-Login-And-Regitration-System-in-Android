using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using AwesomeAndroidApp.Resources.LayoutModel;
using AwesomeAndroidApp.ORM;
using SQLite;
using Android.Text;

namespace AwesomeAndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {

        Users users = new Users();
        DbRepository db = new DbRepository();
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            db.CreateTable();
            Button BtnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            Button Btn_Register = FindViewById<Button>(Resource.Id.btnRegister);

            Btn_Register.Click += Btn_Register_Click;
            BtnLogin.Click += BtnLogin_Click;

        }

        private void Btn_Register_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Register));
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {

            var Txt_UserName = FindViewById<TextView>(Resource.Id.Txt_UserName);
            var Txt_Password = FindViewById<TextView>(Resource.Id.Txt_Password);

            if ((string.IsNullOrWhiteSpace(Txt_Password.Text)) || (string.IsNullOrWhiteSpace(Txt_UserName.Text)))

            {

                Android.App.AlertDialog.Builder alertDiag = new Android.App.AlertDialog.Builder(this);

                alertDiag.SetTitle(Html.FromHtml("<font color='#FF0000'>All Fields are required  </font>"));

                alertDiag.SetNeutralButton("OK", (c, ev) =>
                {
                });

                alertDiag.Show();

            }
            else {

                var Result = db.Login_User(Txt_UserName.Text, Txt_Password.Text);

                if (Result == false)

                {
                    Android.App.AlertDialog.Builder alertDiag = new Android.App.AlertDialog.Builder(this);

                    alertDiag.SetTitle(Html.FromHtml("<font color='#FF0000'> Ivalid Login Detials  </font>"));

                    alertDiag.SetNeutralButton("OK", (c, ev) =>
                    {
                    });

                    alertDiag.Show();
                 
                }

                else { StartActivity(typeof(HomeActivity)); }
              }

           
        }
    }
}
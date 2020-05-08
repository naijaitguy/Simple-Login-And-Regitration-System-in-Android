using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using AwesomeAndroidApp.Resources.LayoutModel;
using AwesomeAndroidApp.ORM;
using SQLite;

namespace AwesomeAndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class Index : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Index);

            // Create your application here

            Button btnLogin = FindViewById<Button>(Resource.Id.btn2);
            Button btn_Register = FindViewById<Button>(Resource.Id.btn1);

            btnLogin.Click += BtnLogin_Click;
            btn_Register.Click += Btn_Register_Click;

        }

        private void Btn_Register_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Register));
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}
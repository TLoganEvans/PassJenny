using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace PassJenny
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Wire up

            // UI controls
            CheckBox uppercase = FindViewById<CheckBox>(Resource.Id.checkBoxUpper);
            CheckBox numbers = FindViewById<CheckBox>(Resource.Id.checkBoxNumbers);
            CheckBox specialchars = FindViewById<CheckBox>(Resource.Id.checkBoxSpecial);
            EditText passLength = FindViewById<EditText>(Resource.Id.passLength);
            Button generatePass = FindViewById<Button>(Resource.Id.generateButton);
            TextView generatedPassword = FindViewById<TextView>(Resource.Id.generatedPassword);
            Button copyButton = FindViewById<Button>(Resource.Id.copyButton);

            // Code to generate password
            generatePass.Click += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(passLength.Text))
                {
                    generatedPassword.Text = string.Empty;
                }
                else
                {
                    generatedPassword.Text = Core.PasswordGenerator.GeneratePassword(passLength.Text, uppercase.Checked, numbers.Checked, specialchars.Checked);
                }
            };

            copyButton.Click += (sender, e) =>
            {
                var clipboard = (ClipboardManager)GetSystemService(ClipboardService);
                var clip = ClipData.NewPlainText("label", generatedPassword.Text);

                clipboard.PrimaryClip = clip;
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
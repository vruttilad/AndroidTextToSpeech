using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AndroidTextToSpeech
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText edtTxt;
        Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            edtTxt = FindViewById<EditText>(Resource.Id.editText1);
            button = FindViewById<Button>(Resource.Id.button1);
            
            button.Click += Button_Click;
            
        }

        private  async void  Button_Click(object sender, EventArgs e)
        {
            string speak =edtTxt.Text;
            var locales = await TextToSpeech.GetLocalesAsync();

            var locale = locales.FirstOrDefault();

            var settings = new SpeechOptions()
            {
                Volume = .75f,
                Pitch = 1.0f,
                Locale= locale
            };
            await TextToSpeech.SpeakAsync(speak, settings);


        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
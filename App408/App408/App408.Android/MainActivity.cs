using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace App408.Droid
{
    [Activity(Label = "App408", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(2000);
                    ToggleFullscreen(true);
                    Thread.Sleep(2000);
                    ToggleFullscreen(false);
                }
            });
        }


        private void ToggleFullscreen(bool isFullscreen)
        {
            RunOnUiThread(() =>
            {
                if (isFullscreen)
                {
                    Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(
                        SystemUiFlags.Fullscreen
                        | SystemUiFlags.HideNavigation
                        | SystemUiFlags.Immersive
                        | SystemUiFlags.ImmersiveSticky
                        | SystemUiFlags.LowProfile
                        | SystemUiFlags.LayoutStable
                        | SystemUiFlags.LayoutHideNavigation
                        | SystemUiFlags.LayoutFullscreen
                    );
                }
                else
                {
                    Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(
                        SystemUiFlags.LayoutStable
                    );
                }
            });
        }

     
    }
}
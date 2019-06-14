using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App408
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        public Page1()
        {
            InitializeComponent();

            Task.Factory.StartNew(() => {
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
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => {

                if (isFullscreen)
                {
                    myStackLayout.TranslationY = 0;
                }
                else
                {
                    myStackLayout.TranslationY = -64;
                }

                NavigationPage.SetHasNavigationBar(this, !isFullscreen);

            });
        }
    }
}
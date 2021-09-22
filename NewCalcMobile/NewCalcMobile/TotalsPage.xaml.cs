using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace NewCalcMobile
{
    public partial class TotalsPage : ContentPage
    {
        #region Variables
        private static double CbrtTotalNEW { get; set; }
        private static int StandoffWithCover { get; set; }
        private static int StandoffWithoutCover { get; set; }
        private static int StandoffOverpressure { get; set; }
        private static int StandoffLightFrag { get; set; }
        private static int StandoffHeavyFrag { get; set; }
        #endregion

        public TotalsPage()
        {
            InitializeComponent();
        }

        public void SetTotals()
        {
            CbrtTotalNEW = Math.Sqrt(Math.Sqrt(App.TotalNEW));
            StandoffWithCover = ((int)(CbrtTotalNEW * 10) + 1);
            StandoffWithoutCover = ((int)(CbrtTotalNEW * 15) + 1);
            StandoffOverpressure = ((int)(CbrtTotalNEW * 20) + 1);
            StandoffLightFrag = ((int)(CbrtTotalNEW * 300) + 1);
            StandoffHeavyFrag = ((int)(CbrtTotalNEW * 500) + 1);
        }

        async void StartApp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(), true);
        }
    }
}
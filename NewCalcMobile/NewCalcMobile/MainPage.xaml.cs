using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewCalcMobile
{
    public partial class MainPage : ContentPage
    {
        #region Page Initialization
        public MainPage()
        {
            var ShowNEW = new Label { Text = $"Current NEW: {App.TotalNEW}" };
            var ShowNumElements = new Label { Text = $"Elements: #{App.numElements}" };
            BindingContext = this;
            InitializeComponent();
        }

        private async void ShowTotals(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TotalsPage(), true);
        }
        #endregion

        #region Set Global Variables
        void SetWeight(object sender, EventArgs e)
        {
            string senderWeight = ((Entry)sender).Text;
            App.Weight = double.Parse(senderWeight);
        }

        void SetQuantity(object sender, EventArgs e)
        {
            string senderQuantity = ((Entry)sender).Text;
            App.Quantity = double.Parse(senderQuantity);
        }

        void SetREF(object sender, EventArgs e)
        {
            string senderREF = ((Entry)sender).Text;
            App.REF = double.Parse(senderREF);
        }

        void SwitchSetIsGrain(object sender, ToggledEventArgs e)
        {
            bool senderIsGrain = e.Value;
            App.isGrain = senderIsGrain;
        }

        #endregion

        #region Functions
        static void ResetInputVariables()
        {
            App.Weight = 0;
            App.Quantity = 0;
            App.REF = 0;
            App.CurrentNEW = 0;
            App.isGrain = false;
        }

        static void ResetTotalVariables()
        {
            App.numElements = 0;
            App.TotalNEW = 0;
        }

        static void AddElement(object sender, EventArgs e)
        {
            App.TotalNEW += CalculateNEW();
            App.numElements++;
            ResetInputVariables();
        }

        static double CalculateNEW()
        {
            App.CurrentNEW = (App.Weight * App.Quantity * App.REF);
            if (App.isGrain == true)
                App.CurrentNEW /= 7000;
            return App.CurrentNEW;
        }


        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace App5_2018
{
    partial class pgMain
    {
        public pgMain()
        {
            InitialiseComponent();
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            string lcArtistName = Convert.ToString(lstArtists.SelectedItem);
            if (!string.IsNullOrEmpty(lcArtistName) &&
                await DisplayAlert("Deleting artist", "Are you sure?", "Yes", "No"))
            {
                lblMessage.Text = await ServiceClient.DeleteArtistAsync(lcArtistName) + '\n';
                lstArtists.ItemsSource = await ServiceClient.GetArtistNamesAsync();
            }
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pgArtist(null));
        }

        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pgArtist(lstArtists.SelectedItem.ToString()));
        }

        public async void UpdateDisplay() // #async
        {
            try
            {
                //lstArtists.DataSource = null;  // needed?
                lstArtists.ItemsSource = await ServiceClient.GetArtistNamesAsync();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.GetBaseException().Message;
            }
        }
        protected override void OnAppearing()
        {
            UpdateDisplay();
            base.OnAppearing();
        }
    }
}

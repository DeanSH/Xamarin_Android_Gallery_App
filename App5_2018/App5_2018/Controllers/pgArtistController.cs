using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App5_2018
{
    partial class pgArtist
    {
        private string _ArtistName;
        private clsArtist _Artist;
        private bool _navigatingForward;
        public pgArtist(string prArtistName)
        {
            InitialiseComponent();
            _ArtistName = prArtistName;
        }

        private void updateDisplay()
        {
            txtName.Text = _Artist.Name;
            txtName.IsEnabled = string.IsNullOrWhiteSpace(_Artist.Name);
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
            lstWorks.ItemsSource = _Artist.WorksList;
        }

        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            string lcChoiceString = await DisplayActionSheet("Select artwork type:", "Cancel", null, clsAllWork.Choices.Keys.ToArray<string>());
            if (clsAllWork.Choices.TryGetValue(lcChoiceString, out char lcChoiceChar))
            {
                clsAllWork lcWork = clsAllWork.NewWork(lcChoiceChar);
                lcWork.ArtistName = _Artist.Name;
                editWork(lcWork);
            }
        }
        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (lstWorks.SelectedItem != null &&
                await DisplayAlert("Deleting artwork", "Are you sure?", "Yes", "No"))
            {
                lblMessage.Text += await ServiceClient.DeleteArtworkAsync(
                lstWorks.SelectedItem as clsAllWork) + '\n';
                _Artist = await ServiceClient.GetArtistAsync(_Artist.Name);
                updateDisplay();
            }
        }
        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            saveArtist();
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    return base.OnBackButtonPressed();
        //}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            _navigatingForward = false;
            try
            {
                if (!string.IsNullOrWhiteSpace(_ArtistName))
                {
                    _Artist = await ServiceClient.GetArtistAsync(_ArtistName);
                    updateDisplay();
                }
                else // no parameter -> new artist!
                    _Artist = new clsArtist();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.GetBaseException().Message;
            }
        }
        protected override void OnDisappearing()
        {
            if (!_navigatingForward)
                saveArtist();
            base.OnDisappearing();
        }
        private async void saveArtist()
        {
            try
            {
                pushData();
                if (txtName.IsEnabled)
                {
                    lblMessage.Text +=
                        await ServiceClient.InsertArtistAsync(_Artist) + '\n';
                    txtName.IsEnabled = false;
                }
                else
                    lblMessage.Text +=
                        await ServiceClient.UpdateArtistAsync(_Artist) + '\n';
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.GetBaseException().Message;
            }

        }

        private void BtnEdit_Clicked(object sender, EventArgs e)
        {
            editWork(lstWorks.SelectedItem as clsAllWork);
        }
        private async void editWork(clsAllWork prWork)
        {
            if (prWork != null)
            {
                _navigatingForward = true;
                await Navigation.PushAsync(new pgWork(prWork));
            }
        }
    }
}

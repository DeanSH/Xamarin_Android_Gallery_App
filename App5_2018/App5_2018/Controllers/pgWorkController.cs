using System;
using System.Collections.Generic;
using System.Text;

namespace App5_2018
{
    partial class pgWork
    {
        public pgWork(clsAllWork prWork)
        {
            addWorkSpecificContent(prWork);
            initialiseComponent();
            updatePage(prWork);
        }
        private void pushData()
        {
            _Work.Name = txtName.Text;
            _Work.Date = DateTime.Parse(txtDate.Text);
            _Work.Value = decimal.Parse(txtValue.Text);
            _artWorkCtrl.PushData(_Work);
        }
        private async void BtnOK_Clicked(object sender, EventArgs e)
        {
            pushData();
            if (txtName.IsEnabled)
                await ServiceClient.InsertWorkAsync(_Work);
            else
                await ServiceClient.UpdateWorkAsync(_Work);
            await Navigation.PopAsync();
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void addWorkSpecificContent(clsAllWork prWork)
        {
            switch (char.ToUpper(prWork.WorkType))
            {
                case 'P':
                    _artWorkCtrl = new ctrPaintPhoto();
                    Title = "edit painting";
                    break;
                case 'H':
                    _artWorkCtrl = new ctrPaintPhoto();
                    Title = "edit photograph";
                    break;
                case 'S':
                    _artWorkCtrl = new ctrSculpture();
                    Title = "edit sculpture";
                    break;
            }
        }

        private void updatePage(clsAllWork prWork)
        {
            _Work = prWork;
            txtName.Text = _Work.Name.EmptyIfNull();
            txtDate.Text = _Work.Date.ToString("d");
            txtValue.Text = _Work.Value.ToString();
            txtName.IsEnabled = string.IsNullOrEmpty(_Work.Name);
            _artWorkCtrl.UpdateControl(prWork);
        }
    }
}

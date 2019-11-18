using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App5_2018
{

    public partial class pgWork : ContentPage
    {
        private clsAllWork _Work;

        private Label lblTitle = new Label();
        private Label lblName = new Label { Text = "Name:" };
        private Entry txtName = new Entry { Placeholder = "Enter Name", FontSize = 12, };
        private Label lblDate = new Label { Text = "Date" };
        private Entry txtDate = new Entry { Placeholder = "Enter Date", FontSize = 12 };
        private Label lblValue = new Label { Text = "Value" };
        private Entry txtValue = new Entry { Placeholder = "Enter $ Value", FontSize = 12 };
        private Button btnOK = new Button { Text = "OK" };
        private Button btnCancel = new Button { Text = "Cancel" };
        private Label lblMessage = new Label();

        private IWorkControl _artWorkCtrl;
        private void initialiseComponent()
        {
            Grid lcWorkDetailsGrid = clsPageUtil.createGrid(3, 2);

            lcWorkDetailsGrid.Children.Add(lblName, 0, 0);
            lcWorkDetailsGrid.Children.Add(txtName, 1, 0);
            lcWorkDetailsGrid.Children.Add(lblDate, 0, 1);
            lcWorkDetailsGrid.Children.Add(txtDate, 1, 1);
            lcWorkDetailsGrid.Children.Add(lblValue, 0, 2);
            lcWorkDetailsGrid.Children.Add(txtValue, 1, 2);

            Grid lcButtonGrid = clsPageUtil.createGrid(1, 2);
            lcButtonGrid.Children.Add(btnOK, 0, 0);
            lcButtonGrid.Children.Add(btnCancel, 1, 0);

            btnOK.Clicked += BtnOK_Clicked;
                btnCancel.Clicked += BtnCancel_Clicked;

            Content = new StackLayout
            {
                Children = {
                    lblTitle,
                    lcWorkDetailsGrid,
                    _artWorkCtrl.Grid(),
                    lcButtonGrid,
                    lblMessage
                }
            };
        }

  
    }
}
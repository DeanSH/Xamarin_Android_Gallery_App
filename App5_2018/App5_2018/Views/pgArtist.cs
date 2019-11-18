using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App5_2018
{
    public partial class pgArtist : ContentPage
    {
        private Label lblName = new Label { Text = "Name:" };
        private Entry txtName = new Entry { Placeholder = "Enter Name", FontSize = 12, };
        private Label lblSpeciality = new Label { Text = "Speciality" };
        private Entry txtSpeciality = new Entry { Placeholder = "Enter Speciality", FontSize = 12 };
        private Label lblPhone = new Label { Text = "Phone" };
        private Entry txtPhone = new Entry { Placeholder = "Enter Phone Nr", FontSize = 12 };
        private Label lblMessage = new Label();
        private ListView lstWorks = new ListView();

        private Button btnAdd = new Button { Text = "Add" };
        private Button btnEdit = new Button { Text = "Edit" };
        private Button btnDelete = new Button { Text = "Del" };
        private Button btnSave = new Button { Text = "Save" };
        private void InitialiseComponent()
        {
            Title = "edit artist";

            Grid lcArtistDetailsGrid = clsPageUtil.createGrid(3, 2);

            lcArtistDetailsGrid.Children.Add(lblName, 0, 0);
            lcArtistDetailsGrid.Children.Add(txtName, 1, 0);
            lcArtistDetailsGrid.Children.Add(lblSpeciality, 0, 1);
            lcArtistDetailsGrid.Children.Add(txtSpeciality, 1, 1);
            lcArtistDetailsGrid.Children.Add(lblPhone, 0, 2);
            lcArtistDetailsGrid.Children.Add(txtPhone, 1, 2);

            Grid lcButtonGrid = clsPageUtil.createGrid(1, 4);
            lcButtonGrid.Children.Add(btnAdd, 0, 0);
            lcButtonGrid.Children.Add(btnEdit, 1, 0);
            lcButtonGrid.Children.Add(btnDelete, 2, 0);
            lcButtonGrid.Children.Add(btnSave, 3, 0);

            btnSave.Clicked += BtnSave_Clicked;
            btnEdit.Clicked += BtnEdit_Clicked;
            btnAdd.Clicked += BtnAdd_Clicked;
            btnDelete.Clicked += BtnDelete_Clicked;

            Content = new StackLayout
            {
                Children = {
                    lcArtistDetailsGrid,
                    lstWorks,
                    lcButtonGrid,
                    lblMessage
                }
            };
        }

      
    }
}
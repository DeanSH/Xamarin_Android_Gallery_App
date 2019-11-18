using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App5_2018
{
    public partial class pgMain : ContentPage
    {
        private ListView lstArtists = new ListView();
        //{ ItemsSource = new List<string>() { "Red", "Green", "Blue", "Black", "White", "Orange" } };
        private Button btnAdd = new Button { Text = "Add" /*, WidthRequest = 1 / 4 */};
        private Button btnEdit = new Button { Text = "Edit"/*, WidthRequest = 1 / 4 */ };
        private Button btnDelete = new Button { Text = "Delete" /*, WidthRequest = 1 / 4 */};
        private Label lblMessage = new Label();

        private void InitialiseComponent()
        {
            Title = "my artists";
            btnEdit.Clicked += BtnEdit_Clicked;
            //lstArtists.ItemTapped += BtnEdit_Clicked; // bad if you want to select then delete
            btnAdd.Clicked += BtnAdd_Clicked;
            btnDelete.Clicked += BtnDelete_Clicked;

            //lstArtists.ItemTapped += LstArtists_ItemTapped;
            //lstArtists.ItemTemplate...
            //lstArtists.Style = new Style("MyTheme");

            Grid lcButtonGrid = clsPageUtil.createGrid(1, 3);
            lcButtonGrid.Children.Add(btnAdd, 0, 0);
            lcButtonGrid.Children.Add(btnEdit, 1, 0);
            lcButtonGrid.Children.Add(btnDelete, 2, 0);

            Content = new StackLayout
            {
                Children = {
                    //new Label { Text = "my artists" },
                    lstArtists,
                    lcButtonGrid,
                    lblMessage
                    }
            };
        }

        //private void LstArtists_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var viewCell = (ViewCell)sender;
        //    if (viewCell.View != null)
        //    {
        //        viewCell.View.BackgroundColor = Color.Gray;
        //    }
        //}
    }
}
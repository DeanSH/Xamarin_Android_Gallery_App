using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App5_2018
{
    internal class ctrPaintPhoto : IWorkControl
    {
        private Label lblWidth = new Label { Text = "Width:" };
        private Entry txtWidth = new Entry { Placeholder = "Enter Width", FontSize = 12, };
        private Label lblHeight = new Label { Text = "Height" };
        private Entry txtHeight = new Entry { Placeholder = "Enter Height", FontSize = 12 };
        private Label lblType = new Label { Text = "Type" };
        private Entry txtType = new Entry { Placeholder = "Enter Type", FontSize = 12 };

        public Grid Grid()
        {
            Grid lcWorkDetailsGrid = clsPageUtil.createGrid(3, 2);

            lcWorkDetailsGrid.Children.Add(lblWidth, 0, 0);
            lcWorkDetailsGrid.Children.Add(txtWidth, 1, 0);
            lcWorkDetailsGrid.Children.Add(lblHeight, 0, 1);
            lcWorkDetailsGrid.Children.Add(txtHeight, 1, 1);
            lcWorkDetailsGrid.Children.Add(lblType, 0, 2);
            lcWorkDetailsGrid.Children.Add(txtType, 1, 2);
            return lcWorkDetailsGrid;
        }

        public void PushData(clsAllWork prWork)
        {
            prWork.Width = float.Parse(txtWidth.Text);
            prWork.Height = float.Parse(txtHeight.Text);
            prWork.Type = txtType.Text;
        }

        public void UpdateControl(clsAllWork prWork)
        {
            txtWidth.Text = prWork.Width.ToString();
            txtHeight.Text = prWork.Height.ToString();
            txtType.Text = prWork.Type.EmptyIfNull();
        }

    }
}

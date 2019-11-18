using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App5_2018
{
    internal class ctrSculpture : IWorkControl

    {
        private Label lblWeight = new Label { Text = "Weight:" };
        private Entry txtWeight = new Entry { Placeholder = "Enter Weight", FontSize = 12, };
        private Label lblMaterial = new Label { Text = "Material" };
        private Entry txtMaterial = new Entry { Placeholder = "Enter Material", FontSize = 12 };


        public Grid Grid()
        {
            Grid lcWorkDetailsGrid = clsPageUtil.createGrid(3, 2);

            lcWorkDetailsGrid.Children.Add(lblWeight, 0, 0);
            lcWorkDetailsGrid.Children.Add(txtWeight, 1, 0);
            lcWorkDetailsGrid.Children.Add(lblMaterial, 0, 1);
            lcWorkDetailsGrid.Children.Add(txtMaterial, 1, 1);

            return lcWorkDetailsGrid;
        }

        public void PushData(clsAllWork prWork)
        {
            prWork.Weight = float.Parse(txtWeight.Text);
            prWork.Material = txtMaterial.Text;
        }

        public void UpdateControl(clsAllWork prWork)
        {
            txtWeight.Text = prWork.Weight.ToString();
            txtMaterial.Text = prWork.Material.EmptyIfNull();
        }

    }

}

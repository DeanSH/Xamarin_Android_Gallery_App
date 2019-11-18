using Xamarin.Forms;

namespace App5_2018
{
    internal static class clsPageUtil
    {
        internal static Grid createGrid(int prRowCount, int prColCount)
        {
            Grid lcGrid = new Grid();
            for (int i = 0; i < prRowCount; i++)
                lcGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            for (int i = 0; i < prColCount; i++)
                lcGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            return lcGrid;
        }
    }
}

using Xamarin.Forms;

namespace App5_2018
{
    interface IWorkControl
    {
        void PushData(clsAllWork prWork);
        void UpdateControl(clsAllWork prWork);
        Grid Grid();
    }
}

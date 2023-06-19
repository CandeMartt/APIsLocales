using Android.Widget;
using APIsLocales.Helpers;

namespace APIsLocales.PlatformImplementations;

public class Toaster : IToast
{
    public void MakeToast(string message)
    {
        Toast.MakeText(Platform.CurrentActivity, "You have Internet!", ToastLength.Long).Show();
    }
}

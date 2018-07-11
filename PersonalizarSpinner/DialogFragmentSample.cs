using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PersonalizarSpinner
{

     public class DialogFragmentSample : DialogFragment
    {
        public static DialogFragmentSample NewInstace(Bundle bundle)
        {
            var fragment = new DialogFragmentSample();
            fragment.Arguments = bundle;
            return fragment;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //return customview for the fragment
            View view = inflater.Inflate(Resource.Layout.spinner_dialog, container, false);
            Button button = view.FindViewById<Button>(Resource.Id.btnClearLL);
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //remove title area
            Dialog.SetCanceledOnTouchOutside(false); //dismiss window on touch outside

            button.Click += delegate {
                Dismiss();
                Toast.MakeText(Activity, "Dialog fragment dismissed!", ToastLength.Short).Show();
            };
            return view;
        }
    }
}
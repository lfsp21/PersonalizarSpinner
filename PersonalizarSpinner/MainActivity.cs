using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;


namespace PersonalizarSpinner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private Spinner Sp;
        private string[] spItems;
        private ArrayAdapter SpAdapter;
        private Button btnD;
        private TextView spTxt;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                // Create your application here
                SetContentView(Resource.Layout.activity_main);

                FindViews();

                //Obtiene el array de items del archivo strings
               spItems = Resources.GetStringArray(Resource.Array.spinner_items);

                //Adapter para el elemento seleccionado (el fondo) y para el elemento dropdown
               SpAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.spinner_items, Resource.Layout.spinner_selected_item);
               SpAdapter.SetDropDownViewResource(Resource.Layout.spinner_dropdown_item);
               Sp.Adapter = SpAdapter;

                EventHandler();


               

            }
            catch (Exception)
            {

                throw;
            }


        }

        void EventHandler()
        {
            btnD.Click += BtnD_Click;
            spTxt.Click += SpTxt_Click;
        }

        private void SpTxt_Click(object sender, EventArgs e)
        {
            CustomDialog();
        }

        private void BtnD_Click(object sender, EventArgs e)
        {
            ShowCustomAlertDialog();
      
        }

        void FindViews()
        {
            Sp = FindViewById<Spinner>(Resource.Id.custom_sp);
            btnD = FindViewById<Button>(Resource.Id.btnOpenDialog);
            spTxt = FindViewById<TextView>(Resource.Id.txtSpinner);
        }

        void ShowCustomAlertDialog()
        {
            //Inflate layout
            View view = LayoutInflater.Inflate(Resource.Layout.spinner_dialog, null);
            Android.App.AlertDialog builder = new Android.App.AlertDialog.Builder(this).Create();
            builder.SetView(view);
            builder.SetCanceledOnTouchOutside(false);
            Button button = view.FindViewById<Button>(Resource.Id.btnClearLL);
            button.Click += delegate {
                builder.Dismiss();
                Toast.MakeText(this, "Alert dialog dismissed!", ToastLength.Short).Show();
            };
            builder.Show();
        }

        void CustomDialog()
        {
            ContextThemeWrapper ctw = new ContextThemeWrapper(this, Resource.Style.Theme_Dialog_N);
            Android.App.AlertDialog.Builder ad = new Android.App.AlertDialog.Builder(ctw);

            //LayoutInflater inflater = this.LayoutInflater;
            //ad.SetView(inflater.Inflate(Resource.Layout.dialogWindow, null));
            ad.SetTitle("Previt");
            ad.SetSingleChoiceItems(spItems, -1, SingleChoiceAction);
            ad.SetPositiveButton("Cancelar", delegate { });
            Android.App.AlertDialog mDialog = ad.Create();
            mDialog.Show();
            //mDialog.Window.SetBackgroundDrawableResource(Resource.Color.colorPrimary);
        }

        private void SingleChoiceAction(object sender, DialogClickEventArgs e)
        {
            var d = (sender as Android.App.AlertDialog);
            spTxt.Text = spItems[e.Which];
      
            // Dismiss Dialog
            d.Dismiss();
        }
    }
}


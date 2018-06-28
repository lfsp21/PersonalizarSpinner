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
        private string[] SpItems;
        private ArrayAdapter SpAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                // Create your application here
                SetContentView(Resource.Layout.activity_main);

                FindViews();

                //Obtiene el array de items del archivo strings
                SpItems = Resources.GetStringArray(Resource.Array.spinner_items);

                //Adapter para el elemento seleccionado (el fondo) y para el elemento dropdown
                SpAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.spinner_items, Resource.Layout.spinner_selected_item);
                SpAdapter.SetDropDownViewResource(Resource.Layout.spinner_dropdown_item);
                Sp.Adapter = SpAdapter;
            }
            catch (Exception)
            {

                throw;
            }


        }

        void FindViews()
        {
            Sp = FindViewById<Spinner>(Resource.Id.custom_sp);

        }
    }
}


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
using DevoirSNCF_Ivan_Naluzhnyi.Modeles;

namespace DevoirSNCF_Ivan_Naluzhnyi.Adapters
{
    public class NewInscriptAdapter : ArrayAdapter<Inscription>
    {
        Activity context;
        List<Inscription> lesInscrs;

        public NewInscriptAdapter(Activity unContext, List<Inscription> desInscrs)
            : base(unContext, Resource.Layout.ItemNewInscription, desInscrs)
        {
            context = unContext;
            lesInscrs = desInscrs;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = context.LayoutInflater.Inflate(Resource.Layout.ItemNewInscription, null);
            view.FindViewById<TextView>(Resource.Id.textNewCode).Text = lesInscrs[position].numAgance.ToString();
            view.FindViewById<TextView>(Resource.Id.textNewNom).Text = lesInscrs[position].nomAg.ToString();

            Switch s = view.FindViewById<Switch>(Resource.Id.switch1);
            s.CheckedChange += delegate (object sender, CompoundButton.CheckedChangeEventArgs e)
            {
                if (s.Checked)
                {
                    view.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ffff4444"));
                }
                else
                {
                    view.SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
            };
            return view;
        }

    }
}
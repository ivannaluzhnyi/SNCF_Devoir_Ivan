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
    public class InscritAdapter : ArrayAdapter<Inscription>
    {
        Activity context;
        List<Inscription> lesInscs;

        public InscritAdapter(Activity unContext, List<Inscription> desInscs)
            : base(unContext, Resource.Layout.ItemInscrit, desInscs)
        {
            context = unContext;
            lesInscs = desInscs; 
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = context.LayoutInflater.Inflate(Resource.Layout.ItemInscrit, null);

            view.FindViewById<TextView>(Resource.Id.textCode).Text = lesInscs[position].numAgance.ToString();
            view.FindViewById<TextView>(Resource.Id.textNom).Text = lesInscs[position].nomAg.ToString();
            int t = Convert.ToInt32(lesInscs[position].presenceAg);
            if ( t == 1)
            {
                view.SetBackgroundColor(Android.Graphics.Color.ParseColor("#3381CC"));
            }
            else
            {
                view.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff99cc00"));
            }
            return view;
        }
    }
}
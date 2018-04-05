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
    public class ActiviteAdapter : ArrayAdapter<Activite>
    {
        Activity context;
        List<Activite> lesActivites;

        public ActiviteAdapter(Activity unContext, List<Activite> desActivites)
            : base(unContext, Resource.Layout.ItemActivite, desActivites)
        {
            context = unContext;
            lesActivites = desActivites;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = context.LayoutInflater.Inflate(Resource.Layout.ItemActivite, null);
  
            view.FindViewById<TextView>(Resource.Id.textLibelle).Text = lesActivites[position].nomAct.ToString();
            return view;
        }
    }
}
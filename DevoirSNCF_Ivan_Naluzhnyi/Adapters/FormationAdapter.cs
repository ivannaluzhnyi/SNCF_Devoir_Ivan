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
    class FormationAdapter : ArrayAdapter<Formation>
    {
        Activity context;
        List<Formation> lesFormations;

        public FormationAdapter(Activity unContext, List<Formation> desFormations)
            : base(unContext, Resource.Layout.ItemFormation, desFormations)
        {
            context = unContext;
            lesFormations = desFormations;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = context.LayoutInflater.Inflate(Resource.Layout.ItemFormation, null);
            view.FindViewById<TextView>(Resource.Id.textForma).Text = lesFormations[position].intituleForma.ToString();
            return view;
        }
    }
}
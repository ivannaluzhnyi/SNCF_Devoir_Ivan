using Android.App;
using Android.Widget;
using Android.OS;
using System.Net;
using System;
using DevoirSNCF_Ivan_Naluzhnyi.Modeles;
using System.Collections.Generic;
using Newtonsoft.Json;
using DevoirSNCF_Ivan_Naluzhnyi.Adapters;
using Android.Content;
using DevoirSNCF_Ivan_Naluzhnyi.Activitys;

namespace DevoirSNCF_Ivan_Naluzhnyi
{
    [Activity(Label = "DevoirSNCF_Ivan_Naluzhnyi", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ListView lstActivite;
        ListView lstFormation;
        List<Activite> lesActivites;
        List<Formation> lesFormations;
        ActiviteAdapter adapterACT;
        FormationAdapter adapterFRM;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            lstActivite = FindViewById<ListView>(Resource.Id.lstActivite);
            lstFormation = FindViewById<ListView>(Resource.Id.lstFormation);
            WebClient wc = new WebClient();
            Uri url = new Uri("http://" + GetString(Resource.String.ip) + "GetAllActivites.php");

            wc.DownloadStringAsync(url);
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
            lstActivite.ItemClick += LstActivite_ItemClick; 

            lstFormation.ItemClick += LstFormation_ItemClick;
        }

        private void LstFormation_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Formation f = lesFormations[e.Position];
            Intent intent = new Intent(this, typeof(InscritActivity));
            intent.PutExtra("formation", JsonConvert.SerializeObject(f));
            StartActivity(intent);
        }

        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            lesActivites = JsonConvert.DeserializeObject<List<Activite>>(e.Result);
            adapterACT = new ActiviteAdapter(this, lesActivites);
            lstActivite.Adapter = adapterACT;
        }


        private void LstActivite_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Activite a = lesActivites[e.Position];
            WebClient wc = new WebClient();
            Uri url = new Uri("http://" + GetString(Resource.String.ip) + "GetFormationsByIdActivite.php?idActivite=" + a.numAct);
            wc.DownloadStringAsync(url);
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted1;
        }

        private void Wc_DownloadStringCompleted1(object sender, DownloadStringCompletedEventArgs e)
        {
            lesFormations = JsonConvert.DeserializeObject<List<Formation>>(e.Result);
            adapterFRM = new FormationAdapter(this, lesFormations);
            lstFormation.Adapter = adapterFRM;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DevoirSNCF_Ivan_Naluzhnyi.Adapters;
using DevoirSNCF_Ivan_Naluzhnyi.Modeles;
using Newtonsoft.Json;

namespace DevoirSNCF_Ivan_Naluzhnyi.Activitys
{
    [Activity(Label = "Inscrit")]
    public class InscritActivity : Activity
    {
        Formation forma;
        Button btnListInsc;
        Button btnIncrirAg;
        ListView lstInscrit;
        List<Inscription> lesIncrits;
        InscritAdapter adapterInsc;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.InscritLayout);

            string fr = Intent.GetStringExtra("formation");
            forma = JsonConvert.DeserializeObject<Formation>(fr);

            btnListInsc = FindViewById<Button>(Resource.Id.btnListInsc);
            btnIncrirAg = FindViewById<Button>(Resource.Id.btnIncrirAg);
            lstInscrit = FindViewById<ListView>(Resource.Id.lstInscrit);

            btnListInsc.Click += BtnListInsc_Click;
            btnIncrirAg.Click += BtnIncrirAg_Click;
            // Create your application here
        }

        private void BtnIncrirAg_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(NewIncriptionActivity));
            intent.PutExtra("formation", JsonConvert.SerializeObject(forma));
            StartActivity(intent);
        }

        private void BtnListInsc_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            Uri url = new Uri("http://" + GetString(Resource.String.ip) + "GetAllInscriptions.php?idFormation="+forma.numForma);
            wc.DownloadStringAsync(url);
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
        }

        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            lesIncrits = JsonConvert.DeserializeObject<List<Inscription>>(e.Result);
            adapterInsc = new InscritAdapter(this, lesIncrits);
            lstInscrit.Adapter = adapterInsc;

        }
    }
}
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

    [Activity(Label = "NewIncriptionActivity")]
    public class NewIncriptionActivity : Activity
    {
        Formation forma;
        ListView lstNewInsc;
        List<Inscription> lesInscriptions;
        NewInscriptAdapter adapterInsc;
        Button btnValider;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewInscriptionLayout);

            lstNewInsc = FindViewById<ListView>(Resource.Id.lstNewInsc);
            btnValider = FindViewById<Button>(Resource.Id.btnValider);

            string fr = Intent.GetStringExtra("formation");
            forma = JsonConvert.DeserializeObject<Formation>(fr);

            WebClient wc = new WebClient();
            Uri url = new Uri("http://" + GetString(Resource.String.ip) + "GetAllInscriptionsNonInscrits.php?idFormation=" + forma.numForma);
            wc.DownloadStringAsync(url);
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;


            btnValider.Click += BtnValider_Click;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Insertion", ToastLength.Long).Show();
            // 
            //Switch s = FindViewById<Switch>(Resource.Id.switch1);
            
            //WebClient wc = new WebClient();
            //Uri url = new Uri("http://" + GetString(Resource.String.ip) + "InsertInscription.php?idFormation=" + forma.numForma + "&numAgent="+ );
            //wc.DownloadStringAsync(url);
            
        }

        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            lesInscriptions = JsonConvert.DeserializeObject<List<Inscription>>(e.Result);
            adapterInsc = new NewInscriptAdapter(this, lesInscriptions);
            lstNewInsc.Adapter = adapterInsc;
        }
    }
}
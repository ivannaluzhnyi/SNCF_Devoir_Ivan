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
using Newtonsoft.Json;

namespace DevoirSNCF_Ivan_Naluzhnyi.Modeles
{
    public class Inscription
    {
        [JsonProperty("code")]
        public string numAgance { get; set; }
        [JsonProperty("presence")]
        public string presenceAg { get; set; }
        [JsonProperty("nom")]
        public string nomAg { get; set; }
    }
}
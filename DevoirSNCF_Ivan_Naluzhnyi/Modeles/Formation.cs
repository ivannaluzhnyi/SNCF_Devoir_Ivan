﻿using System;
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
    public class Formation
    {
        [JsonProperty("code")]
        public string numForma { get; set; }
        [JsonProperty("intitule")]
        public string intituleForma { get; set; }
    }
}
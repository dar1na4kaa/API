﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamModule4
{
    public class JsonResponse
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}

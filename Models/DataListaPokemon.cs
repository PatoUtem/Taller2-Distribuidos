﻿namespace API_taller2.Models
{
    public class DataListaPokemon
    {


        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public Result[] results { get; set; }


        public class Result
        {
            public string name { get; set; }
            public string url { get; set; }
        }

    }
}

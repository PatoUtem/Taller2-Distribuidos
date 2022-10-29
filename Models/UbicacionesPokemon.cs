namespace API_taller2.Models
{
    public class UbicacionesPokemon
    {

        public Location_Area location_area { get; set; }
        public Version_Details[] version_details { get; set; }


        public class Location_Area
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Version_Details
        {
            public Encounter_Details[] encounter_details { get; set; }
            public int max_chance { get; set; }
            public Version version { get; set; }
        }

        public class Version
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Encounter_Details
        {
            public int chance { get; set; }
            public Condition_Values[] condition_values { get; set; }
            public int max_level { get; set; }
            public Method method { get; set; }
            public int min_level { get; set; }
        }

        public class Method
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Condition_Values
        {
            public string name { get; set; }
            public string url { get; set; }
        }

    }
}

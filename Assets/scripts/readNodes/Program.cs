using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;


namespace nodeA_reader
{
    //Set components of JSON
    public class nodeData
    {
        public _nodeData[] data { get; set; }
    }

    public class _nodeData
    {
        public string accuracy { get; set; }
        public string dist_km { get; set; }
        public string iff { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public rfData[] rf_function { get; set; }
        public string tag { get; set; }
        public string time { get; set; }
}

    public class rfData
    {
        public float ant_beam_az { get; set; }
        public float ant_beam_el { get; set; }
        public float ant_beam_width { get; set; }
        public string ant_type { get; set; }
        public float bw_hz { get; set; }
        public float fc_hz { get; set; }
        public float pwr_dbm { get; set; }
        public float range_km { get; set; }
        public float sector { get; set; }
        public string status { get; set; }
        public string tag { get; set; }
        public string type { get; set; }
    }

    public class _isa_id
    {
        public string isa_id { get; set; }
    }

    public class _ver
    {
        public string ver { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            getData();
        }


        //Loops through each JSON file and retrieves necessary information.
        //In this case this it is just lat long
        //Probably will use Update function at some point to keep up with the game
        //Need this for all Nodes
        static void getData()
        {
            for (int i = 1; i < 3; i++)
            {
                //Create root 
                string linkRoot = "NodeA_";
                int x = i;
                string intToString = x.ToString();
                string endRoot = "copyy.json";
                string root = linkRoot + intToString + endRoot;
                Console.WriteLine(root);

                //reads json
                string jsonText = File.ReadAllText(root);

                //reads data
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<nodeData>(jsonText);

                //saves lat lon data
                float lat = data.data[0].lat;
                float lon = data.data[0].lon;

                //prints data
                Console.WriteLine(lat);
                Console.WriteLine(lon);
                Console.WriteLine("HELLO");
            }
        }
    }
}

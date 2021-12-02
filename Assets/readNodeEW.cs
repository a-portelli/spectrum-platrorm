using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;


    //Set components of JSON
    public class nodeData4
    {
        public _nodeData[] data { get; set; }
    }

    public class _nodeData4
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

    public class rfData4
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

    public class _isa_id4
    {
        public string isa_id { get; set; }
    }

    public class _ver4
    {
        public string ver { get; set; }
    }

public class readNodeEW : MonoBehaviour
{
    //Declare variables
    GameObject myObject;

    //speed
    public float Speed = 10f;

    //counter
    public int counter = 0;

    //coords
    public float lat;
    public float lon;

    //origin coordinates
    public float originLat1;
    public float originLon1;

    public float originLat2;
    public float originLon2;

    //Temporary arrays
    int[] xArr = {8,6,-6};
    int[] yArr = {-8,6,-6};

    //lat and lon val arrays
    public float[] originLatArr = new float[713];
    public float[] originLonArr = new float[713];

    //lat and lon val arrays
    public float[] latArr = new float[713];
    public float[] lonArr = new float[713];

    //string file path for lat and lon values
    public string filePath = "Assets/lonVals.txt"; 

    //sets target for object path
    private Transform target;

    //declare public counter
    public int j = 0;


    //FUNCTIONS

    private void Awake() 
    {
        for(int b = 0; b < 2; b++)
        {
            //Create origin root 
            string oPath = "Assets/nodeEW/";
            string oLinkRoot = "EW_";
            int x = b;
            string oIntToString = x.ToString();
            string oEndRoot = ".json";
            string oRoot = oPath + oLinkRoot + oIntToString + oEndRoot;
            Debug.Log(oRoot);
            
            //reads json
            string originJsonText = File.ReadAllText(oRoot);

            //reads data]
            var originData = Newtonsoft.Json.JsonConvert.DeserializeObject<nodeData>(originJsonText);

            //saves lat lon data
            float originLat = originData.data[0].lat;
            float originLon = originData.data[0].lon;

            //convert to better coordinates 
            //every coordinate 43, -113 - too small for unity (for now)
            float originLatConvert = ((originLat - 43) * 500);
            float originLonConvert = ((originLon + 113) * 500);

            //come up with origin coordinates based off first JSON file location
            originLatArr[b] = originLatConvert;
            originLonArr[b] = originLonConvert;
        }

        //set first origin and first target coordinates 
        originLat1 = originLatArr[0];
        originLon1 = originLonArr[0];

        originLat2 = originLatArr[1];
        originLon2 = originLonArr[1];

        Debug.Log(originLat1);
        Debug.Log(originLon1);

        Debug.Log(originLat2);
        Debug.Log(originLon2);

    }


    // Start is called before the first frame update
    void Start()
    {
        // Position the cube at the origin.
        transform.position = new Vector3(originLat1, 0.0f, originLon1);

        // Create and position the cylinder. Reduce the size.
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        // Grab cylinder values and place on the target.
        target = cylinder.transform;
        target.transform.localScale = new Vector3(0.15f, 1.0f, 0.15f);
        target.transform.position = new Vector3(originLat2, 0.0f, originLon2);

        // Create and position the floor.
        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.transform.position = new Vector3(182f, -1.0f, -66f);
        floor.transform.localScale = new Vector3(4f,1f,4f);

        for (int i = 2; i < 713; i++)
            {
                //Create root 
                string path = "Assets/nodeEW/";
                string linkRoot = "EW_";
                int x = i;
                string intToString = x.ToString();
                string endRoot = ".json";
                string root = path + linkRoot + intToString + endRoot;
            
                //reads json
                string jsonText = File.ReadAllText(root);

                //reads data
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<nodeData>(jsonText);

                //saves lat lon data
                float lat = data.data[0].lat;
                float lon = data.data[0].lon;

                //convert to better coordinates 
                //every coordinate 43, -113 - too small for unity (for now)
                float latConvert = ((lat - 43) * 500);
                float lonConvert = ((lon + 113) * 500);

                latArr[i] = latConvert;
                lonArr[i] = lonConvert;
            }
    }

    // Update is called once per frame
    void Update()
    {
        //set counter


        // Move our position a step closer to the target.
        float step =  30f * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target.position) < 0.001f && j < 713) 
        {
            if(j == 0 || j==1){
                j++;
                //Debug.Log("DONT DO ANYTHING J PLEASE");
            }
            else{
                // Swap the position of the cylinder.
                target.position = new Vector3(latArr[j], 0.0f, lonArr[j]);
                // Debug.Log(j);
                // Debug.Log(latArr[j]);
                // Debug.Log(lonArr[j]);
                // Debug.Log("ZZZZ");
                j++;
            }
            if(j==712)
            {
                transform.position = new Vector3(originLat1,0f,originLon1);
                target.position = new Vector3(originLat2,0f,originLon2);
                j=0;
            }
        }

    //write lat long data to file
    using (var writer = new StreamWriter("Assets/lonVals.txt")){
        for(int zz = 0; zz < 713; zz++)
        {
            if(zz == 0)
            {
                //writer.WriteLine(originLat1);
                writer.WriteLine(originLon1);
            }
            else if(zz == 1)
            {
                //writer.WriteLine(originLat2);
                writer.WriteLine(originLon2);
            }
            else
            {
                writer.WriteLine(lonArr[zz].ToString());
            }
        }  
    }

    }
}

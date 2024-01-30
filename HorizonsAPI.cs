﻿namespace GUI
{
    using System.Net;
    using System.Text.RegularExpressions;

    internal partial class Program
    {
        public class HorizonsAPI
        {
            // Properties

            // URL for JPL Horizons API
            string url = "https://ssd.jpl.nasa.gov/api/horizons.api?";

            // Request parameters
            string command;
            string center = "CENTER='@sun'";
            string make_ephem = "MAKE_EPHEM='YES'";
            string table_type = "TABLE_TYPE='VECTORS'";
            // START TIME AND STOP TIME ARE CURRENTLY HARDCODED! THESE WILL NEED CHANGING IF YOU WANT UPDATED VALUES
            string start_time = "START_TIME='2024-01-22'";
            string stop_time = "STOP_TIME='2024-01-23'";
            string step_size = "STEP_SIZE='1 d'";
            string out_units = "OUT_UNITS='KM-S'";
            string ref_plane = "REF_PLANE='ECLIPTIC'";
            string ref_system = "REF_SYSTEM='J2000'";


            //client to access the API
            WebClient client = new WebClient();

            // Constructor 
            public HorizonsAPI()
            {

            }

            private string Query(string name)
            {
                Dictionary<string, string> HorizonsID = new Dictionary<string, string>()
            {
                {"Sun",     "10"  },
                {"Mercury", "199" },
                {"Venus",   "299" },
                {"Earth",   "399" },
                {"Mars",    "499" },
                {"Jupiter", "599" },
                {"Saturn",  "699" },
                {"Uranus",  "799" },
                {"Neptune", "899" },
                {"Pluto",   "999" }

             };

                string ID = HorizonsID[name];
                this.command = "COMMAND='" + ID + "'";

                string fullurl = url + "format=text&" + command + "&" + center + "&" + make_ephem + "&" + table_type + "&" + start_time + "&" + stop_time + "&" + step_size + "&" + out_units + "&" + ref_plane + "&" + ref_system;
                // For json format: string fullurl = url + "format=json&" + command + "&" + center + "&" + make_ephem + "&" + table_type + "&" + start_time + "&" + stop_time + "&" + step_size + "&" + out_units + "&" + ref_plane + "&" + ref_system;

                string response = client.DownloadString(fullurl);

                return response;
            }

            public Body ParseAPIResponse(string queryname)
            {
                string response = this.Query(queryname);


                string namepattern = @"Revised: \w+ \d+, \d+\s+\d*\s(\w+)";
                Match namematch = Regex.Match(response, namepattern);
                string name = Convert.ToString(namematch.Groups[1].Value);

                string idpattern = @"Revised: \w+ \d+, \d+\s+\d*\s\w+\s+(\d\d\d?)";
                Match idmatch = Regex.Match(response, idpattern);
                string id = Convert.ToString(idmatch.Groups[1].Value);

                string masspattern = @"Mass,?\s*x?\s*10.(\d+).+?=\s*~?(\d+\.?\d*)";
                Match massmatch = Regex.Match(response, masspattern);
                double mass = float.Parse(massmatch.Groups[2].Value) * Math.Pow(10, Convert.ToInt32(massmatch.Groups[1].Value));

                string radiuspattern = @"M?m?ean R?r?adius.+?=\s*(\d+\.?\d*?)";
                Match radiusmatch = Regex.Match(response, radiuspattern);
                double radius = Convert.ToDouble(radiusmatch.Groups[1].Value);

                string positionpattern = @"SOE\s*.*\n\s*?X =(-? ?\d+\.\d+E\+?-?\d+).*?Y =(-? ?\d+\.\d+E\+?-?\d+)";
                Match positionmatch = Regex.Match(response, positionpattern);
                double x = Convert.ToDouble(positionmatch.Groups[1].Value);
                double y = Convert.ToDouble(positionmatch.Groups[2].Value);
                Vector position = new Vector(x, y);

                string velocitypattern = @"SOE\s*.*\n.*\n\s*VX=(-? ?\d+\.\d+E\+?-?\d+).*?VY=(-? ?\d+\.\d+E\+?-?\d+)";
                Match velocitymatch = Regex.Match(response, velocitypattern);
                double vx = Convert.ToDouble(velocitymatch.Groups[1].Value);
                double vy = Convert.ToDouble(velocitymatch.Groups[2].Value);
                Vector velocity = new Vector(vx, vy);

                Body newbody = new Body(name, id, mass, radius, position, velocity);

                return newbody;
            }



        }
    }
}
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExploreNowWeb.Models
{
    public class Activity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool Public { get; set; }
        public string ActivityCategory { get; set; }
        public int Count { get; set; }
        public string GoogleMapsReader { get; set; }
        public static List<Activity> activities = new List<Activity>();

        public Activity()
        {

        }
        public Activity(string googlemapsreader)
        {
            GoogleMapsReader = googlemapsreader;
        }
        public Activity(int id, string name, string latitude, string longitude, string activitycategory)
        {
            ID = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            ActivityCategory = activitycategory;
        }
        public string GetActivities() //List<Activity> // Ej testad
        {
            //int id = 1;
            var markers = "";
            var newMarkers = "";
            try
            {
                SQL.conn.Open();
                SQL.query = "SELECT activity.id, activity.name, activity.latitude, activity.longitude, activity_category.name FROM activity INNER JOIN activity_category ON activity_category.id = activity.activity_category_id WHERE public = true ORDER BY activity.id";
                SQL.cmd = new Npgsql.NpgsqlCommand(SQL.query, SQL.conn);
                SQL.dr = SQL.cmd.ExecuteReader();
                if (SQL.dr.HasRows)
                {
                    while (SQL.dr.Read())
                    {
                        markers += "{";
                        string geolat = Convert.ToString(SQL.dr["latitude"]).Replace(",", ".");
                        string geolong = Convert.ToString(SQL.dr["longitude"]).Replace(",", ".");
                        markers += string.Format("'Id': {0},", SQL.dr.GetInt32(SQL.dr.GetOrdinal("id"))/*id++*/);
                        markers += string.Format("'PlaceName': '{0}',", SQL.dr["name"]);
                        markers += string.Format("'GeoLong': '{0}',", geolat/*SQL.dr["latitude"]*/);
                        markers += string.Format("'GeoLat': '{0}',", geolong/*SQL.dr["longitude"]*/);
                        markers += string.Format("'type': '{0}'", "Fiske"/*SQL.dr["activity_category.name"]*/);
                        markers += "},";
                        newMarkers = markers.Replace("'", "\"");
                        
                        //GoogleMapsReader = newMarkers;
                        //activities.Add(new Activity(newMarkers));

                        //activities.Add(new Activity(SQL.dr.GetInt32(SQL.dr.GetOrdinal("id")), SQL.dr["name"].ToString(), SQL.dr["latitude"].ToString(), SQL.dr["longitude"].ToString()/*, SQL.dr["activity_category_id"].ToString()*/));

                        //ID = SQL.dr.GetOrdinal("id");
                        //Name = SQL.dr["name"].ToString();
                        //Latitude = SQL.dr["latitude"].ToString();
                        //Longitude = SQL.dr["longitude"].ToString();
                        //Count = activities.Count();

                    }
                        //activities.Add(newMarkers);
                }
            }
            catch (NpgsqlException ex)
            {
                throw;
            }
            finally
            {
                SQL.conn.Close();
            }
            //newMarkers += "]";

            //string newMarkers = markers.Replace("'", "\"");

            return /*new Activity()*//*activities*/newMarkers;
        }

    }
}
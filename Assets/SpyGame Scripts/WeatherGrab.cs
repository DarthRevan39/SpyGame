/*
using UnityEngine;
using System.Collections;

public class WeatherGrab : MonoBehaviour {
    void Start()
    {
        string url = "http://example.com/script.php?var1=value2&amp;var2=value2";
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
    }
    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
*/

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Net;

namespace WReader
{
    public class WeatherGrab : MonoBehaviour
    {
        static void GetWeather()
        {

                Console.Write("Enter Zip Code: ");
                string zipCode = Console.ReadLine();
                string conditions = GetConditions(zipCode);
                Console.WriteLine(conditions);
                Debug.Log(conditions);

        }
        public static string GetConditions(string zipCode)
        {
            string URLString = "http://www.wunderground.com/weather-forecast/" + zipCode;
            int count = 0;
            try
            {
                WebClient client = new WebClient();
                using (var stream = client.OpenRead(URLString))
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine().Trim()) != null)
                    {
                        if (line.Length > 25)
                        {
                            string key = line.Substring(0, 25);
                            //Console.WriteLine(key);
                            if (key.Equals("<meta property=\"og:title\""))
                            {
                                line = line.Substring(34);
                                int pipeCount = 0;
                                int aposCount = 0;
                                int weatherIndex0 = 0;
                                int weatherIndex1 = 0;
                                for (int i = 0; i < line.Length; i++)
                                {
                                    char c = line.ToCharArray()[i];
                                    if (c == '\"')
                                    {
                                        aposCount++;
                                        if (aposCount == 2) weatherIndex1 = i;
                                    }
                                    if (c == '|')
                                    {
                                        pipeCount++;
                                        if (pipeCount == 2) weatherIndex0 = i + 1;
                                    }
                                }
                                line = line.Substring(weatherIndex0, weatherIndex1 - weatherIndex0);
                                line = line.Trim();
                                return line;
                            }

                        }
                        count++;
                    }
                    //Console.ReadKey();
                    return "NA";
                }
            }
            catch
            {
                return "NA";
            }
        }
    }
}



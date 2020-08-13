using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BestSellingBooksCRUD.Data
{
    public class GetBooksData
    {

        public static JObject GetBestSellerItems(int offset)
        {
            string baseUrl = DataConstants.Api.baseUrl + "&offset=" + offset;
            
            JObject results = null;

            
            try
            {
                // Using HTTP request to get datafrom url
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(baseUrl));
                // request type 'GET'
                WebReq.Method = "GET";

                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


                string jsonString;
                // Stream is used to read the data as a stream and convert into a JSON string
                using (Stream stream = WebResp.GetResponseStream())  
                {
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    jsonString = reader.ReadToEnd();
                }

                results =  JObject.Parse(jsonString);

                return results;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
                return results;
            }
        }
    }
}

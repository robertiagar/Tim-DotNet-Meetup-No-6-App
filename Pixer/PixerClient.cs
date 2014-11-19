using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pixer
{
    public class PixerClient
    {
        private const string consumerKey = "nGr9Xrl4hMz5njA64KeOFuJS7u85NwOHSMS8BCAv";
        private HttpClient client;
        public PixerClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.500px.com/v1/");
        }

        public async Task<IList<Photo>> GetPhotosAsync(int noOfImages)
        {
            var reqString = string.Format("photos?feature=fresh_today&sort=created_at&image_size=4&include_store=store_download&include_states=voted&consumer_key={0}&rpp={1}", consumerKey, noOfImages);
            var result = await client.GetStringAsync(reqString);
            dynamic json = JsonConvert.DeserializeObject(result);
            var photos = new List<Photo>();

            foreach (dynamic photo in json.photos)
            {
                if (photo.nsfw != true)
                {
                    var newPhoto = new Photo
                        {
                            Title = photo.name,
                            Url = photo.image_url,
                            Username = photo.user.username
                        };
                    photos.Add(newPhoto);
                }
            }

            return photos;
        }
    }
}

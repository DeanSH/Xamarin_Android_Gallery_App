using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App5_2018
{
    internal static class ServiceClient
    {
        internal async static Task<List<string>> GetArtistNamesAsync() // #async
        {
            using (HttpClient lcHttpClient = new HttpClient())
                // use "magic" IP to get to 127.0.0.1 of the dev machine from Android Emulator
                // see https://developer.android.com/studio/run/emulator-networking
                return JsonConvert.DeserializeObject<List<string>>(await lcHttpClient.GetStringAsync("http://10.0.2.2:60064/api/gallery/GetArtistNames/"));
        }

        internal async static Task<clsArtist> GetArtistAsync(string prArtistName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsArtist>(await lcHttpClient.GetStringAsync("http://10.0.2.2:60064/api/gallery/GetArtist?Name=" + prArtistName));
            //return Util.Json2Object<clsArtist>(await lcHttpClient.GetStringAsync("http://10.0.2.2:60064/api/gallery/GetArtist?Name=" + prArtistName));
        }
        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content = new StringContent(JsonConvert.SerializeObject(prItem), Encoding.UTF8, "application/json"))
            //            using (lcReqMessage.Content = new StringContent(Util.Object2Json(prItem), Encoding.UTF8, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal async static Task<string> InsertArtistAsync(clsArtist prArtist)
        {
            return await InsertOrUpdateAsync(prArtist, "http://10.0.2.2:60064/api/gallery/PostArtist", "POST");
        }

        internal async static Task<string> UpdateArtistAsync(clsArtist prArtist)
        {
            return await InsertOrUpdateAsync(prArtist, "http://10.0.2.2:60064/api/gallery/PutArtist", "PUT");
        }

        internal async static Task<string> InsertWorkAsync(clsAllWork prWork)
        {
            return await InsertOrUpdateAsync(prWork, "http://10.0.2.2:60064/api/gallery/PostArtWork", "POST");
        }

        internal async static Task<string> UpdateWorkAsync(clsAllWork prWork)
        {
            return await InsertOrUpdateAsync(prWork, "http://10.0.2.2:60064/api/gallery/PutArtWork", "PUT");
        }

        internal async static Task<string> DeleteArtistAsync(string prArtistName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync($"http://10.0.2.2:60064/api/gallery/DeleteArtist?Name={prArtistName}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal async static Task<string> DeleteArtworkAsync(clsAllWork prWork)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
                    ($"http://10.0.2.2:60064/api/gallery/DeleteArtWork?WorkName={prWork.Name}&ArtistName={prWork.ArtistName}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }
    }
}

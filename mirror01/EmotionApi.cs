using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;
using Windows.Web.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mirror01
{

    class EmotionApi
    {
        //ATTRIBUTS
        private int anger;
        private int contempt;
        private int disgust;
        private int fear;
        private int happiness;
        private int neutral;
        private int sadness;
        private int surprise;

        //CONSTRUCTOR
        public EmotionApi()
        {

        }

        //METHODS
        public async Task<int[]> CheckEmotions(string picturePath)
        {
            string charlotte = "Charlotte";
            string responseToRequest = await MakeRequest(charlotte);

            int[] emotions = new int [] {anger, contempt, disgust, fear, happiness, neutral, sadness, surprise };
            return emotions;
        }

        public async Task<string> MakeRequest(string filePath)
        {
            // Capture image from camera
            /*CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(500, 500);
            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);*/

            //StorageFile photo = await StorageFile.GetFileFromPathAsync("ms-appx:///Assets/portrait.jpeg");
            StorageFile photo = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/portrait.jpeg"));

            //string filename = "Logo.jpeg";
            //Windows.Storage.StorageFile sampleFile = await Windows.Storage.KnownFolders.SavedPictures.Path.;


            // Setup http content using stream of captured photo
            IRandomAccessStream stream = await photo.OpenAsync(FileAccessMode.Read);
            HttpStreamContent streamContent = new HttpStreamContent(stream);
            streamContent.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("application/octet-stream");

            // Setup http request using content
            Uri apiEndPoint = new Uri("https://api.projectoxford.ai/emotion/v1.0/recognize");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiEndPoint);
            request.Content = streamContent;

            // Do an asynchronous POST.           
            string apiKey = "1dd1f4e23a5743139399788aa30a7153";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            HttpResponseMessage response = await httpClient.SendRequestAsync(request).AsTask();

            // Read response
            string responseContent = await response.Content.ReadAsStringAsync();


            // Parse the Json code
            var myJsonString = "[{Id: 42}]";

            var items = JsonConvert.DeserializeObject<List<MyClass>>(myJsonString);

            string data = "Charlotte";


            // Display response
            return data;
        }
    }

    public class MyClass
    {
        public int Id { get; set; }
        //public string Name { get; set; }
    }
}

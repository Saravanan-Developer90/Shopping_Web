namespace Shopping_Web.Models
{
    public class ProductModel
    {
        public int PId { get; set; }

        public string PName { get; set; }

        public int PPrice { get; set; }

        public string PCategory { get; set; }

        public bool PIsInStock { get; set; }

        public List<ProductModel> postData = new List<ProductModel>();

        public List<ProductModel> GetProductDetails()
        {
            string url = "https://localhost:7052/api/products";
            HttpClient client = new HttpClient();

            //set the client to make a call in data format
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var call = client.GetAsync(url).Result;

            if (call.IsSuccessStatusCode)
            {
                var data = call.Content.ReadAsAsync<List<ProductModel>>();
                data.Wait();
                postData = data.Result;
            }
            else
            {
                throw new Exception("Could not load data please contact the admin");
            }


            return postData;
        }
    }
}

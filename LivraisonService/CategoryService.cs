using LivraisonModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LivraisonService
{
    public class CategoryService
    {
        private readonly HttpClient client;
        public CategoryService(string baseAddress)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
        }

        public async Task<IEnumerable<CategoryModel>> GetAsync()
        {
            string url = $"Categories";
            var response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return CategoryModel.DeserializeObject<IEnumerable<CategoryModel>>(data);
            }
            else
            {
                throw new Exception($"Error status code : {response.StatusCode} \n {data}");
            }
        }
    }
}

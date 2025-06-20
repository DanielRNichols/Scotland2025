﻿
using Scotland2025.Contracts.JsonDocuments;
using System.Net.Http.Json;

namespace DataUploader
{
    public class JsonDocumentPoster
    {
        public async Task PostJsonDocuments(string dataFolder)
        {
            string[] files = Directory.GetFiles(dataFolder, "*.json");
            foreach(string file in files)
            {
                string documentName = Path.GetFileNameWithoutExtension(file);
                string json = File.ReadAllText(file);
                await PostJsonDocument(documentName, json);
            }

        }

        private async Task PostJsonDocument(string documentName, string jsonValue)
        {
            var jsonDocumentPutRequest = new UpdateJsonDocument.Request(jsonValue);

            // local
            string url = $"https://localhost:7243/api/jsondocuments/{documentName}";

            // test
            //string url = $"https://localhost:7244/api/jsondocuments/{documentName}";
            //string url = $"http://scotland2025.api.test.nichols-br.net/api/jsondocuments/{documentName}";

            // prod
            //string url = $"http://scotland2025.api.nichols-br.net/api/jsondocuments/{documentName}";
            //string url = $"https://localhost:7245/api/jsondocuments/{documentName}";

            using var httpClient = new HttpClient();
            Console.WriteLine(url);
            var response = await httpClient.PutAsJsonAsync(url, jsonDocumentPutRequest);


            return;
        }
    }
}

﻿
using System.Net.Http.Json;

namespace DataUploader
{
    public class JsonDocumentUploader
    {
        public async Task UploadJsonDocuments(string dataFolder)
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
            var jsonDocumentPutRequest = new Scotland2025.Contracts.JsonDocuments.UpdateJsonDocument.Request(jsonValue);

            string url = $"https://localhost:7243/api/jsondocuments/{documentName}";
            //string url = $"http://danielrnichols-001-site5.ftempurl.com/api/jsondocuments/{documentName}";

            using var httpClient = new HttpClient();
            Console.WriteLine(url);
            var response = await httpClient.PutAsJsonAsync(url, jsonDocumentPutRequest);


            return;
        }
    }
}

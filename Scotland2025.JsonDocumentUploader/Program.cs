namespace DataUploader
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var uploader = new JsonDocumentUploader();
                await uploader.UploadJsonDocuments(@"C:\Users\danie\OneDrive\Documents\Scotland Trip\json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
using System.Net.Http;
//program 
namespace SitePing
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main()
        {
            bool runProgram = true;
            // run program while true 
            do
            {
                Console.WriteLine("Enter the website you wish to ping (Ex: http://www.Youtube.com)");
                string website = Console.ReadLine().Trim();
                // make sure user input is not empty
                while (string.IsNullOrEmpty(website))
                {
                    Console.WriteLine("Your input can not be empty\n");
                    website = Console.ReadLine().Trim();
                }
                await getWebsite(website);
            }
            while (runProgram); 
        }

        static async Task getWebsite(string name)
        {
            try
            {
                using HttpResponseMessage response = await client.GetAsync(name);
                Console.WriteLine($"Website: {name}");
                Console.WriteLine("Status: ONLINE");
                Console.WriteLine($"HTTP Code: {(int)response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Website: {name}");
                Console.WriteLine("Status: OFFLINE");
            }
        }
    }
}
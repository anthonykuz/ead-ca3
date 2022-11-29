using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace ca3_x00162229.Shared
{
    class AnimeTitle
    {
        // Query attributes
        public string? Name { get; set; }
        public string? Image { get; set; }
        private int FactNumber { get; set; }
        public List<string> Facts;

        // Inserted markup after retrieving data
        public string? Markup { get; set; }

        // Creates a TextInfo based on the "en-US" (for letter casing, removing underscores)
        public TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

        // Constructor
        public AnimeTitle()
        {
            Name = "";
            Image = "";
            FactNumber = 0;
            Facts = new List<string>();
        }

        // Methods

        public async Task GetAnime(string input)
        {
            // Base case
            if (input == null)
            {
                throw new ArgumentException("Error: input empty.");
            }

            // Base URL (based of the heroku hosted API)
            //string baseUrl = $"https://anime-facts-rest-api.herokuapp.com/api/v1/{FixInputString(input)}";

            // Mock API result
            string baseUrl = "https://anime-facts.azure-api.net/v1/get-facts";

            // Get response
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();

                            if (data != null)
                            {
                                // Parse  data into a object
                                var dataObj = JObject.Parse(data);

                                // Check if need to reset values
                                ResetTitle();

                                // Fix casing and remove underscores for output
                                input = OutputName(input);

                                // Add data to list and image src
                                AddData(input, dataObj);

                                // Insert markup
                                InsertHTML(Facts);
                            }
                            else
                            {
                                throw new ArgumentException("Error: No returned data.");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void InsertHTML(List<string> facts)
        {
            foreach (string item in facts)
            {
                Markup = Markup + item;
            }
            Console.WriteLine("💥💥💥: finished adding markup");
        }

        public string FixInputString(string inputName)
        {
            inputName = inputName.Replace(@" ", "_");
            return myTI.ToLower(inputName);
        }

        public string OutputName(string inputName)
        {
            inputName = inputName.Replace(@"_", " ");
            return myTI.ToTitleCase(inputName);
        }

        public void ResetTitle()
        {
            // Reset values
            if (Facts.Count > 0)
            {
                Name = "";
                Image = "";
                Markup = "";
                FactNumber = 0;
                Facts.Clear();
            }
        }

        public void AddData(string input, JObject dataObj)
        {
            // Add values to variables
            Name = input;                               // Name
            Image = $"{dataObj["anime_img"]}";          // Image
            foreach (var item in dataObj["data"]!)      // Facts
            {
                FactNumber += 1;
                Facts.Add($"<div class=\"fact-collapsed\"><h6>Fact: {FactNumber}</h6><p>{item["fact"]!.ToString()}</p></div>");
            }
        }
    }
}

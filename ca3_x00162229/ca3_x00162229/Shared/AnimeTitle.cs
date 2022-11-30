using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Xml.Linq;

namespace ca3_x00162229.Shared
{
    public class Rootobject
    {
        public List<AnimeTitle>? Shows { get; set; }
    }

    public class AnimeTitle
    {
        // JSON attributes
        public int AnimeID { get; set; }
        public string? Name { get; set; }
        public int FactNumber { get; set; }
        public string? Image { get; set; }
        public List<Fact>? Facts { get; set; }

        // Inserted markup after retrieving data
        public string? Markup { get; set; }

        // Creates a TextInfo based on the "en-US" (for letter casing, removing underscores)
        private readonly TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

        // Methods
        public override string ToString()
        {
            return $"Name: {Name}, Image: {Image} Fact Count: {Facts.Count}";
        }

        public void InsertHTML(List<string> facts)
        {
            foreach (string item in facts)
            {
                Markup += item;
            }
        }

        public string FixInputString(string inputName)
        {
            return myTI.ToLower(inputName.Replace(@" ", "_"));
        }

        public string OutputName(string inputName)
        {
            return myTI.ToTitleCase(inputName.Replace(@"_", " "));
        }

        
    }
}

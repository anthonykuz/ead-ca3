using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Text;
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
        public string? Image { get; set; }
        public List<Fact>? Facts { get; set; }

        // Inserted markup after retrieving data
        public string? Markup { get; set; }

        // Creates a TextInfo based on the "en-US" (for letter casing, removing underscores)
        private readonly TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

        // Output name
        public string? OutName { get; set; }

        // --------------------- Methods ---------------------

        // Adds facts markup for object
        public void InsertHTML()
        {
            if (Markup == null)
            {
                foreach (Fact item in Facts!)
                {
                    Markup += $"<div class=\"fact-collapsed\"><h6>Fact: {item.fact_id}</h6><p>{item.fact}</p></div>";
                }
            }
        }
        
        // Alters input string when querying root object list
        public string FixInputString(string inputName)
        {
            return myTI.ToLower(inputName.Replace(@" ", "_"));
        }

        // Alters input string for output
        public void OutputName(string inputName)
        {
            OutName = myTI.ToTitleCase(inputName.Replace(@"_", " "));
        }
    }
}

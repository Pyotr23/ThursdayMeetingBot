using System.IO;
using System.Linq;
using HtmlAgilityPack;
using NUnit.Framework;
using ThursdayMeetingBot.Libraries.Wikipedia.Utils;

namespace Tests.Unit.ThursdayMeetingBot.Libraries.Wikipedia.Utils
{
    public class HolidayParserTests
    {
        [Test]
        public void Parse_TheFirstOfAugustHtml_Correctparsing()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var htmlFilePath = Path.Combine(currentDirectory, @"HtmlDocuments\the-first-of-august.html");
            var html = File.ReadAllText(htmlFilePath);
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var parser = new HolidayParser(document);

            parser.Parse();

            var holidays = parser
                .AllHolidays
                .ToArray();
            
            Assert.AreEqual(10, holidays.Length);
            
            Assert.AreEqual("Барбадос, Бермуды, Гайана, Тринидад и Тобаго Ямайка — День эмансипации", 
                holidays.ElementAt(0).Text);
            Assert.AreEqual("Азербайджан — День азербайджанского алфавита и языка", 
                holidays.ElementAt(1).Text);
            Assert.AreEqual("Россия — День памяти жертв Первой мировой войны", 
                holidays.ElementAt(8).Text);
            Assert.AreEqual("Россия, Адыгея — День репатриантов", 
                holidays.ElementAt(9).Text);
        }
    }
}
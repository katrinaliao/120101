using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace _120101
{
    [TestClass]
    public class UnitTest1
    {
        [TestCase(106, "2", true)]
        [TestCase(106, "11", true)]
        [TestCase(106, "0", false)]
        [TestCase(106, "12", false)]
        [TestCase(106, "99", true)]
        [TestCase(107, "2a", true)]
        [TestCase(107, "2b", true)]
        [TestCase(107, "14", true)]
        [TestCase(107, "1", true)]
        [TestCase(107, "2", false)]
        [TestCase(107, "12", false)]
        [TestCase(107, "99", true)]
        [TestCase(107, "abc", false)]
        public void valid_list(int year, string content, bool expected)
        {
            var medical = new Medical(year, content);
            Assert.AreEqual(expected, medical.IsValid());
        }
    }

    public class Medical
    {
        public int Year;

        public string Content;

        public Medical(int year, string content)
        {
            Year = year;
            Content = content;
        }

        private List<string> Year106List = new List<string>
        {
            "1","2","3","4","5","6","7","8","9","10","11","99"
        };

        private List<string> Year107List = new List<string>
        {
            "1","3","4","5","6","7","8","9","10","11","13","14","99","2a","2b"
        };

        private bool Valid106()
        {
            var number = int.Parse(Content);
            return (number >= 1 && number <= 11) || number == 99;
        }

        private bool Valid107()
        {
            var number = int.Parse(Content);
            var numberlist = Enumerable.Range(1, 14).Except(new[] {2, 12});
            numberlist.Select(x => x.ToString()).Concat(new[] {"2a", "2b", "99"});

            return ((AcceptIn107(number)) && number!= 2 && number!= 12) || number == 99 || Content == "2a" || Content == "2b";
        }

        private static bool AcceptIn107(int number)
        {
            return number > 0 && number < 15;
        }

        public bool IsValid()
        {
            switch (Year)
            {
                case 106:
                    return Valid106();
                    //return Year106List.Contains(Content);
                case 107:
                    return Year107List.Contains(Content);
            }
            return false;
        }
    }
}

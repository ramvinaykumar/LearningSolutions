using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace DownloadPdf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            //int size = Convert.ToInt32(Console.ReadLine());

            //string[] arr = new string[size];

            //for (int i = 0; i < size; i++)
            //{

            //    string arrItem = Console.ReadLine();

            //    arr[i] = arrItem;

            //}

            //process(arr, size);

            // OOPS Question;
            //Senior senior = new Senior();
            //Student student = senior;
            //student.Study();


            // Array and Exceptions
            //int sample;
            //int[] array = new int[4];
            //try
            //{
            //    sample = 5;
            //    array[sample] = 22;
            //}
            //catch (FormatException e)
            //{
            //    Console.Write("X");
            //}
            //catch (IndexOutOfRangeException e)
            //{
            //    Console.Write("Y");
            //}
            //Console.Write("Z");

            // Static and Constructor
            //Sample s = new Sample();
            //s.Value();

            string htmlPath = Path.Combine("", "");

            DateTime localDt = DateTime.Today;
            DateTime utcTime = localDt.ToUniversalTime();
            TimeZoneInfo timeInfoSingapore = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
            DateTime estDt = TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeInfoSingapore);

            Console.WriteLine("Local Date Time ==>>" + localDt);
            Console.WriteLine("Utc Date Time ==>>" + utcTime);
            Console.WriteLine("Singapore Date Time ==>>" + estDt);

            Console.WriteLine("GetCurrentDateTimeOffSet ==>>" + GetCurrentDateTimeOffSet());

            //var yearMonth = DateTime.UtcNow.Month(11).ToString("yyyy-MM");
            //Console.WriteLine("yearMonth ==>>" + yearMonth);

            // Linq Sum

            var data = new List<PlatformDetail>()
            {
                new PlatformDetail()
                {
                    PlatformName = "1",
                    NetEarning = "200"
                },
                new PlatformDetail()
                {
                    PlatformName = "2",
                    NetEarning = "649"
                },
                new PlatformDetail()
                {
                    PlatformName = "3",
                    NetEarning = "800"
                },
                new PlatformDetail()
                {
                    PlatformName = "4",
                    NetEarning = "649"
                },
                new PlatformDetail()
                {
                    PlatformName = "5",
                    NetEarning = "800"
                }
            };

            var xx = data.Sum(x => Convert.ToInt16(x.NetEarning));

            Console.WriteLine("Sum of net earnings ==>>" + xx);


            //var myString = @"Row 1 => Patient Identification no              (if NRIC, key in as S1234567E)            
            //                (*Mandatory field) (Mandatory) , Total Refund Amt ($)            (*Mandatory field) (Non-numeric) , MED Refund Amt   ($)             (*Mandatory field) (Mandatory) , Hospital Registration Number (HRN)
            //                (*Mandatory field) (Mandatory) | Row 2 =>  , Hospital Registration Number (HRN)
            //                (*Mandatory field) (Mandatory) | Row 3 =>  , Hospital Registration Number (HRN)
            //                (*Mandatory field) (Mandatory) | Row 4 =>  , Hospital Registration Number (HRN)
            //                (*Mandatory field) (Mandatory) | Row 5 =>  , Hospital Registration Number (HRN)
            //                (*Mandatory field) (Mandatory)}";
            //if (myString.Contains("=>"))
            //    myString = myString.Remove(myString.IndexOf("=>"), 1);
            //Console.WriteLine("truncatedData ==>>" + myString);

            //if (!string.IsNullOrEmpty(requestDto.BirthMonthYear) && requestDto.BirthMonthYear.Contains(MonthYear_Spliter))
            //{
            //    var birthMonthYear = requestDto.BirthMonthYear.Split(MonthYear_Spliter);
            //    inputBirthYear = Convert.ToInt16(birthMonthYear[Index_0], CultureInfo.CurrentCulture);
            //    inputBirthMonth = Convert.ToInt16(birthMonthYear[Index_1], CultureInfo.CurrentCulture);
            //}

            string[] MF_DATEOFBIRTH_PATTERN_LIST = new[] { "0001-01-01", "0000-00-00", "00-00", "0000" };
            var mainframeDob = "1945-00-00";
            var mainframeDob1 = "1945-01-01";

            var drd = mainframeDob.Length == 10 && mainframeDob.Contains("-") && mainframeDob.IndexOf("00") > 0 ? mainframeDob.Substring(5,5) : mainframeDob;
            var drd1 = mainframeDob1.Length == 10 && mainframeDob1.Contains("-") && mainframeDob1.IndexOf("00") > 0 ? mainframeDob1.Substring(5, 5) : mainframeDob1;

            Console.WriteLine("One or more PATTERN begin with: {0}",
                Array.Exists(MF_DATEOFBIRTH_PATTERN_LIST, element => element.StartsWith(mainframeDob)));

            if (MF_DATEOFBIRTH_PATTERN_LIST.Contains(drd))
            {
                Console.WriteLine("MF_DATEOFBIRTH_PATTERN_LIST Contains ==>> " + drd);
            }

            if (MF_DATEOFBIRTH_PATTERN_LIST.Contains(drd1))
            {
                Console.WriteLine("MF_DATEOFBIRTH_PATTERN_LIST Contains ==>> " + drd1);
            }

            string[] StateDetails = { "Noida", "Naagpur",
                "Mumbhai", "Delhi", "Faridabad",
                "Rohtak", "Lukhnow", "Banglore" };

            Console.WriteLine("One or more states begin with 'N': {0}",
                Array.Exists(StateDetails, element => element.StartsWith("N")));

            Console.WriteLine("One or more states begin with 'B': {0}",
                Array.Exists(StateDetails, element => element.StartsWith("B")));

            Console.WriteLine("Is sameCity one of the State? {0}",
                Array.Exists(StateDetails, element => element == "Noida"));

            decimal number = 12345.4567m;
            string formatted = number.ToString("0.00"); ; // formatted will be "123.46"
            Console.WriteLine("formatted will be ==>> " + formatted);

            // C# code snippet to generate a random email address:
            string randomEmail = GenerateRandomEmail();
            Console.WriteLine("Random Email Address: " + randomEmail);

            Console.ReadLine();
        }

        // COMPLETE THIS FUNCTION

        static void process(string[] arr, int size)
        {
            var query = arr.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();
        }

        static string GenerateRandomEmail()
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder stringBuilder = new StringBuilder();

            // Generate random username
            for (int i = 0; i < 10; i++)
            {
                stringBuilder.Append(chars[random.Next(chars.Length)]);
            }
            stringBuilder.Append("@");

            // Generate random domain
            string[] domains = { "gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "example.com" };
            stringBuilder.Append(domains[random.Next(domains.Length)]);

            return stringBuilder.ToString();
        }

        static DateTimeOffset GetCurrentDateTimeOffSet()
        {
            
            DateTime dateTime = DateTime.SpecifyKind(DateTime.Now.AddHours(8.0), DateTimeKind.Unspecified);
            return new DateTimeOffset(dateTime, TimeSpan.FromHours(8.0));
        }
    }

    public class PlatformDetail
    {
        [JsonProperty("platformName")]
        public string PlatformName { get; set; } = string.Empty;

        [JsonProperty("netEarning")]
        public string NetEarning { get; set; } = string.Empty;
    }

    class Student
    {
        public Student()
        {
            Console.Write("1");
        }

        public void Study()
        {
            Console.Write("2");
        }
    }

    class Senior:Student
    {
        public Senior()
        {
            Console.Write("3");
        }

        public void Study()
        {
            Console.Write("4");
        }
    }

    public class Sample
    {
        public static int sampler;

        public Sample()
        {
            if(sampler == 0)
                sampler = 1;
        }

        static Sample()
        {
            if (sampler == 0)
                sampler = 2;
        }

        public void Value()
        {
            if (sampler == 1)
                sampler = 3;

            Console.WriteLine(sampler);
        }
    }
}

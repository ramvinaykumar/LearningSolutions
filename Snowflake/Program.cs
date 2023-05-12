using Snowflake.Data.Client;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Snowflake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Console.WriteLine("Enter a string:");
            //string input = Console.ReadLine();

            //var patt = new Regex(@"/^([0-9]{11})|([0-9]{2}-[0-9]{3}-[0-9]{6})$/");
            //var isValid = patt.Match("22-333-666666"); // true

            //eNUM _num;
            //string number = "four";
            //if (Enum.TryParse<eNUM>(number, out _num))
            //{
            //    //do some thing 
            //}
            //else
            //{
            //    Console.WriteLine("Not found" + number);
            //}

            //string[] str = { "000-0-000000", "000-000000-0", "000-00000-0", "000-000000-10" };
            //foreach (string s in str)
            //{
            //    Console.WriteLine(isValidGivenFormat(s) ? "true" : "false");
            //}

            //Console.WriteLine("Regex: " + isValid);

            //RemoveRepeatedCharacters("aabbcadbcaaddert");

            //ReverseString("Bholenath");

            var coded = ("ictk_}:7cgP[[");
            string inputStr = Encoding.UTF8.GetString(Convert.FromBase64String(coded));
            Console.WriteLine(inputStr);


            Console.ReadLine();
        }

        // method containing the regex
        public static bool isValidGivenFormat(string str)
        {
            // string strRegex = "^[0-9]{3}[-][0-9]{1}[-][0-9]{6} | [0-9]{3}[-][0-9]{6}[-][0-9]{1}$";
            //string strRegex = "[0-9]{3}[-][0-9]{6}[-][0-9]{1}|[0-9]{3}[-][0-9]{1}[-][0-9]{6}$";

            var strRegex = "[0-9]{12}(?[0-9]{3}[-][0-9]{1}[-][0-9]{6})?|[0-9]{102}(?[0-9]{3}[-][0-9]{6}[-][0-9]{1})?|[0-9]{11}(?[0-9]{3}[-][0-9]{5}[-][0-9]{1})?$";

            Regex re = new Regex(strRegex);
            if (re.IsMatch(str))
                return (true);
            else
                return (false);
        }

        public static bool isValidPanCardNo(string str)
        {
            string strRegex = @"[0-9]{3}[-][0-9]{1}[-][0-9]{6}$";
            string strRegex1 = @"[0-9]{3}[-][0-9]{6}[-][0-9]{1}$";

            Regex reg = new Regex(@"[0-9]{3}[-][0-9]{1}[-][0-9]{6} + [0-9]{3}[-][0-9]{6}[-][0-9]{1}$");

            Regex re = new Regex(strRegex); Regex re1 = new Regex(strRegex1);
            if (re.IsMatch(str) || re1.IsMatch(str))
                return (true);
            else
                return (false);
        }

        public static void SnowflakeConnector()
        {
            //string connectionString = "scheme=https;ACCOUNT=bea78282;HOST=bea78282.us-east-1.snowflakecomputing.com;port=443; ROLE=sysadmin;WAREHOUSE=compute_wh; USER=nitesh; PASSWORD=XXXXXXX;DB=employeemanagement;SCHEMA=EM";
            ////Scenario 1. Get the list of employee from Snowflake View which returns Json data  
            //using (var conn = new SnowflakeDbConnection())
            //{
            //    conn.ConnectionString = connectionString;
            //    conn.Open();
            //    var cmd = conn.CreateCommand();
            //    cmd.CommandText = "select * from employee_skill_json_view;";
            //    var reader = cmd.ExecuteReader();
            //    dynamic employeeList;
            //    while (reader.Read())
            //    {
            //        Console.WriteLine(reader.GetString(0));
            //        employeeList = reader.GetString(0);
            //    }
            //    conn.Close();
            //}
            ////Scenario 2. Call the stored procedure employee_insert_json to insert to json data.  
            //string inputJsonData = @"{""employee_name"":""San"",""employee_address"": ""Hyderabad""}";
            //using (var conn = new SnowflakeDbConnection())
            //{
            //    conn.ConnectionString = connectionString;
            //    conn.Open();
            //    var cmd = conn.CreateCommand();
            //    cmd.CommandText = "call employee_insert_json('" + inputJsonData + "'); ";
            //    var reader = cmd.ExecuteReader();
            //    dynamic resultData;
            //    while (reader.Read())
            //    {
            //        Console.WriteLine(reader.GetString(0));
            //        resultData = reader.GetString(0);
            //    }
            //    conn.Close();
            //}
        }

        public static void RemoveRepeatedCharacters(string input)
        {
            char[] charArray = input.ToCharArray();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (result.ToString().IndexOf(charArray[i]) == -1)
                {
                    result.Append(charArray[i]);
                }
            }

            Console.WriteLine("String without repeated characters: " + result.ToString());
        }

        public static void ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            int length = input.Length;
            char[] reversed = new char[length];

            for (int i = 0; i < length; i++)
            {
                reversed[i] = charArray[length - i - 1];
            }

            string output = new string(reversed);
            Console.WriteLine("Reversed string: " + output);
        }

    }

    public enum eNUM
    {
        one,Two,Three
    }
}

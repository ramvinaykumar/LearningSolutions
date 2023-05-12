using System;
using System.Collections.Generic;
using System.Linq;

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

using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;


namespace WinWire.Console.ConstructorInformationProgram
{
    public class ConstructorProgram
    {
       
    }

    public class Tailor
    {
        public float Length { get; set; }

        public int Duration { get; set; }

        public DateTime Date { get; set; }

        public Tailor(float Length, int Duration, DateTime date)
        {

        }

        public Tailor(float Length, DateTime date)
        {

        }

        public Tailor(DateTime date)
        {

        }
    }

    public class TailorValidator
    {
        public string ConstructorInformation()
        {
            Type type = typeof(Tailor);
            StringBuilder result = new StringBuilder("[");
            ConstructorInfo[] constructors = type.GetConstructors(); 

            for (int i = 0; i < constructors.Length; i++)
            {
                ParameterInfo[] parameters = constructors[i].GetParameters();
                result.Append("{");

                for (int j = 0; j < parameters.Length; j++)
                {
                    result.Append(parameters[j].ParameterType.Name);
                    if (j < parameters.Length - 1)
                    {
                        result.Append(", ");
                    }
                }

                result.Append("}");
                if (i < constructors.Length - 1)
                {
                    result.Append(", ");
                }
            }

            result.Append("]");
            return result.ToString();
        }

        public string DateInfo()
        {
            StringBuilder result = new StringBuilder();
            Type type = typeof(Tailor);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var property in properties)
            {
                result.Append($"{property.PropertyType.Name} {property.Name}--");
            }

            // Remove the last "--" if it exists
            if (result.Length > 2)
            {
                result.Length -= 2;
            }

            return result.ToString();
        }
    }
}

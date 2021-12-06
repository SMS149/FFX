using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Playing fizzbuzz...");
            for (int count = 1; count <= 100; count ++)
            {
                if (count % 3 == 0 && count % 5 == 0)
                    Debug.WriteLine("fizzbuzz");
                else if (count % 3 == 0)
                    Debug.WriteLine("fizz");
                else if (count % 5 == 0)
                    Debug.WriteLine("buzz");
                else
                    Debug.WriteLine(count);
            }
            Console.WriteLine("Now for some  Postcode parsing...");
            Console.WriteLine("Please enter a postcode, press ENTER to finish:");
            string postCode = Console.ReadLine();
            do
            {
                if (!string.IsNullOrEmpty(postCode))
                {
                    // Convert to upper at start to save multiple conversions later
                    postCode = postCode.ToUpper();
                    // Remove any whitespace
                    postCode = postCode.Replace(" ", String.Empty);
                    //Inward code is ALWAYS length 3
                    if (postCode.Length >= 3)
                    {
                        Debug.WriteLine("# POSTCODE: " + postCode);
                        //inward code is always length 3
                        var inwardCode = postCode.Substring(postCode.Length - 3, 3);
                        if (!char.IsDigit(inwardCode, 0))
                        {
                            Debug.WriteLine("Invalid Postcode");
                        }
                        else
                        {
                            // outward code is everything but the last 3 chars
                            var outwardCode = postCode.Substring(0, postCode.Length - 3);
                            // Take chars until we first encounter a number
                            var outwardLetter = new string(outwardCode.TakeWhile(c => !char.IsDigit(c)).ToArray());
                            // take remainder after first occurrence of a number
                            var outwardNumber = outwardCode.Substring(outwardLetter.Length,
                                outwardCode.Length - outwardLetter.Length);
                            //output results
                            Debug.WriteLine("\tOUTWARD CODE: " + outwardCode);
                            Debug.WriteLine("\t\tOUTWARD LETTER: " + outwardLetter);
                            Debug.WriteLine("\t\tOUTWARD NUMBER: " + outwardNumber);
                            Debug.WriteLine("\tINWARD CODE: " + inwardCode);
                            Debug.WriteLine("");
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Invalid Postcode");
                    }
                }
                else
                {
                    Debug.WriteLine("User ended execution");
                }
                postCode = Console.ReadLine();
            } while (!string.IsNullOrEmpty(postCode));
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace readinguser {
    class readinginput
    {
        static void Main(string[] args) {


           Console.WriteLine("Hi enter some text and once you want to end writing just type END ");
            string line;
            string multilineinput = "";
            while ((line = Console.ReadLine()) != "END") {
                multilineinput +=line+ Environment.NewLine;
            
            }
            Console.WriteLine("Your document contents");
           Console.WriteLine($"{multilineinput}");
        
        }

     }





}

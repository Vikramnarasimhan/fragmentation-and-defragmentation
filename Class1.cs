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

             Console.WriteLine("Input how many characters at a time to split and create. Enter from 1-10");
            int charlength = int.Parse(Console.ReadLine());
            Console.WriteLine($"Reading  {charlength}  characters at a time");
            List<string> chunks = new List<string>();
            for (int i = 0; i < multilineinput.Length; i += charlength)
            {
                int length = Math.Min(charlength, multilineinput.Length - i);
                string chunk = multilineinput.Substring(i, length);
              //  Console.WriteLine($"{chunk}");
                chunks.Add( chunk );
            }
            for (int i = 0; i < chunks.Count; i++) {
                string filename = $"chunk_{i+1}.txt";
                File.WriteAllText( filename, chunks[i] );
           //     Console.WriteLine($"CHUNKS{filename} stored successfully");
            }
            Console.WriteLine("ALL CHUNKS RESPECTIVE TEXT FILES CREATED SUCCESSFULLY");
            string[] chunkfiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "chunk_*.txt");
            Array.Sort(chunkfiles, (a, b) =>
            {
                int numA = int.Parse(Path.GetFileNameWithoutExtension(a).Split('_')[1]);
                int numB = int.Parse(Path.GetFileNameWithoutExtension(b).Split('_')[1]);
                return numA.CompareTo(numB);
            });

            string reconstructed = "";
            foreach(string file in chunkfiles)
            {
                
               string content= File.ReadAllText(file);
                reconstructed+= content;
            }
            Console.WriteLine("ok these are my contents:");
            Console.WriteLine(reconstructed);
            //List<string> chunks = new List<string>();

            //for (int i = 0; i < multilineinput.Length; i += charlength)
            //{
            //  int length = Math.Min(charlength, multilineinput.Length - i);
            //string chunk = multilineinput.Substring(i, length);
            //chunks.Add(chunk);
            //}
            //string reconstructed = string.Join("", chunks);
            //Console.WriteLine("Reconstructed text:");
            //Console.WriteLine(reconstructed);




            // Console.WriteLine("Your document contents");
            //Console.WriteLine($"{multilineinput}");


            // string filepath = "Userdocumentation.txt";
            // File.WriteAllText(filepath,multilineinput);
            // Console.WriteLine("enter number of characters you want per line from 1-5");
            // string characterextraction=Console.ReadLine();


        }

    }





}

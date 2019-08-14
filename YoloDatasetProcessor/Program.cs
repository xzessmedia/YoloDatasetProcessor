using System;
using System.Collections.Generic;
using System.IO;

namespace YoloDatasetProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yolo Dataset Processor © 2019 TK");
            Console.WriteLine("--------------------------------");

            Console.WriteLine("Please enter the base Path ( example: data/myfolder/ ):");
            var basepath = Console.ReadLine();

            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);

            List<string> Trainingfilenames = new List<string>();

            int count = 0;

            foreach (var item in files)
            {
                if (Path.GetExtension(item) == ".jpg" || Path.GetExtension(item) == ".JPG" || Path.GetExtension(item) == ".png")
                {
                    // Check if we have a tagfile for image
                    if (File.Exists(Path.Combine(Path.GetDirectoryName(item), Path.GetFileNameWithoutExtension(item) + ".txt")) == true)
                    {
                        Trainingfilenames.Add(Path.Combine(basepath, Path.GetFileName(item)));
                        Console.WriteLine("Adding: " + item);
                        count++;
                    } else
                    {
                        Console.WriteLine(Path.Combine(Path.GetDirectoryName(item), Path.GetFileNameWithoutExtension(item), ".txt") + " does not exist");
                    }
                }
            }
            File.WriteAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "train.txt"), Trainingfilenames);
            Console.WriteLine("Processing finished.. added " + count.ToString() + " files to dataset");
        }
    }
}

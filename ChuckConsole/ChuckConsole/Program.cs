﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace ChuckConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                AppSettingsReader asr = new AppSettingsReader();
                List<string> theFacts = null;
                using (StreamReader reader = new StreamReader(asr.GetValue("FactFile", typeof(String)).ToString()))
                {
                    theFacts = new List<string>();
                    string line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line != null && line != string.Empty)
                            theFacts.Add(line);
                    }
                }
                Console.WriteLine(theFacts[new Random().Next(0, theFacts.Count - 1)]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Uh-oh! " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\n\n\n\n\n\n\n\npress any key to go about your day :)");
                Console.ReadKey();
            }
        }
    }
}
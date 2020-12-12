﻿using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CP77Tools.Model;
using WolvenKit.CR2W;

namespace CP77Tools
{
    public static partial class ConsoleFunctions
    {

        public static int Cr2wTask(string path, bool all, bool chunks)
        {
            // initial checks
            var inputFileInfo = new FileInfo(path);
            if (!inputFileInfo.Exists)
                return 0;

            var f = File.ReadAllBytes(inputFileInfo.FullName);

            var cr2w = new CR2WFile();

            try
            {
                using var ms = new MemoryStream(f);
                using var br = new BinaryReader(ms);
                cr2w.ReadImportsAndBuffers(br);

                var obj = new Cr2wDumpObject();
                obj.Filename = inputFileInfo.FullName.ToString();

                if (all)
                {
                    obj.Stringdict = cr2w.StringDictionary;
                    obj.Imports = cr2w.Imports;
                    obj.Buffers = cr2w.Buffers;
                }

                if (chunks || all)
                {
                    obj.Chunks = cr2w.Chunks;
                    foreach (var chunk in cr2w.Chunks)
                    {
                        obj.ChunkData.Add(chunk.GetDumpObject(br));
                    }
                }

                //dump texture
                







                var joptions = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                var jsonstring = JsonSerializer.Serialize(obj, joptions);

                File.WriteAllText($"{inputFileInfo.FullName}.dump.json", jsonstring);
                Console.WriteLine($"Finished. Dump file written to {inputFileInfo.FullName}.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return 1;
        }
    }
}
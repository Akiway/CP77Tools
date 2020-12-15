﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.IoC;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.CommandLine.IO;
using System.CommandLine.Parsing;
using System.Globalization;
using System.IO;
using System.Reflection;
using CP77Tools.Model;
using CP77Tools.Services;
using CsvHelper;
using WolvenKit.Common.FNV1A;
using WolvenKit.Common.Services;
using WolvenKit.Common.Tools.DDS;

namespace CP77Tools
{
    class Program
    {
        [STAThread]
        public static async Task Main(string[] args)
        {
            ServiceLocator.Default.RegisterType<ILoggerService, LoggerService>();
            ServiceLocator.Default.RegisterType<IMainController, MainController>();

            // get csv data
            Console.WriteLine("Loading Hashes...");
            Loadhashes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/archivehashes.csv"));
            Console.WriteLine("Loaded Hashes.");

            #region commands

            







            var rootCommand = new RootCommand();

            var archive = new Command("archive", "Target an archive to extract files or dump information.")
            {
                new Option<string>(new []{"--path", "-p"}, "Input path to .archive."),
                new Option<string>(new []{ "--outpath", "-o"}, "Output directory to extract files to."),
                new Option<bool>(new []{ "--extract", "-e"}, "Extract files from archive."),
                new Option<bool>(new []{ "--dump", "-d"}, "Dump archive information."),
                new Option<bool>(new []{ "--list", "-l"}, "List contents of archive."),
                new Option<bool>(new []{ "--uncook", "-u"}, "Uncooks textures from archive."),
                new Option<EUncookExtension>(new []{ "--uext"}, "Uncook extension (tga, bmp, jpg, png, dds). Default is tga."),
                new Option<ulong>(new []{ "--hash"}, "Extract single file with given hash."),
            };
            rootCommand.Add(archive);
            archive.Handler = CommandHandler.Create<string, string, bool, bool, bool, bool, EUncookExtension, ulong>(ConsoleFunctions.ArchiveTask);

            var dump = new Command("dump", "Target an archive or a directory to dump archive information.")
            {
                new Option<string>(new []{"--path", "-p"}, "Input path to .archive or to a directory (runs over all archives in directory)."),
                new Option<bool>(new []{ "--imports", "-i"}, "Dump all imports (all filenames that are referenced by all files in the archive)."),
                new Option<bool>(new []{ "--missinghashes", "-m"}, "List all missing hashes of all input archives."),
                new Option<bool>(new []{ "--info"}, "Dump all xbm info."),
            };
            rootCommand.Add(dump);
            dump.Handler = CommandHandler.Create<string, bool, bool, bool>(ConsoleFunctions.DumpTask);

            var cr2w = new Command("cr2w", "Target a specific cr2w (extracted) file and dumps file information.")
            {
                new Option<string>(new []{"--path", "-p"}, "Input path to a cr2w file."),
                new Option<bool>(new []{ "--all", "-a"}, "Dump all information."),
                new Option<bool>(new []{ "--chunks", "-c"}, "Dump all class information of file."),
            };
            rootCommand.Add(cr2w);
            cr2w.Handler = CommandHandler.Create<string, bool, bool>(ConsoleFunctions.Cr2wTask);

            var hashTask = new Command("hash", "Some helper functions related to hashes.")
            {
                new Option<string>(new []{"--input", "-i"}, "Create FNV1A hash of given string"),
                new Option<bool>(new []{"--missing", "-m"}, ""),
            };
            rootCommand.Add(hashTask);
            hashTask.Handler = CommandHandler.Create<string, bool>(ConsoleFunctions.HashTask);

            var oodleTask = new Command("oodle", "Some helper functions related to oodle compression.")
            {
                new Option<string>(new []{"--path", "-p"}, ""),
                new Option<bool>(new []{"--decompress", "-d"}, ""),
            };
            rootCommand.Add(oodleTask);
            oodleTask.Handler = CommandHandler.Create<string, bool>(ConsoleFunctions.OodleTask);

            #endregion

            var logger = ServiceLocator.Default.ResolveType<ILoggerService>();

            // Run
            if (args == null || args.Length == 0)
            {
                // write welcome message
                rootCommand.InvokeAsync("-h").Wait();

                while (true)
                {
                    string line = System.Console.ReadLine();
                    var parsed = CommandLineExtensions.ParseText(line, ' ', '"');
                    rootCommand.InvokeAsync(parsed.ToArray()).Wait();

                    await WriteLog();
                }

            }
            else
            {
                rootCommand.InvokeAsync(args).Wait();

                await WriteLog();
            }


            async Task WriteLog()
            {
                if (string.IsNullOrEmpty(logger.ErrorLogStr))
                    return;

                var t = DateTime.Now.ToString("yyyyMMddHHmmss");
                var fi = new FileInfo(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    $"errorlogs/log_{t}.txt"));
                if (fi.Directory != null)
                {
                    Directory.CreateDirectory(fi.Directory.FullName);
                    var log = logger.ErrorLogStr;
                    await File.WriteAllTextAsync(fi.FullName, log);
                }
                else
                {
                    
                }
            }

        }


        private static void Loadhashes(string path)
        {
            var _maincontroller = ServiceLocator.Default.ResolveType<IMainController>();

            using (var fr = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var sr = new StreamReader(fr))
            using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                var records1 = csv.GetRecords<HashObject>();
                var Hashdict = _maincontroller.Hashdict;

                foreach (var record in records1)
                {
                    ulong hash = ulong.Parse(record.Hash);
                    if (!Hashdict.ContainsKey(hash))
                        Hashdict.Add(hash, record.String);
                }
            }
        }


        
    }
}

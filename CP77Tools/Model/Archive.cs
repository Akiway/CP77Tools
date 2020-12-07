﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Kaitai;

namespace CP77Tools.Model
{
    public class Archive
    {
        public ArHeader Header { get; set; }
        public List<byte[]> Files { get; set; }
        public ArTable Table { get; set; }

        public Archive(string path)
        {

            Files = new List<byte[]>();

            using (var br = new BinaryReader(new FileStream(path, FileMode.Open)))
            {
                Read(br);
            }
        }


        private void Read(BinaryReader br)
        {
            Header = new ArHeader(br);

            br.BaseStream.Seek((long)Header.Tableoffset, SeekOrigin.Begin);

            Table = new ArTable(br);

            // read files
            foreach (var entry in Table.FileInfo)
            {
                // get file offsets
                var startindex = (int)entry.startindex;
                var nextindex = (int)entry.nextindex;

                using var ms = new MemoryStream();
                using var bw = new BinaryWriter(ms);
                for (int i = startindex; i < nextindex; i++)
                {
                    var offsetentry = this.Table.Offsets[i];
                    br.BaseStream.Seek((long)offsetentry.Offset, SeekOrigin.Begin);
                    var buffer = br.ReadBytes((int)offsetentry.Zsize);
                    bw.Write(buffer);
                }

                Files.Add(ms.ToArray());
            }
        }
    }




    public partial class ArHeader
    {
        public byte[] Magic { get; set; }
        public uint Version { get; set; }
        public ulong Tableoffset { get; set; }
        public ulong Tablesize { get; set; }
        public ulong Unk3 { get; set; }
        public ulong Filesize { get; set; }

        public ArHeader(BinaryReader br)
        {
            Read(br);
        }

        private void Read(BinaryReader br)
        {
            Magic = br.ReadBytes(4);
            if (KaitaiStream.ByteArrayCompare(Magic, new byte[] { 82, 68, 65, 82 }) != 0)
            {
                throw new NotImplementedException();
            }
            Version = br.ReadUInt32();
            Tableoffset = br.ReadUInt64();
            Tablesize = br.ReadUInt64();
            Unk3 = br.ReadUInt64();
            Filesize = br.ReadUInt64();
        }
    }
    public partial class ArTable
    {
        

        public uint Num { get; private set; }
        public uint Size { get; private set; }
        public ulong Checksum { get; private set; }
        public uint Table1count { get; private set; }
        public uint Table2count { get; private set; }
        public uint Table3count { get; private set; }
        public List<FileInfoEntry> FileInfo { get; private set; }
        public Dictionary<int, OffsetEntry> Offsets { get; private set; }
        public Dictionary<int, HashEntry> HashTable { get; private set; }

        public ArTable(BinaryReader br)
        {
            Read(br);

            FileInfo = new List<FileInfoEntry>();
            Offsets = new Dictionary<int, OffsetEntry>();
            HashTable = new Dictionary<int, HashEntry>();

            // read tables
            for (int i = 0; i < Table1count; i++)
            {
                FileInfo.Add( new FileInfoEntry(br));
            }

            for (int i = 0; i < Table2count; i++)
            {
                Offsets.Add(i, new OffsetEntry(br));
            }

            for (int i = 0; i < Table3count; i++)
            {
                HashTable.Add(i, new HashEntry(br));
            }
        }

        private void Read(BinaryReader br)
        {
            Num = br.ReadUInt32();
            Size = br.ReadUInt32();
            Checksum = br.ReadUInt64();
            Table1count = br.ReadUInt32();
            Table2count = br.ReadUInt32();
            Table3count = br.ReadUInt32();
        }
    }

    public partial class HashEntry
    {
        public ulong Hash { get; set; }

        public HashEntry(BinaryReader br)
        {
            Read(br);
        }

        private void Read(BinaryReader br)
        {
            Hash = br.ReadUInt64();
        }
    }

    public partial class OffsetEntry
    {

        public ulong Offset { get; set; }
        public uint Zsize { get; set; }
        public uint Size { get; set; }

        public OffsetEntry(BinaryReader br)
        {
            Read(br);
        }

        private void Read(BinaryReader br)
        {
            Offset = br.ReadUInt64();
            Zsize = br.ReadUInt32();
            Size = br.ReadUInt32();
        }
    }

    public partial class FileInfoEntry
    {
        public byte[] Header { get; set; }
        public uint somebool { get; private set; }
        public uint startindex { get; private set; }
        public uint nextindex { get; private set; }
        public uint unk1 { get; private set; }
        public uint unk2 { get; private set; }

        public byte[] Footer { get; set; }

        public FileInfoEntry(BinaryReader br)
        {
            Read(br);
        }

        private void Read(BinaryReader br)
        {
            Header = br.ReadBytes(16);

            somebool = br.ReadUInt32();
            startindex = br.ReadUInt32();
            nextindex = br.ReadUInt32();
            unk1 = br.ReadUInt32();
            unk2 = br.ReadUInt32();

            Footer = br.ReadBytes(20);
        }
    }
}




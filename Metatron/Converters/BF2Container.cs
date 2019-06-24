using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.FileFormat;
using Yarhl.FileSystem;
using Yarhl.Media.Text;
using Yarhl.IO;

namespace Metatron
{
    public class BF2Container : IConverter<BinaryFormat, NodeContainerFormat>
    {
        public NodeContainerFormat Convert(BinaryFormat source)
        {
            NodeContainerFormat file = new NodeContainerFormat();
            var dr = new DataReader(source.Stream)
            {
                DefaultEncoding = new UTF8Encoding(),
                Endianness = EndiannessMode.LittleEndian,
            };

            dr.Stream.Position = 0x10;
            byte entryCount = dr.ReadByte();
            dr.Stream.Position = 0x20;
            for (int i = 0; i < entryCount; i++)
            {
                int entryID = dr.ReadInt32();
                int entryLength = dr.ReadInt32() * dr.ReadInt32();
                int entryPosition = dr.ReadInt32();
                if (i == entryCount - 1)
                    entryLength = (int)source.Stream.Length - entryPosition;
                file.Root.Add(new Node(Identify(entryID), new BinaryFormat(source.Stream, entryPosition, entryLength)));
            }
            return file;
        }

        public string Identify(int entryID)
        {
            switch (entryID)
            {
                case 0:
                    return "pre";
                case 1:
                    return "lbe";
                case 2:
                    return "idt";
                case 3:
                    return "bmd";
                case 4:
                    return "cam";
                default:
                    return "";
            }
        }
    }
}

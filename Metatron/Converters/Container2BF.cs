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
    class Container2BF : IConverter<NodeContainerFormat, BinaryFormat>
    {
        public BinaryFormat Convert(NodeContainerFormat source)
        {
            throw new NotImplementedException();
        }

        public static Node HeaderNode(string file)
        {
            var dr = new DataReader(new DataStream(file, FileOpenMode.Read))
            {
                DefaultEncoding = new UTF8Encoding(),
                Endianness = EndiannessMode.LittleEndian,
            };
            dr.Stream.Position = 0x10;
            byte entryCount = dr.ReadByte();
            return new Node("Header", new BinaryFormat(dr.Stream, 0, (entryCount * 0x10) + 0x20));            
        }
    }
}

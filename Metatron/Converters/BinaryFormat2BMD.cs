using Kagutsuchi.Formats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.FileFormat;
using Yarhl.IO;
using Yarhl.Media.Text;

namespace Kagutsuchi
{
    class BinaryFormat2PO : IConverter<BinaryFormat, BMD>
    {
        public BMD Convert(BinaryFormat src)
        {
            if (src == null)
                throw new ArgumentNullException(nameof(src));

            DataReader reader = new DataReader(src.Stream);
            BMD msg1 = new BMD
            {
                header = new BMD.Header {
                    chunkID = reader.ReadUInt32(),
                    fileSize = reader.ReadUInt32(),
                    magicID = reader.ReadUInt32(),
                    nullBlock = reader.ReadUInt32(),
                    lastBlockOffset = reader.ReadUInt32(),
                    lastBlockSize = reader.ReadUInt32(),
                    entryCount = reader.ReadUInt32(),
                    unknownConst = reader.ReadUInt32()
                },
                table = new List<BMD.Table>(),
                entries = new List<BMD.Entry>(),
            };
            return msg1;
        }

        public void FillTable(List<BMD.Table> tab)
        {
            
        }
    }
}

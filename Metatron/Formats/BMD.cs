using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarhl.FileFormat;

namespace Kagutsuchi.Formats
{
    class BMD
    {
        public Header header { get; set; }
        public List<Table> table { get; set; }
        public List<Entry> entries { get; set; }

        public class Header
        {
            public uint chunkID { get; set; }
            public uint fileSize { get; set; }
            public uint magicID { get; set; }
            public uint nullBlock { get; set; }
            public uint lastBlockOffset { get; set; }
            public uint lastBlockSize { get; set; }
            public uint entryCount { get; set; }
            public uint unknownConst { get; set; }
        }
        
        public class Table
        {
            public uint offset { get; set; }
        }

        public class Entry
        {
            public int ID { get; set; }
            public string nameID { get; set; }
            public string Text { get; set; }
        }        
    }
}

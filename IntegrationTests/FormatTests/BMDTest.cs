using NUnit.Framework;
using System.IO;
using Yarhl.FileSystem;
using Metatron;
using System;
using Yarhl.IO;

namespace Tests
{
    public class Tests
    {
        string resPath;
        [SetUp]
        public void Setup()
        {
            string programDir = AppDomain.CurrentDomain.BaseDirectory;
            resPath = Path.GetFullPath(programDir + "/../../../" + "TestResources/BMDTest/");
        }

        [Test]
        public void BF2BMDTest()
        {
            using (DataStream a = NodeFactory.FromFile(resPath + "e801.bf").TransformWith<BF2Container>().Children[3].Stream)
            {
                using (DataStream b = NodeFactory.FromFile(resPath + "e801.bmd").Stream)
                {
                    Assert.IsTrue(a.Compare(b));
                }
            }
        }

        [Test]
        public void UTest()
        {
            Assert.IsTrue(true);
        }
    }
}
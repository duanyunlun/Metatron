using NUnit.Framework;
using System.IO;
using Yarhl.FileSystem;
using Metatron;
using System;
using Yarhl.IO;
using Yarhl.FileFormat;

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
            DataReader a = new DataReader(NodeFactory.FromFile(resPath + "e801.bf").TransformWith<BF2Container>().Children[3].Stream);
            DataReader b = new DataReader(NodeFactory.FromFile(resPath + "e801.bmd").Stream);            
            Assert.AreEqual(a.ReadBytes((int)a.Stream.Length), b.ReadBytes((int)a.Stream.Length));
        }

        [Test]
        public void UTest()
        {
            Assert.IsTrue(true);
        }
    }
}
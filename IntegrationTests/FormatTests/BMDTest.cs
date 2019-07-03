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
            using (DataStream a = NodeFactory.FromFile(resPath + "e801.bf").TransformWith<BF2Container>().Children[3].Stream)
            {
                using (DataStream b = NodeFactory.FromFile(resPath + "e801.bmd").Stream)
                {
                    Assert.IsTrue(a.Compare(b));
                }
            }
        }

        [Test]
        public void BMD2BFTest()
        {
            using (Node a = NodeFactory.FromFile(resPath + "e801.bf").TransformWith<BF2Container>())
            {
                foreach (var child in a.Children)
                {
                    child.Stream.WriteTo(resPath + Path.GetFileNameWithoutExtension(a.Name) + "/" + a.Name + "." + child.Name);                    
                }

                foreach (var child in a.Children)
                {
                    if (File.Exists(resPath + Path.GetFileNameWithoutExtension(a.Name) + "/" + a.Name + "." + child.Name))
                    {
                        child.ChangeFormat(new BinaryFormat(new DataStream(resPath + Path.GetFileNameWithoutExtension(a.Name) + "/" + a.Name + "." + child.Name, FileOpenMode.Read)));
                    }
                }

                a.TransformWith<Container2BF>().Stream.WriteTo(resPath + a.Name + ".test"); //Container2BF necesario para seguir con el test
            }

            using (DataStream a = NodeFactory.FromFile(resPath + "e801.bf.test").Stream)
            {
                using (DataStream b = NodeFactory.FromFile(resPath + "e801.bf.test2").Stream)
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
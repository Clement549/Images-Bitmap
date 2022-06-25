using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QRCode_Esilv;

namespace Test_Unitaire
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            int input = 1;
            string myFile = "./Images/coco.bmp";

            MyImage image = new MyImage(myFile,input);

            byte[] b = image.INT2LE(1);

            Assert.AreEqual(1, b[0]);
        }
    }
}

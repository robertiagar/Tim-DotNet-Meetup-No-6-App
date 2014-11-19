using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Pixer.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            var pixer = new Pixer();

            var photos = await pixer.GetPhotosAsync();

            Assert.IsNotNull(photos);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPAC;
using System.Threading;

namespace GPAC.NET.Tests;

[TestClass]
public class Fraction64Tests
{
    [TestMethod]
    public void TestString() {
        Assert.AreEqual("1/10", new Fraction64(1L, 10ul).ToString());
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPAC;
using System.Threading;

namespace GPAC.NET.Tests;

[TestClass]
public class FractionTests
{
    [TestMethod]
    public void TestString() {
        Assert.AreEqual("1/10", new Fraction(1, 10).ToString());
    }
}
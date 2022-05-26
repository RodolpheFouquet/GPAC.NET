using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPAC;
using System.Threading;

namespace GPAC.NET.Tests;

[TestClass]
public class ErrorTests
{
    [TestMethod]
    public void TestSuccess() {
        Assert.AreEqual(true, Error.OK.Success());
        Assert.AreEqual(false, Error.BadParam.Success());
        Assert.AreEqual(true, Error.ScriptInfo.Success());
        Assert.AreEqual(false, Error.ScriptError.Success());
    }
}
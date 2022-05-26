using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPAC.NET;
using System.Threading;
using System.Runtime.InteropServices;
using System;

namespace GPAC.NET.Tests;


[TestClass]
public class GpacTests
{


    [TestInitialize()]
    public void Startup()
    {
    }

    [TestCleanup()]
    public void Cleanup()
    {
        Gpac.Close();
    }

    [TestMethod]
    public void TestInit()
    {
        Gpac.Init(MemoryTrackerType.None);
    }

    [TestMethod]
    public void TestError()
    {
        Assert.AreEqual("Bad Parameter", Error.BadParam.ToErrorString());
    }

    [TestMethod]
    public void TestHighResClock()
    {
        Gpac.Init(MemoryTrackerType.None);
        var now = Gpac.HighResClock();
        Assert.AreNotEqual(0, now);
        var then = Gpac.HighResClock();
        Assert.IsTrue(then > now);
    }

    [TestMethod]
    public void TestSysClock()
    {
        Gpac.Init(MemoryTrackerType.None);
        var now = Gpac.SysClock();
        Assert.AreNotEqual(0, now);
        Thread.Sleep(5);
        var then = Gpac.SysClock();
        Assert.IsTrue(then > now);
    }

    [TestMethod]
    public void TestLogLevels()
    {
        Gpac.Init(MemoryTrackerType.None);
        Gpac.SetLogLevel("all@info", false);
        Assert.AreEqual("all@info", Gpac.GetLogLevel());
    }

    [TestMethod]
    public void TestSetArgs()
    {
        Gpac.Init(MemoryTrackerType.None);
        Gpac.SetArgs(new string[] { "-blacklist=nvdec" });
    }

    [TestMethod]
    public void TestSleep()
    {
        Gpac.Init(MemoryTrackerType.None);
        var now = Gpac.SysClock();
        var sleep = 10ul;
        Gpac.Sleep(sleep);
        var then = Gpac.SysClock();
        Assert.IsTrue( then - now > sleep);
    }

}
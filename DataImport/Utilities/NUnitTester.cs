#if TESTDRIVER
using System;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Utilities
{
    using NUnit.Framework;

    [TestFixture]
    public class NUnitTester
    {
        #region UnitTests

        [Test]
        public void RunDebugLevelTests()
        {
            SystemDebug.Level = 3;

            Assert.IsTrue(SystemDebug.DebugOutput(2));
            Assert.IsTrue(SystemDebug.DebugOutput(3));
            Assert.IsFalse(SystemDebug.DebugOutput(4));
        }

        [Test]
        public void LogMessageNoLevelSet()
        {
            const string fileName = @".\Testing.out";
            var logger = new Logging(fileName);
            logger.StartLoging();
            string msg = String.Format("This is a test String");
            SystemDebug.Log((int)TraceLevel.Verbose, msg);
            logger.EndLoging();

            var fInfo = new FileInfo(fileName);
            Assert.AreEqual(0, fInfo.Length);
            File.Delete(fileName);
        }

        [Test]
        public void LogMessageLevelSet()
        {
            const string fileName = @".\Testing.out";
            var logger = new Logging(fileName);
            logger.StartLoging();
            string msg = String.Format("This is a test String");
            SystemDebug.Level = (int)TraceLevel.Verbose;
            SystemDebug.Log((int)TraceLevel.Verbose, msg);
            Thread.Sleep(1000);
            logger.EndLoging();

            var fInfo = new FileInfo(fileName);
            Assert.Greater(fInfo.Length, 0);
            File.Delete(fileName);
        }

        [Test]
        public void LogMessageLevelToHigh()
        {
            const string fileName = @".\Testing.out";
            var logger = new Logging(fileName);
            logger.StartLoging();
            string msg = String.Format("This is a test String");
            SystemDebug.Level = (int)TraceLevel.Warning;
            SystemDebug.Log((int)TraceLevel.Verbose, msg);
            logger.EndLoging();

            var fInfo = new FileInfo(fileName);
            Assert.AreEqual(0, fInfo.Length);
            File.Delete(fileName);
        }

        [Test]
        public void LogMessageWithDirectory()
        {
            const string fileName = @".\Testing\Testing.out";
            var logger = new Logging(fileName);
            logger.StartLoging();
            string msg = String.Format("This is a test String");
            SystemDebug.Level = (int)TraceLevel.Warning;
            SystemDebug.Log((int)TraceLevel.Verbose, msg);
            logger.EndLoging();

            var fInfo = new FileInfo(fileName);
            Assert.AreEqual(0, fInfo.Length);
            Directory.Delete(Path.GetDirectoryName(fileName), true);
        }

        #endregion

        #region PrivateMethods

        #endregion
    }
}
#endif
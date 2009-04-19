#if TESTDRIVER

using TesterBC;

namespace DataAccessModule
{
    using NUnit.Framework;

    [TestFixture]
    public class NUnitTester : TesterBaseClass
    {
        #region UnitTests

        [Test]
        public void SQLServerDBUserLogin()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString(UserName, UserPassword,
                                             Server, Database);
            connection.ReturnSQLDataReader("Create Table TestTable (Name char(10))", null);
            connection.ReturnSQLDataReader("Drop Table TestTable", null);
        }

        [Test]
        [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
        public void SQLServerBadDBUserLogin()
        {
            var connection = new SQLServerConnect();

            connection.SetupConnectionString("User1", "User1",
                                                    Server, Database);
            connection.ReturnSQLDataReader("Create Table TestTable (Name char(10))", null);
        }

        [Test]
        public void ParmObject()
        {
            var parmObj = new ParmObject("Int", 1);
            Assert.AreEqual("Int", parmObj.ParmName);
            Assert.AreEqual(1, parmObj.ParmObj);

            parmObj = new ParmObject("String", "Testing");
            Assert.AreEqual("String", parmObj.ParmName);
            Assert.AreEqual("Testing", parmObj.ParmObj);

            parmObj = new ParmObject("Decimal", 3.54M);
            Assert.AreEqual("Decimal", parmObj.ParmName);
            Assert.AreEqual(3.54M, parmObj.ParmObj);
        }

        [Test]
        public void ParmListWithObject()
        {
            var parmList = new ParmList();

            var parmObj = new ParmObject("Int", 1);
            parmList.Add(parmObj);
            parmObj = new ParmObject("String", "Testing");
            parmList.Add(parmObj);
            parmObj = new ParmObject("Decimal", 3.54M);
            parmList.Add(parmObj);

            var list = parmList.Items;
            Assert.AreEqual(list[0].ParmName, "Int");
            Assert.AreEqual(list[0].ParmObj, 1);

            Assert.AreEqual(list[1].ParmName, "String");
            Assert.AreEqual(list[1].ParmObj, "Testing");

            Assert.AreEqual(list[2].ParmName, "Decimal");
            Assert.AreEqual(list[2].ParmObj, 3.54M);
        }

        [Test]
        public void ParmListWithOutObject()
        {
            var parmList = new ParmList();

            parmList.Add("Int", 1);
            parmList.Add("String", "Testing");
            parmList.Add("Decimal", 3.54M);

            var list = parmList.Items;
            Assert.AreEqual(list[0].ParmName, "Int");
            Assert.AreEqual(list[0].ParmObj, 1);

            Assert.AreEqual(list[1].ParmName, "String");
            Assert.AreEqual(list[1].ParmObj, "Testing");

            Assert.AreEqual(list[2].ParmName, "Decimal");
            Assert.AreEqual(list[2].ParmObj, 3.54M);
        }

        #endregion
    }
}

#endif
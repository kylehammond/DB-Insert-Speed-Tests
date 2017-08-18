using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using FastMember;

namespace DBInsertSpeedTests
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initialize / assumptions
            var test1Stopwatch = new Stopwatch();
            var test2Stopwatch = new Stopwatch();
            var test3Stopwatch = new Stopwatch();

            const int batches = 200;
            const int batchSize = 1000;

            var testData = new InsertTestType1() { Id = 1, IntProp = 2, StringProp1 = "test 2", StringProp2 = "test 2" };
            var testData2 = new InsertTestType2() { Id = 1, IntProp = 2, StringProp1 = "test 2", StringProp2 = "test 2" };
            var testData3 = new InsertTestType3() { Id = 1, IntProp = 2, StringProp1 = "test 2", StringProp2 = "test 2" };

            var testList1 = new List<InsertTestType1>();
            var testList2 = new List<InsertTestType2>();
            var testList3 = new List<InsertTestType3>();

            var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InsertTestContext"].ConnectionString);

            for (var j = 0; j < batchSize; j++)
            {
                testList1.Add(testData);
                testList2.Add(testData2);
                testList3.Add(testData3);
            }

            #endregion

            #region Test 1 - current method

            test1Stopwatch.Start();
            sqlConnection.Open();

            for (var i = 0; i < batches; i++)
            {
                var sqlSerializer = new SqlSerializer<InsertTestType1>();
                var query = sqlSerializer.SerializeInsert(testList1);
                var command = new SqlCommand(query) { Connection = sqlConnection };
                command.ExecuteNonQuery();
            }

            sqlConnection.Close();
            test1Stopwatch.Stop();

            #endregion


            #region Test 2 - FastMember
            test2Stopwatch.Start();

            sqlConnection.Open();
            for (var i = 0; i < batches; i++)
            {
                var typeOfList = typeof(InsertTestType2);

                using (var bcp = new SqlBulkCopy(sqlConnection))
                using (var reader = ObjectReader.Create(testList2))
                {
                    bcp.DestinationTableName = typeOfList.Name;
                    bcp.WriteToServer(reader);
                }
            }
            sqlConnection.Close();
            test2Stopwatch.Stop();
            
            #endregion


            #region Test 3 - 

            test3Stopwatch.Start();
            test3Stopwatch.Stop();

            #endregion


            Console.WriteLine("Speed of serialize: " + test1Stopwatch.Elapsed);
            Console.WriteLine("Speed of fast-member: " + test2Stopwatch.Elapsed);
            Console.WriteLine("Speed of ?: " + test3Stopwatch.Elapsed);
            Console.Read();
        }

    }
}

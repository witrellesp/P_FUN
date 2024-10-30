using Microsoft.VisualStudio.TestTools.UnitTesting;
using P_fun_application;
using System;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class CryptocurrencyTests
    {
        [TestMethod]
        public void LoadData_ValidFileData_DataLoadedCorrectly()
        {
            // Arrange
            var crypto = new Cryptocurrency(System.Drawing.Color.Red);
            string testFilePath = "testData.csv";
            File.WriteAllText(testFilePath, "Date,Price\n2024-01-01,30000\n2024-01-02,31000\n"); 

            // Act
            crypto.LoadData(testFilePath);

            // Assert
            Assert.AreEqual(2, crypto.Dates.Count);
            Assert.AreEqual(new DateTime(2024, 1, 1), crypto.Dates[0]);
            Assert.AreEqual(30000, crypto.Prices[0]);
            Assert.AreEqual(new DateTime(2024, 1, 2), crypto.Dates[1]);
            Assert.AreEqual(31000, crypto.Prices[1]);

          
        }
    }
}

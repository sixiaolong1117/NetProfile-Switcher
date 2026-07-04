using System;
using System.IO;
using Microsoft.Data.Sqlite;
using Xunit;
using NetworkSelector.Datas;
using NetworkSelector.Models;

namespace NetworkSelector.Tests
{
    public class SQLiteHelperTests : IDisposable
    {
        private readonly string _dbPath;

        public SQLiteHelperTests()
        {
            _dbPath = Path.Combine(Path.GetTempPath(), $"nstest_{Guid.NewGuid():N}.db");
        }

        public void Dispose()
        {
            SqliteConnection.ClearAllPools();
            try { if (File.Exists(_dbPath)) File.Delete(_dbPath); } catch { }
        }

        private SQLiteHelper CreateHelper()
        {
            return new SQLiteHelper($"Data Source={_dbPath}");
        }

        [Fact]
        public void Constructor_CreatesTable()
        {
            var helper = CreateHelper();
            var result = helper.QueryData();
            Assert.Empty(result);
        }

        [Fact]
        public void Insert_ThenQuery_ReturnsInsertedData()
        {
            var helper = CreateHelper();
            var model = new NSModel
            {
                Name = "Test Config",
                Netinterface = "以太网",
                IPAddr = "192.168.1.100",
                Mask = "255.255.255.0",
                Gateway = "192.168.1.1",
                DNS1 = "8.8.8.8",
                DNS2 = "8.8.4.4"
            };

            helper.InsertData(model);
            var result = helper.QueryData();

            Assert.Single(result);
            Assert.Equal("Test Config", result[0].Name);
            Assert.Equal("以太网", result[0].Netinterface);
            Assert.Equal("192.168.1.100", result[0].IPAddr);
            Assert.Equal("255.255.255.0", result[0].Mask);
            Assert.Equal("192.168.1.1", result[0].Gateway);
            Assert.Equal("8.8.8.8", result[0].DNS1);
            Assert.Equal("8.8.4.4", result[0].DNS2);
        }

        [Fact]
        public void Insert_ThenUpdate_ThenQuery_ReturnsUpdatedData()
        {
            var helper = CreateHelper();
            var model = new NSModel
            {
                Name = "Original",
                Netinterface = "Wi-Fi",
                IPAddr = "10.0.0.5",
                Mask = "255.0.0.0",
                Gateway = "10.0.0.1",
                DNS1 = "1.1.1.1",
                DNS2 = null
            };

            helper.InsertData(model);
            var inserted = helper.QueryData()[0];

            inserted.Name = "Updated";
            inserted.IPAddr = "10.0.0.50";
            inserted.DNS2 = "1.0.0.1";
            helper.UpdateData(inserted);

            var result = helper.QueryData();
            Assert.Single(result);
            Assert.Equal("Updated", result[0].Name);
            Assert.Equal("10.0.0.50", result[0].IPAddr);
            Assert.Equal("1.0.0.1", result[0].DNS2);
        }

        [Fact]
        public void Insert_ThenDelete_ThenQuery_ReturnsEmpty()
        {
            var helper = CreateHelper();
            var model = new NSModel
            {
                Name = "To Delete",
                Netinterface = "Wi-Fi",
                IPAddr = "172.16.0.1",
                Mask = "255.255.0.0",
                Gateway = "172.16.0.254",
                DNS1 = "8.8.8.8",
                DNS2 = null
            };

            helper.InsertData(model);
            var inserted = helper.QueryData()[0];

            helper.DeleteData(inserted);
            var result = helper.QueryData();

            Assert.Empty(result);
        }

        [Fact]
        public void QueryEmptyTable_ReturnsEmptyList()
        {
            var helper = CreateHelper();
            var result = helper.QueryData();
            Assert.Empty(result);
        }

        [Fact]
        public void InsertMultiple_ThenQuery_ReturnsAll()
        {
            var helper = CreateHelper();
            helper.InsertData(new NSModel { Name = "Config 1", Netinterface = "Wi-Fi" });
            helper.InsertData(new NSModel { Name = "Config 2", Netinterface = "以太网" });

            var result = helper.QueryData();
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void InsertWithNullFields_DoesNotThrow()
        {
            var helper = CreateHelper();
            var model = new NSModel
            {
                Name = "Minimal",
                Netinterface = null,
                IPAddr = null,
                Mask = null,
                Gateway = null,
                DNS1 = null,
                DNS2 = null
            };

            helper.InsertData(model);
            var result = helper.QueryData();

            Assert.Single(result);
            Assert.Null(result[0].Netinterface);
            Assert.Null(result[0].IPAddr);
            Assert.Null(result[0].DNS1);
        }

        [Fact]
        public void InsertWithSpecialCharacters_Succeeds()
        {
            var helper = CreateHelper();
            var model = new NSModel
            {
                Name = "Config with ' quotes and \" double",
                Netinterface = "Wi-Fi 6 (测试)",
                IPAddr = "192.168.1.1",
                Mask = "255.255.255.0",
                Gateway = "192.168.1.254",
                DNS1 = null,
                DNS2 = null
            };

            helper.InsertData(model);
            var result = helper.QueryData();

            Assert.Single(result);
            Assert.Equal("Config with ' quotes and \" double", result[0].Name);
            Assert.Equal("Wi-Fi 6 (测试)", result[0].Netinterface);
        }

        [Fact]
        public void DropTable_ClearsData_NewHelperCreatesTable()
        {
            var helper = CreateHelper();
            helper.InsertData(new NSModel { Name = "Test", Netinterface = "eth0" });
            helper.DropTable();

            var newHelper = CreateHelper();
            var result = newHelper.QueryData();
            Assert.Empty(result);
        }
    }
}

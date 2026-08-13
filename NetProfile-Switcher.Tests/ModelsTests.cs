using Xunit;
using Newtonsoft.Json;
using NetProfileSwitcher.Models;

namespace NetProfileSwitcher.Tests
{
    public class ModelsTests
    {
        [Fact]
        public void NSModel_Properties_Roundtrip()
        {
            var model = new NSModel
            {
                Id = 42,
                Name = "办公网络",
                Netinterface = "以太网",
                IPAddr = "10.0.0.100",
                Mask = "255.255.255.0",
                Gateway = "10.0.0.1",
                DNS1 = "8.8.8.8",
                DNS2 = "8.8.4.4"
            };

            Assert.Equal(42, model.Id);
            Assert.Equal("办公网络", model.Name);
            Assert.Equal("以太网", model.Netinterface);
            Assert.Equal("10.0.0.100", model.IPAddr);
            Assert.Equal("255.255.255.0", model.Mask);
            Assert.Equal("10.0.0.1", model.Gateway);
            Assert.Equal("8.8.8.8", model.DNS1);
            Assert.Equal("8.8.4.4", model.DNS2);
        }

        [Fact]
        public void NSModel_Defaults_AreNull()
        {
            var model = new NSModel();
            Assert.Equal(0, model.Id);
            Assert.Null(model.Name);
            Assert.Null(model.Netinterface);
            Assert.Null(model.IPAddr);
            Assert.Null(model.Mask);
            Assert.Null(model.Gateway);
            Assert.Null(model.DNS1);
            Assert.Null(model.DNS2);
        }

        [Fact]
        public void NSModel_SerializesAndDeserializes()
        {
            var original = new NSModel
            {
                Id = 1,
                Name = "Home",
                Netinterface = "Wi-Fi",
                IPAddr = "192.168.1.10",
                Mask = "255.255.255.0",
                Gateway = "192.168.1.1",
                DNS1 = "8.8.8.8",
                DNS2 = null
            };

            var json = JsonConvert.SerializeObject(original);
            var deserialized = JsonConvert.DeserializeObject<NSModel>(json);

            Assert.NotNull(deserialized);
            Assert.Equal(original.Id, deserialized.Id);
            Assert.Equal(original.Name, deserialized.Name);
            Assert.Equal(original.Netinterface, deserialized.Netinterface);
            Assert.Equal(original.IPAddr, deserialized.IPAddr);
            Assert.Equal(original.Mask, deserialized.Mask);
            Assert.Equal(original.Gateway, deserialized.Gateway);
            Assert.Equal(original.DNS1, deserialized.DNS1);
            Assert.Equal(original.DNS2, deserialized.DNS2);
        }

        [Fact]
        public void InterfaceInfoModel_Properties_Roundtrip()
        {
            var model = new InterfaceInfoModel
            {
                Name = "以太网",
                Description = "Realtek PCIe GbE",
                MACAddress = "00-11-22-33-44-55",
                IPAddress = "192.168.1.100",
                GatewayAddress = "192.168.1.1",
                DNS = "8.8.8.8",
                Type = "Ethernet",
                Speed = "1 Gbps"
            };

            Assert.Equal("以太网", model.Name);
            Assert.Equal("Realtek PCIe GbE", model.Description);
            Assert.Equal("00-11-22-33-44-55", model.MACAddress);
            Assert.Equal("192.168.1.100", model.IPAddress);
            Assert.Equal("192.168.1.1", model.GatewayAddress);
            Assert.Equal("8.8.8.8", model.DNS);
            Assert.Equal("Ethernet", model.Type);
            Assert.Equal("1 Gbps", model.Speed);
        }

        [Fact]
        public void DHCPInterfaceModel_Properties_Roundtrip()
        {
            var model = new DHCPInterfaceModel
            {
                Netinterface = "Wi-Fi"
            };
            Assert.Equal("Wi-Fi", model.Netinterface);
        }
    }
}

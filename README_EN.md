# NetProfile Switcher

<div align="center">

<img src="NetworkSelector/Assets/StoreLogo.scale-200.png" alt="NetProfile Switcher" width="128">

**A WinUI 3 network preset switching tool for Windows<br/>Quickly switch between multiple IPv4 network configurations, DNS, and DHCP**

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)](https://dotnet.microsoft.com/)
[![WinUI 3](https://img.shields.io/badge/WinUI-3-0078D4)](https://learn.microsoft.com/windows/apps/winui/winui3/)
[![Windows App SDK](https://img.shields.io/badge/Windows%20App%20SDK-1.6-0078D4)](https://aka.ms/windowsappsdk)

**English** | [简体中文](README.md)

</div>

---

## 📖 Introduction

NetProfile Switcher is a desktop network configuration preset tool for Windows. It saves network configurations (IPv4 address, subnet mask, gateway, and DNS) for different network adapters and lets you switch to a specified configuration with a single click.

It is ideal for frequently switching between direct connections, bypass gateways, proxy gateways, lab networks, office networks, and home networks. Instead of repeatedly opening Windows system settings to manually change network parameters, simply maintain your presets and apply them with one click.

## 🖼️ Preview

![NetProfile Switcher preview](README/1.png)

## ✨ Features

- **Multi-profile management**: Save configuration name, network adapter, IPv4 address, subnet mask, gateway, preferred DNS, and alternate DNS.
- **Quick preset apply**: Double-click a configuration to switch, or use the right-click context menu.
- **Administrator execution**: Network changes are applied via system commands with UAC elevation triggered as needed.
- **DHCP quick restore**: Select an adapter and quickly switch back to DHCP address and DHCP DNS.
- **Auto-detect active adapter**: On startup, the currently active network interface is selected by default.
- **Interface details panel**: View adapter name, description, MAC address, IPv4 / IPv6 address, gateway, DNS, interface type, and link speed.
- **Enable / disable IPv6**: Quickly toggle the IPv6 binding state for the currently selected adapter.

## 🚀 Quick Start

### System Requirements

- Windows 10 1809 or later
- An available Ethernet, Wi-Fi, or other Windows network adapter

### Installation

#### 🛒 Get From Microsoft Store

[<img src="README/zh-cn light.svg" width="220" alt="Get from Microsoft Store">](https://apps.microsoft.com/detail/9PDQC93R0WLF)

#### 🛠️ Build From Source

1. Clone the repository:

```powershell
git clone https://github.com/sixiaolong1117/NetProfile-Switcher.git
```

2. Open `NetworkSelector.sln` with Visual Studio.
3. Restore NuGet packages.
4. Select the `x64`, `x86`, or `ARM64` platform, then run or package the app.

## 📖 Usage

### ➕ Add A Static Network Configuration

1. Click **Add** on the Gateway Switch page.
2. Enter a configuration name, such as "Bypass Gateway" or "Office Network".
3. Select the network adapter to bind.
4. Fill in the IPv4 address, subnet mask, gateway, preferred DNS, and alternate DNS.
5. Click **Add** to save the configuration.

### 🔁 Switching Configurations

| Action | Description |
|--------|-------------|
| Double-click a configuration | Apply the static network configuration immediately |
| Right-click configuration → Switch to | Apply the configuration from the context menu |
| DHCP button | Select an adapter and switch back to DHCP address and DNS |
| IPv6 button | Enable or disable IPv6 for the currently selected adapter |

> After applying a configuration, the Windows Advanced Network Settings page may need to be reopened to display the latest result.

### 📦 Import And Export

| Action | Entry |
|--------|-------|
| Import configuration | Bottom **Import** button |
| Export configuration | Configuration context menu **Export** |
| Replace configuration | Configuration context menu **Replace** |
| Copy configuration | Configuration context menu **Copy** |
| Delete configuration | Configuration context menu **Delete** |

Configuration files use the `.nsconfigx` extension. Each file contains a single network preset as JSON data, making backup and migration straightforward.

### ⚙️ Maintenance

- Execute **Reset Database** on the Settings page to clear all locally saved network configurations.

## 🔒 Privacy

NetProfile Switcher does not collect, use, or share personal information. See [PRIVACY](PRIVACY) for details.

## 🤝 Contributing

Issues and pull requests are welcome!

## 📄 License

This project is open-source under the [MIT License](LICENSE).

## 🙏 Acknowledgements

- [Windows App SDK](https://aka.ms/windowsappsdk) — Modern Windows desktop app development framework
- [Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite/) — SQLite data storage
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) — JSON serialization support
- [Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) — Windows Toast notification support
- [Microsoft.Windows.CsWin32](https://www.nuget.org/packages/Microsoft.Windows.CsWin32/) — Win32 API source-generated interop support

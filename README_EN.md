# NetProfile Switcher

<div align="center">

<img src="NetworkSelector/Assets/StoreLogo.scale-200.png" alt="NetProfile Switcher" width="128">

**A WinUI 3 network profile switcher for Windows<br/>Quickly switch between IPv4 network profiles, DNS, DHCP, and IPv6 states**

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)](NetworkSelector/NetworkSelector.csproj)
[![WinUI 3](https://img.shields.io/badge/WinUI-3-0078D4)](https://learn.microsoft.com/windows/apps/winui/winui3/)
[![Windows App SDK](https://img.shields.io/badge/Windows%20App%20SDK-1.6-0078D4)](https://aka.ms/windowsappsdk)

**English** | [简体中文](README.md)

</div>

---

## 📖 Introduction

NetProfile Switcher is a desktop network profile tool for Windows. It saves static IPv4 addresses, subnet masks, gateways, and DNS settings for different network adapters, then applies a selected profile whenever you need it.

It is useful when you often switch between direct network access, bypass gateways, proxy gateways, lab networks, office networks, and home networks. Instead of repeatedly opening Windows network settings and editing values by hand, you can maintain a few profiles and apply one with a double-click.

## 🖼️ Preview

![NetProfile Switcher preview](README/1.png)

## ✨ Features

### 🌐 Network Profile Switching

- **Multiple profiles**: Save profile name, network adapter, IPv4 address, subnet mask, gateway, preferred DNS, and alternate DNS.
- **Fast profile apply**: Double-click a profile to apply it, or use the right-click context menu.
- **Administrator elevation**: Network changes are applied through system commands and request UAC elevation when needed.
- **DHCP shortcut**: Select an adapter and quickly switch its IP address and DNS back to DHCP.

### 🧭 Network Adapter Details

- **Auto-detect active adapter**: The app selects the currently active network adapter on startup when possible.
- **Interface details panel**: View adapter name, description, MAC address, IPv4 / IPv6 address, gateway, DNS, interface type, and link speed.
- **Manual adapter selection**: Switch the adapter being viewed or configured from the drop-down list.
- **Refresh current state**: Right-click the adapter details area to reload the latest network information.

### 📋 Profile Management

- **Add / edit / delete profiles**: Manage network profiles through built-in dialogs.
- **Copy profiles**: Create a new profile from an existing one.
- **Replace profiles**: Replace an existing record with an imported profile.
- **Import / export profiles**: Back up and migrate a single network profile with `.nsconfigx` files.
- **Local database**: Profiles are stored locally in SQLite.

### 🧩 IPv6 And App Experience

- **Enable / disable IPv6**: Quickly toggle IPv6 binding for the selected adapter.
- **System notifications**: Send Windows Toast notifications after network or IPv6 state changes.
- **WinUI 3 visual style**: Supports Mica, Mica Alt, and Acrylic background materials.
- **Chinese and English UI**: Includes Simplified Chinese and English resources, switchable in Settings.
- **Database reset**: Clear all locally saved profiles from the Settings page.

## 🚀 Quick Start

### Requirements

- Windows 10 1809 or later
- An available Ethernet, Wi-Fi, or other Windows network adapter
- Administrator approval is required when switching static IP, DNS, DHCP, or IPv6 state
- Running as a normal user is recommended; WinUI file pickers used by import / export may not work in elevated administrator mode

### Installation

#### 🛒 Get From Microsoft Store

[<img src="README/zh-cn light.svg" width="220" alt="Get from Microsoft Store">](https://apps.microsoft.com/detail/9PDQC93R0WLF)

#### 🛠️ Build From Source

1. Clone the repository:

```powershell
git clone https://github.com/SIXiaolong1117/NetProfile-Switcher.git
```

2. Open `NetworkSelector.sln` with Visual Studio.
3. Restore NuGet packages.
4. Select the `x64`, `x86`, or `ARM64` platform, then run or package the app.

## 📖 Usage

### ➕ Add A Static Network Profile

1. Click **Add** on the Gateway Switch page.
2. Enter a profile name, such as "Bypass Gateway" or "Office Network".
3. Select the network adapter for this profile.
4. Fill in the IPv4 address, subnet mask, gateway, preferred DNS, and alternate DNS.
5. Click **Add** to save the profile.

### 🔁 Switch Profiles

| Action | Description |
|--------|-------------|
| Double-click a profile | Apply the static network profile immediately |
| Right-click profile -> Switch to | Apply the profile from the context menu |
| DHCP button | Select an adapter and switch its IP address and DNS back to DHCP |
| IPv6 button | Enable or disable IPv6 for the selected adapter |

> After applying a profile, you may need to reopen the Windows Advanced Network Settings page to see the latest result.

### 📦 Import And Export

| Action | Entry |
|--------|-------|
| Import profile | Bottom **Import** button |
| Export profile | Profile context menu **Export** |
| Replace profile | Profile context menu **Replace** |
| Copy profile | Profile context menu **Copy** |
| Delete profile | Profile context menu **Delete** |

Profile files use the `.nsconfigx` extension. Each file contains one network profile as JSON, making backup and migration straightforward.

### ⚙️ Personalization And Maintenance

- Switch between **Mica / Mica Alt / Acrylic** background materials in Settings.
- Switch the interface language between **Simplified Chinese / English** in Settings.
- Use **Reset Database** in Settings to clear all locally saved network profiles.

## 🏗️ Technical Stack

- **UI framework**: [WinUI 3](https://learn.microsoft.com/windows/apps/winui/winui3/) / [Windows App SDK](https://aka.ms/windowsappsdk)
- **Target framework**: .NET 8.0 Windows
- **Minimum OS version**: Windows 10 1809
- **Network information**: `System.Net.NetworkInformation`
- **Network configuration**: `netsh` and PowerShell network adapter commands
- **Local database**: [Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite/)
- **Serialization**: [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)
- **System notifications**: [Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)
- **Packaging**: MSIX, supporting x86 / x64 / ARM64

## 🔒 Privacy

NetProfile Switcher does not collect, use, or share personal information. See [PRIVACY](PRIVACY) for details.

## 🤝 Contributing

Issues and pull requests are welcome:

- Report compatibility issues across adapters, Windows versions, or network environments
- Improve profile import / export, permission prompts, and error handling
- Add localization text or polish WinUI interface details

## 📄 License

This project is open-source under the [MIT License](LICENSE).

## 🙏 Acknowledgements

- [Windows App SDK](https://aka.ms/windowsappsdk) — Modern Windows desktop app development framework
- [Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite/) — SQLite data storage
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) — JSON serialization support
- [Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) — Windows Toast notification support
- [Microsoft.Windows.CsWin32](https://www.nuget.org/packages/Microsoft.Windows.CsWin32/) — Win32 API source-generated interop support

# NetProfile Switcher

<div align="center">

<img src="NetworkSelector/Assets/StoreLogo.scale-200.png" alt="NetProfile Switcher" width="128">

**基于 WinUI 3 的 Windows 网关预设切换工具<br/>在多个 IPv4 网络配置、DNS、DHCP 与 IPv6 状态之间快速切换**

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)](NetworkSelector/NetworkSelector.csproj)
[![WinUI 3](https://img.shields.io/badge/WinUI-3-0078D4)](https://learn.microsoft.com/windows/apps/winui/winui3/)
[![Windows App SDK](https://img.shields.io/badge/Windows%20App%20SDK-1.6-0078D4)](https://aka.ms/windowsappsdk)

[English](README_EN.md) | **简体中文**

</div>

---

## 📖 简介

NetProfile Switcher 是一款面向 Windows 桌面的网络配置预设工具。它可以保存不同网卡的静态 IPv4 地址、子网掩码、网关与 DNS，并在需要时一键切换到指定配置。

适合经常在直连网络、旁路网关、代理网关、实验室网络、公司与家庭网络之间切换的场景。你不需要反复进入 Windows 网络设置页面手动修改参数，只要维护好预设，双击即可应用。

## 🖼️ 界面预览

![NetProfile Switcher 界面预览](README/1.png)

## ✨ 功能特性

### 🌐 网络预设切换

- **多配置管理**：保存配置名称、网卡接口、IPv4 地址、子网掩码、网关、首选 DNS 与备用 DNS。
- **快速应用预设**：双击配置即可切换，也可以通过右键菜单执行切换。
- **管理员授权执行**：切换网络参数时调用系统命令完成修改，并按需触发 UAC 授权。
- **DHCP 快捷恢复**：选择网卡后可快速切回 DHCP 地址与 DHCP DNS。

### 🧭 网卡信息查看

- **自动识别当前网卡**：启动后优先选中正在使用的网络接口。
- **接口详情面板**：查看接口名称、描述、MAC 地址、IPv4 / IPv6 地址、网关、DNS、接口类型与链路速率。
- **手动选择接口**：可在下拉框中切换要查看或操作的网络接口。
- **刷新信息**：右键网卡信息区域可重新读取当前网络状态。

### 📋 配置管理

- **添加 / 编辑 / 删除配置**：通过对话框维护网络预设。
- **复制配置**：快速基于已有配置创建新预设。
- **覆盖配置**：用导入的配置替换现有记录。
- **导入 / 导出配置**：使用 `.nsconfigx` 文件备份和迁移单条网络配置。
- **本地数据库保存**：配置数据保存在本地 SQLite 数据库中。

### 🧩 IPv6 与系统体验

- **启用 / 禁用 IPv6**：对当前选中的网卡快速切换 IPv6 绑定状态。
- **系统通知**：网络配置或 IPv6 状态变更后发送 Windows Toast 通知。
- **WinUI 3 视觉风格**：支持 Mica、Mica Alt、Acrylic 背景材质。
- **中英文界面**：内置简体中文与 English 资源，可在设置中切换。
- **数据库重置**：可在设置页清空本地配置数据。

## 🚀 快速开始

### 系统要求

- Windows 10 1809 或更高版本
- 可用的以太网、Wi-Fi 或其他 Windows 网络接口
- 切换静态 IP、DNS、DHCP 或 IPv6 状态时需要管理员权限授权
- 建议以普通用户身份启动应用；导入 / 导出配置依赖 WinUI 文件选择器，管理员模式下可能不可用

### 安装

#### 🛒 从 Microsoft Store 获取

[<img src="README/zh-cn light.svg" width="220" alt="从 Microsoft Store 获取">](https://apps.microsoft.com/detail/9PDQC93R0WLF)

#### 🛠️ 从源码构建

1. 克隆仓库：

```powershell
git clone https://github.com/SIXiaolong1117/NetProfile-Switcher.git
```

2. 使用 Visual Studio 打开 `NetworkSelector.sln`。
3. 还原 NuGet 包。
4. 选择 `x64`、`x86` 或 `ARM64` 平台后运行或打包。

## 📖 使用指南

### ➕ 添加静态网络配置

1. 在“网关切换”页面点击 **添加**。
2. 填写配置名称，例如“旁路网关”或“公司网络”。
3. 选择要绑定的网络接口。
4. 填写 IPv4 地址、子网掩码、网关、首选 DNS 与备用 DNS。
5. 点击 **添加** 保存配置。

### 🔁 切换配置

| 操作 | 说明 |
|------|------|
| 双击配置 | 立即应用该静态网络配置 |
| 右键配置 → 切换至此配置 | 通过菜单应用该配置 |
| DHCP 按钮 | 选择网卡并切回 DHCP 地址与 DNS |
| IPv6 按钮 | 对当前选中网卡启用或禁用 IPv6 |

> 应用配置后，Windows 高级网络设置页面可能需要重新打开才能显示最新结果。

### 📦 导入与导出

| 操作 | 入口 |
|------|------|
| 导入配置 | 页面底部 **导入** 按钮 |
| 导出配置 | 配置项右键菜单 **导出** |
| 覆盖配置 | 配置项右键菜单 **覆盖配置** |
| 复制配置 | 配置项右键菜单 **复制** |
| 删除配置 | 配置项右键菜单 **删除** |

配置文件扩展名为 `.nsconfigx`，内容为单条网络预设的 JSON 数据，便于备份和迁移。

### ⚙️ 个性化与维护

- 在设置页切换 **Mica / Mica Alt / Acrylic** 背景材质。
- 在设置页切换 **简体中文 / English** 界面语言。
- 在设置页执行 **重置数据库**，清空本地保存的所有网络配置。

## 🏗️ 技术架构

- **UI 框架**：[WinUI 3](https://learn.microsoft.com/windows/apps/winui/winui3/) / [Windows App SDK](https://aka.ms/windowsappsdk)
- **目标框架**：.NET 8.0 Windows
- **最低系统版本**：Windows 10 1809
- **网络信息读取**：`System.Net.NetworkInformation`
- **网络配置切换**：`netsh` 与 PowerShell 网络适配器命令
- **本地数据库**：[Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite/)
- **序列化**：[Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)
- **系统通知**：[Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)
- **打包方式**：MSIX，支持 x86 / x64 / ARM64

## 🔒 隐私

NetProfile Switcher 不会收集、使用或分享个人信息。更多说明请查看 [PRIVACY](PRIVACY)。

## 🤝 贡献

欢迎提交 Issue 和 Pull Request：

- 反馈不同网卡、系统版本或网络环境下的兼容性问题
- 改进配置导入导出、权限提示与异常处理体验
- 补充国际化文本或优化 WinUI 界面细节

## 📄 许可证

本项目基于 [MIT 许可证](LICENSE) 开源。

## 🙏 致谢

- [Windows App SDK](https://aka.ms/windowsappsdk) — 现代 Windows 桌面应用开发框架
- [Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite/) — SQLite 数据存储
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) — JSON 序列化支持
- [Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) — Windows Toast 通知支持
- [Microsoft.Windows.CsWin32](https://www.nuget.org/packages/Microsoft.Windows.CsWin32/) — Win32 API 源生成互操作支持

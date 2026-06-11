# AGENTS.md

## 项目概览

NetProfile Switcher：基于 WinUI 3 (Windows App SDK) 的 Windows 网络配置预设切换工具。单项目 .NET 解决方案，非 monorepo。

## 构建

```powershell
# 还原依赖
dotnet restore NetworkSelector.sln

# 构建 (必须指定平台)
dotnet build NetworkSelector.sln -c Release -p:Platform=x64
dotnet build NetworkSelector.sln -c Release -p:Platform=ARM64
dotnet build NetworkSelector.sln -c Release -p:Platform=x86
```

也可通过 Visual Studio 打开 `NetworkSelector.sln` 后构建。

**注意**：不支持 `dotnet run` 直接运行，必须通过 Visual Studio 或 MSIX 打包部署。

## 平台与目标

- 目标框架：`net8.0-windows10.0.19041.0`
- 最低版本：Windows 10 1809 (10.0.17763.0)
- 支持平台：x86、x64、ARM64
- 打包格式：MSIX Bundle（AppxBundle=Always）

## 项目结构

```
NetworkSelector/
├── App.xaml.cs              # 入口，单实例控制
├── MainWindow.xaml.cs       # 主窗口，导航框架 + 背景材质(Mica/Acrylic)
├── Pages/
│   ├── NetSelectPage.xaml.cs   # 核心页面：网卡切换、配置管理
│   ├── SettingsPage.xaml.cs    # 设置页
│   ├── About.xaml.cs           # 关于页
│   └── Dialogs/
│       ├── AddNSConfig.xaml.cs     # 添加/编辑静态网络配置
│       └── AddDHCPConfig.xaml.cs   # DHCP 配置对话框
├── Methods/
│   └── NSMethod.cs          # 网络操作、导入导出、通知
├── Models/
│   ├── NSModel.cs            # 网络配置数据模型
│   ├── InterfaceInfoModel.cs # 网卡详情模型
│   └── DHCPInterfaceModel.cs # DHCP 模型
├── Datas/
│   └── SQLiteHelper.cs       # SQLite CRUD (ns.db)
└── Language/
    ├── zh-CN/Resources.resw  # 中文资源（主语言）
    └── en-US/Resources.resw  # 英文资源
```

## 关键技术点

- **管理员权限**：网络切换操作通过 `PowerShell.exe` + `netsh` 命令执行，使用 `Verb = "runas"` 触发 UAC
- **P/Invoke**：启用了 `AllowUnsafeBlocks`，使用 CsWin32 源生成器调用 Win32 API（窗口管理、DPI 等）
- **单实例**：通过 `AppInstance.FindOrRegisterForKey` 实现，重复启动会激活已有实例
- **SQLite**：运行时创建 `ns.db`，存储网络配置预设（NSTable 表）
- **本地化**：使用 `Windows.ApplicationModel.Resources.ResourceLoader`，zh-CN 为参考标准，en-US 需保持同步
- **背景材质**：支持 Mica、MicaAlt、Acrylic 三种，通过 LocalSettings 的 `materialStatus` 键切换

## 本地化

修改 UI 字符串时，必须同时更新两个资源文件：
- `Language/zh-CN/Resources.resw`（主版本）
- `Language/en-US/Resources.resw`

新增资源键时参考 `zh-CN` 下已有的键名格式。

## 注意事项

- 配置导出格式为 `.nsconfigx`（JSON），内容为 `NSModel` 序列化
- FilePicker 在管理员权限下无法打开（WinUI 限制），需降权或提示用户
- `netsh` 命令中网卡名含空格时需用单引号包裹
- AppxBundle 默认只打 x64（csproj 中 `AppxBundlePlatforms=x64`），但 HasPackageAndPublishMenu 条件下会扩展到 `x64|arm64`

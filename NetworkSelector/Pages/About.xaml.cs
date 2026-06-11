// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

﻿using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using System.Net.Http;
using Microsoft.UI.Xaml;

namespace NetworkSelector.Pages
{
    public sealed partial class About : Page
    {
        public About()
        {
            this.InitializeComponent();

            // 在构造函数或其他适当位置设置版本号
            var package = Package.Current;
            var version = package.Id.Version;

            APPVersion.Text = $"{version.Major}.{version.Minor}.{version.Build}";
            //APPVersion.NavigateUri = new System.Uri($"https://github.com/SIXiaolong1117/NetProfile-Switcher/releases/tag/{version.Major}.{version.Minor}.{version.Build}.{version.Revision}");
            //APPVersion.NavigateUri = new System.Uri($"https://www.microsoft.com/store/apps/9PDQC93R0WLF");

            GetList();
        }
        private void AboutAliPay_Click(object sender, RoutedEventArgs e)
        {
            AboutAliPayTips.IsOpen = true;
        }
        private void AboutWePay_Click(object sender, RoutedEventArgs e)
        {
            AboutWePayTips.IsOpen = true;
        }
        private async Task<string> HTTPResponse(string http)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(http);
                if (response.IsSuccessStatusCode)
                {
                    // 从GitHub的响应中读取文件内容
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return "";
                }
            }
        }
        private async void GetList()
        {
            string nameList = null;
            try
            {
                nameList = await HTTPResponse("https://raw.githubusercontent.com/SIXiaolong1117/SIXiaolong1117/main/README/Sponsor/List");
            }
            catch
            {
                nameList = "无法连接至 Github。";
            }

            NameList.Text = nameList;
        }
    }
}

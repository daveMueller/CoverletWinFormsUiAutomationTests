using System;
using System.Diagnostics;
using System.IO;
using WindowsFormsApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
            var solutionRoot = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\"));
            var assemblyPath = $"{solutionRoot}WindowsFormsApp1\\bin\\Debug\\WindowsFormsApp1.exe";

            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", assemblyPath);
            options.AddAdditionalCapability("platformName", "Windows");

            var session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
            var textBox = session.FindElementByClassName("WindowsForms10.EDIT.app.0.141b42a_r7_ad1");
            session.FindElementByName("button1").Click();

            Assert.AreEqual(textBox.Text, "Hello World!");
            session.Quit();
        }
    }
}

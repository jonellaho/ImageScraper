using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;

namespace GoogleImage
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchParameter = "";

            Console.WriteLine("Please enter the Search Parameter:");
            searchParameter = Console.ReadLine();

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");

            driver.FindElement(By.Name("q")).SendKeys(searchParameter + Keys.Enter);

            driver.FindElement(By.XPath("/html/body/div[6]/div[2]/div[3]/div/div/div[1]/div/div/div[1]/div/div[2]/a")).Click();

            List<string> urls = new List<string>();
            for (int i = 1; i <= 3; i++)
            {
                urls.Add(driver.FindElement(By.XPath("/html/body/div[2]/c-wiz/div[3]/div[1]/div/div/div/div/div[1]/div[1]/div[" + i.ToString() + "]/a[2]")).GetAttribute("href"));
                string base64image = driver.FindElement(By.XPath("/html/body/div[2]/c-wiz/div[3]/div[1]/div/div/div/div/div[1]/div[1]/div[" + i.ToString() + "]/a[1]/div[1]/img")).GetAttribute("src").Split(',')[1];
                File.WriteAllBytes(@"images/stringKerkimi" + i.ToString() + ".jpg", Convert.FromBase64String(base64image));
            }
        }
    }
}

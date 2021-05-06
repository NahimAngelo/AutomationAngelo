using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Opera;
using System;
using System.Threading;

namespace AutomationAngelo
{
    class AutomationClass
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new OperaDriver("C:/Users/BioXtrem/Documents/operadriver_win64");
        }

        [Test]
        public void test()
        {
            driver.Url = "http://automationpractice.com/index.php";
            Thread.Sleep(500);

            //Go to log In
            driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a")).Click();
            Thread.Sleep(500);

            //Log In
            driver.FindElement(By.Id("email")).SendKeys("test1249@test.com");
            driver.FindElement(By.Id("passwd")).SendKeys("PKR@PKR");
            driver.FindElement(By.Id("SubmitLogin")).Click();
            Thread.Sleep(1000);

            //Go to Women
            driver.FindElement(By.XPath("//*[@id='block_top_menu']/ul/li[1]/a")).Click();
            Thread.Sleep(500);

            //Add a item
            IWebElement SecondImg = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[3]/div[2]/ul/li[2]/div/div[1]/div/a[1]/img"));
            IWebElement MoreBtn = driver.FindElement(By.XPath("/html/body[1]/div[1]/div[2]/div[1]/div[3]/div[2]/ul/li[2]/div[1]/div[2]/div[2]/a[2]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(SecondImg).MoveToElement(MoreBtn).Click().Perform();
            driver.FindElement(By.Id("quantity_wanted")).Clear();
            driver.FindElement(By.Id("quantity_wanted")).SendKeys("2");
            driver.FindElement(By.XPath("//p[@id='add_to_cart']//span[.='Add to cart']")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[1]/span")).Click();
            Thread.Sleep(500);

            //Go to Dresses
            driver.FindElement(By.XPath("//*[@id='block_top_menu']/ul/li[2]/a")).Click();
            Thread.Sleep(500);

            //Add a item
            IWebElement DressSecondImg = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[3]/div[2]/ul/li[2]/div/div[1]/div/a[1]/img"));
            IWebElement DressMoreBtn = driver.FindElement(By.XPath("/html/body[1]/div[1]/div[2]/div[1]/div[3]/div[2]/ul/li[2]/div[1]/div[2]/div[2]/a[2]"));
            Actions dressActions = new Actions(driver);
            dressActions.MoveToElement(DressSecondImg).MoveToElement(DressMoreBtn).Click().Perform();
            driver.FindElement(By.Id("quantity_wanted")).Clear();
            driver.FindElement(By.Id("quantity_wanted")).SendKeys("2");
            driver.FindElement(By.XPath("//p[@id='add_to_cart']//span[.='Add to cart']")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a")).Click();
            Thread.Sleep(1000);

            //Checkout page Proceed
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[3]/div/p[2]/a[1]/span")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[3]/div/form/p/button/span")).Click();

            //Agree terms&Conditions
            driver.FindElement(By.XPath("//*[@id=\"cgv\"]")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[3]/div/div/form/p/button/span")).Click();
            Thread.Sleep(500);

            //Click on Payby Check
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[3]/div/div/div[3]/div[2]/div/p/a")).Click();
            Thread.Sleep(500);

            //Confirm the order
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[3]/div/form/p/button/span")).Click();
            Thread.Sleep(500);

            // Verify that Product is ordered
            String ConfirmationText = driver.FindElement(By.XPath("//div[@id='center_column']/p[@class='alert alert-success']")).Text;
            if (ConfirmationText.Contains("complete"))
            {
                Console.WriteLine("Order Completed: Test Case Passed");
            }
            else
            {
                Console.WriteLine("Order Not Successfull: Test Case Failed");
            }

        }

        [TearDown]
        public void closeBrowser()
        {
            Thread.Sleep(5000);
            driver.Close();
        }
    }
}

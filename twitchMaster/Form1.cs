using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;

namespace twitchMaster
{
    public partial class Form1 : Form
    {
        static IWebDriver driver = new ChromeDriver(@"C:\Users\dimad\Desktop");
        public Form1()
        {
            InitializeComponent();
            Login();
            Thread.Sleep(2000);
            OpenPromo();
            OpenNewTab();

            pause(7000);
            OpenTop();
    
        }
        public void OpenNewTab()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open('https://twitchmaster.ru/');");
        
        }
        public void OpenPromo()
        {
            driver.Url = "https://twitchmaster.ru/";
            driver.FindElement(By.PartialLinkText("Перейти к просмотру трансляции")).Click();
            Thread.Sleep(5000);
        }
        public void OpenTop()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Url = "https://twitchmaster.ru/";
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div/div[1]/a[2]/img")).Click();
            Thread.Sleep(5000);
        }
        public void pause(int vr)
        {
            double time = DateTime.Now.TimeOfDay.TotalMilliseconds;
            while ((DateTime.Now.TimeOfDay.TotalMilliseconds - time) < vr)
            {
                Application.DoEvents();
            }

        }
        public void Login()
        {

            driver.Url = "https://twitchmaster.ru/";
            pause(50000);

            driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/span[2]/a[2]")).Click();
           
            pause(20000);

            driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/span[2]/a[2]")).Click();

            pause(2000);
            driver.FindElement(By.Name("login")).SendKeys("GRO08Y");
            driver.FindElement(By.Name("mypw")).SendKeys("quakederepa");
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div[4]/div[2]/form/div[5]/div")).Click();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

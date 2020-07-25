using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
using System.Timers;

namespace twitchMaster
{
    public partial class Form1 : Form
    {
        static IWebDriver driver = new ChromeDriver(@"C:\Users\dimad\Desktop");
        private static System.Timers.Timer aTimer;
        public Form1()
        {
            InitializeComponent();
            
            Login();
         
            pause(2000);
           
            OpenPromo();
            OpenNewTab();

            pause(2000);
            OpenTop();
            SetTimer();

        }
        private void SetTimer()
        {
           
            aTimer = new System.Timers.Timer(600000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            CheckTop();
          
            CheckPromo();
           
            
        }
        private void CheckPromo()
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            if (driver.FindElement(By.XPath("/html/body/div[1]/div/div[4]/div[2]/div[3]/b")).Displayed)
            {
                return;
            }
            else
            {
                driver.Url = "https://twitchmaster.ru/";
                pause(180000);
                OpenPromo();
            }

        }
        private void CheckTop()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            if (driver.FindElement(By.XPath("/html/body/div[1]/div/div[4]/div[2]/div[5]")).Displayed)
            {
                return;
            }
            else
            {
                driver.Url = "https://twitchmaster.ru/";
                pause(180000);
                OpenTop();
            }

        }
        protected void WaitForPageLoad()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public void OpenNewTab()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open('https://twitchmaster.ru/');");
        
        }
        public void OpenPromo()
        {
            driver.Url = "https://twitchmaster.ru/";
            pause(2000);
            driver.FindElement(By.PartialLinkText("Перейти к просмотру трансляции")).Click();
           
            
          

        }
        public void OpenTop()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Url = "https://twitchmaster.ru/";
            pause(2000);
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div/div[1]/a[2]/img")).Click();
        
         
      
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
            pause(30000);
            driver.Url = "https://twitchmaster.ru/static/about";
           
            WaitForPageLoad();
            driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/span[2]/a[2]")).Click();
            pause(2000);


            driver.FindElement(By.Name("login")).SendKeys("GRO08Y");
            driver.FindElement(By.Name("mypw")).SendKeys("quakederepa");
            pause(2000);
            driver.FindElement(By.XPath("/html/body/div[4]/div[2]/form/div[5]/div")).Click();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//A[@class='item'][text()='Sign In']")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.XPath, Using = "(//INPUT[@type='text'])[2]")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.XPath, Using = "//INPUT[@type='password']")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//BUTTON[@class='fluid ui teal button'][text()='Login']")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.Credpath, "Credentials");


            SignIntab.Click();
            Thread.Sleep(3000);
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "username"));
            GlobalDefinitions.TurnOnWait();
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "password"));
            GlobalDefinitions.TurnOnWait();
            LoginBtn.Click(); 
            GlobalDefinitions.TurnOnWait();

        }
    }
}
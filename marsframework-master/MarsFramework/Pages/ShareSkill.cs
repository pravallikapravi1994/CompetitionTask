using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
   class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.XPath, Using = "//*[text()='Share Skill']")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.XPath, Using = "//input[@name ='title'][@type='text']")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.XPath, Using = "//textarea[@name ='description']")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name ='categoryId']")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name ='subcategoryId']")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "(//input[@aria-label='Add new tag'])[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type - Hourly
        [FindsBy(How = How.XPath, Using = "(//input[@name='serviceType'])[1]")]
        private IWebElement HourlyServiceType { get; set; }

        //Select the Service type - OneOffServiceType
        [FindsBy(How = How.XPath, Using = "(//input[@name='serviceType'])[2]")]
        private IWebElement OneOffServiceType { get; set; }

        //Select the onSiteLocationType 
        [FindsBy(How = How.XPath, Using = "(//input[@name='locationType'])[1]")]
        private IWebElement onSiteLocationType { get; set; }

        //Select the onlineLocationType 
        [FindsBy(How = How.XPath, Using = "(//input[@name='locationType'])[2]")]
        private IWebElement onlineLocationType { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDate{ get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDate{ get; set; }

        //Storing the table of available days MondayCheckbox
        [FindsBy(How = How.XPath, Using = "//*[@index='1'][@type='checkbox']")]
        private IWebElement MondayCheckbox { get; set; }

        //Storing the MondayStartTime
        [FindsBy(How = How.XPath, Using = "//*[@index='1'][@name='StartTime']")]
        private IWebElement MondayStartTime { get; set; }


        //Click on MondayendTime
        [FindsBy(How = How.XPath, Using = "//*[@index='1'][@name='EndTime']")]
        private IWebElement MondayendTime { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "(//input[@name='skillTrades'])[1]")]
        private IWebElement SkillExchange { get; set; }


        //Enter Credit radio button
        [FindsBy(How = How.XPath, Using = "(//input[@name='skillTrades'])[1]")]
        private IWebElement Creditradiobutton { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "(//input[@name='isActive'])[1]")]
        private IWebElement ActiveRadiobutton { get; set; }


        [FindsBy(How = How.XPath, Using = "(//input[@aria-label='Add new tag'])[2]")]
        private IWebElement SkillExchangeTags { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Savebutton { get; set; }

        internal void EnterShareSkill()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Service Data");


            GlobalDefinitions.wait(1000);
            ShareSkillButton.Click();
           
            GlobalDefinitions.wait(1000);

            //Enter Title

            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Enter Description

            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Select Category
            SelectElement catg = new SelectElement(CategoryDropDown);
            GlobalDefinitions.wait(1000);
            catg.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //Select Subcategory

            OpenQA.Selenium.Support.UI.SelectElement subcatg = new SelectElement(SubCategoryDropDown);
            GlobalDefinitions.wait(1000);
            subcatg.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Sub Category"));

            //Tags 
            GlobalDefinitions.wait(1000);
            Tags.Click();
            GlobalDefinitions.wait(1000);
            Tags.SendKeys("FirstTag" + "\n");

            //Select Service Type from radio buttons

            OneOffServiceType.Click();


            //Select Location Type radio button

            onlineLocationType.Click();

            //Select Available days and Time
            //select startdate
            StartDate.Click();
            GlobalDefinitions.wait(1000);
            StartDate.SendKeys("25062020");

            //Select end date
            EndDate.Click();
            GlobalDefinitions.wait(1000);
            EndDate.SendKeys("25072020");

            //Select Monday
            MondayCheckbox.Click();

            //Select start time for Monday
            MondayStartTime.Click();
            GlobalDefinitions.wait(1000);
            MondayStartTime.SendKeys("0930am");
            GlobalDefinitions.wait(1000);

            //Select end time for Monday
            MondayendTime.Click();
            GlobalDefinitions.wait(1000);
            MondayendTime.SendKeys("0530pm");
            GlobalDefinitions.wait(1000);

            //Select Skill Trade radio button



            Creditradiobutton.Click();

            GlobalDefinitions.wait(1000);


            GlobalDefinitions.wait(1000);
            SkillExchangeTags.Click();
            GlobalDefinitions.wait(1000);
            SkillExchangeTags.SendKeys("FirstSTag" + "\n");

            //Select Active radio button

            ActiveRadiobutton.Click();

            //Save the data
            GlobalDefinitions.wait(1000);

            Savebutton.Click();
            GlobalDefinitions.wait(1000);





        }



        internal void editShareskill()
        {

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Service Data");


           

            GlobalDefinitions.wait(1000);

            //Enter Title

            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Enter Description

            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Select Category
            SelectElement catg = new SelectElement(CategoryDropDown);
            GlobalDefinitions.wait(1000);
            catg.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //Select Subcategory

            OpenQA.Selenium.Support.UI.SelectElement subcatg = new SelectElement(SubCategoryDropDown);
            GlobalDefinitions.wait(1000);
            subcatg.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Sub Category"));

            //Tags 
            GlobalDefinitions.wait(1000);
            Tags.Click();
            GlobalDefinitions.wait(1000);
            Tags.SendKeys("FirstTag" + "\n");

            //Select Service Type from radio buttons

            OneOffServiceType.Click();


            //Select Location Type radio button

            onlineLocationType.Click();

            //Select Available days and Time
            //select startdate
            StartDate.Click();
            GlobalDefinitions.wait(1000);
            StartDate.SendKeys("25062020");

            //Select end date
            EndDate.Click();
            GlobalDefinitions.wait(1000);
            EndDate.SendKeys("25072020");

            //Select Monday
            MondayCheckbox.Click();

            //Select start time for Monday
            MondayStartTime.Click();
            GlobalDefinitions.wait(1000);
            MondayStartTime.SendKeys("0930am");
            GlobalDefinitions.wait(1000);

            //Select end time for Monday
            MondayendTime.Click();
            GlobalDefinitions.wait(1000);
            MondayendTime.SendKeys("0530pm");
            GlobalDefinitions.wait(1000);

            //Select Skill Trade radio button



            Creditradiobutton.Click();

            GlobalDefinitions.wait(1000);


            GlobalDefinitions.wait(1000);
            SkillExchangeTags.Click();
            GlobalDefinitions.wait(1000);
            SkillExchangeTags.SendKeys("FirstSTag" + "\n");

            //Select Active radio button

            ActiveRadiobutton.Click();

            //Save the data
            GlobalDefinitions.wait(1000);

            Savebutton.Click();
            GlobalDefinitions.wait(1000);


        }

    }
}

using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using NUnit.Framework;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']//table/tbody/tr[1]/td[8]//i[@class='remove icon']")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']//table/tbody/tr[1]/td[8]//i[@class='outline write icon']")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        //First row title
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']//tbody/tr[1]/td[3]")]
        private IWebElement TitleS1 { get; set; }


        //First row Description
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']//tbody/tr[1]/td[4]")]
        private IWebElement DescriptionS1 { get; set; }


        //First row CategoryS1
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']//tbody/tr[1]/td[2]")]
        private IWebElement CategoryS1 { get; set; }


        //First row CategoryS1
        [FindsBy(How = How.XPath, Using = "//i[@class='checkmark icon']")]
        private IWebElement deleteyes { get; set; }

        //First row CategoryS1
        [FindsBy(How = How.XPath, Using = "//*[text()='No']")]
        private IWebElement deleteno { get; set; }



        internal void VerifySavedServiceListings()
        {


            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Service Data");

            var ExpTitle = (GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            var ActTitle = TitleS1.Text;


            var ExpDes = (GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            var ActDes = DescriptionS1.Text;


            var ExpCat = (GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            var ActCat = CategoryS1.Text;


            Assert.AreEqual(ExpTitle, ActTitle, "Title is  not  saved");
            Assert.AreEqual(ExpDes, ActDes, "Description does not match");
            Assert.AreEqual(ExpCat, ActCat, "Categoty does not match");



        }


        internal void EditSharedSkill()
        {

            GlobalDefinitions.wait(3000);
            edit.Click();
            GlobalDefinitions.TurnOnWait();

            ShareSkill s = new ShareSkill();
            s.editShareskill();
            GlobalDefinitions.wait(3000);

        }



        internal void DeleteSharedSkill()
        {
            GlobalDefinitions.wait(3000);
            delete.Click();
            GlobalDefinitions.TurnOnWait();


        }

        internal void DeleteSharedYes()
        {

            GlobalDefinitions.wait(3000);
            deleteyes.Click();
            GlobalDefinitions.TurnOnWait();


        }

        internal void DeleteSharedSkillNo()
        {

            GlobalDefinitions.wait(3000);
            deleteno.Click();
            GlobalDefinitions.TurnOnWait();


        }



        internal void VerifyDeleted()
        {

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Service Data");

            var ExpTitle = (GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            var ActTitle = TitleS1.Text;
                Assert.AreNotEqual(ActTitle, ExpTitle, "Title not deleted");

        }





        internal void VerifyNotDeleted()
        {

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Service Data");

            var ExpTitle = (GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            var ActTitle = TitleS1.Text;
            Assert.AreEqual(ActTitle, ExpTitle, "Title deleted");

        }



    }
}

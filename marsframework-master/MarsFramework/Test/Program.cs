using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {
           
            [Test, Order(1)]
            public void AddShareSkillService()
            {

                GlobalDefinitions.TurnOnWait();

                ShareSkill s = new ShareSkill();
                s.EnterShareSkill();



                GlobalDefinitions.wait(3000);

              

                
                
                GlobalDefinitions.TurnOnWait();



                ManageListings ml = new ManageListings();
                ml.VerifySavedServiceListings();


            }



            [Test, Order(2)]
            public void EditShareSkill()
            {

                GlobalDefinitions.TurnOnWait();

                Profile profile = new Profile();
                profile.NavigateToManageListingpage();

                GlobalDefinitions.TurnOnWait();


              

                
                GlobalDefinitions.TurnOnWait();

                ManageListings ml = new ManageListings();
                ml.EditSharedSkill();


                GlobalDefinitions.TurnOnWait();
                profile.NavigateToManageListingpage();

                GlobalDefinitions.TurnOnWait();
                ml.VerifySavedServiceListings();

               

                GlobalDefinitions.TurnOnWait();     

            }



            [Test, Order(4)]
            public void DeleteShareSkillIsDeleted()
            {

                GlobalDefinitions.TurnOnWait();

                Profile profile = new Profile();
                profile.NavigateToManageListingpage();

                GlobalDefinitions.TurnOnWait();
                GlobalDefinitions.wait(1000);

                ManageListings ml = new ManageListings();
                ml.DeleteSharedSkill();

                GlobalDefinitions.TurnOnWait();
                GlobalDefinitions.wait(1000);
                ml.DeleteSharedYes();

                GlobalDefinitions.TurnOnWait();
                GlobalDefinitions.wait(1000);
                ml.VerifyDeleted();


            }

            [Test, Order(3)]
            public void DeleteShareSkillNotDeleted()
            {

                GlobalDefinitions.TurnOnWait();

                Profile profile = new Profile();
                profile.NavigateToManageListingpage();

                GlobalDefinitions.TurnOnWait();

                ManageListings ml = new ManageListings();
                GlobalDefinitions.wait(1000);
                ml.DeleteSharedSkill();

                GlobalDefinitions.TurnOnWait();
                GlobalDefinitions.wait(1000);
                ml.DeleteSharedSkillNo();

                GlobalDefinitions.TurnOnWait();
                GlobalDefinitions.wait(1000);
                ml.VerifyNotDeleted();


            }


        }
    }
}
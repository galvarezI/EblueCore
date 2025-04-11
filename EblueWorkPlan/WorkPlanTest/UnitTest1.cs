using EblueWorkPlan.Controllers;
using EblueWorkPlan.Models;
using Moq;

namespace WorkPlanTest
{
    [TestClass]
    public class UnitTest1
    {
        private ProjectsController _projectsController;

        [TestInitialize]
        public void setup() {
            
        
        
        }


        [TestMethod]
        public void Create_ValidProject_Redirect()
        {
            //Averange

            var project = new Project { 
                ProjectTitle = "A short title",
                ProjectNumber = "AC-984",

            
            
            
            };
        }
    }
}
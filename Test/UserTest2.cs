using System;
using System.Collections.Generic;
using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;
using PG332_SoftwareDesign_EksamenH21.Stubs;

namespace Test
{
    public class UserTest2
    {
        
        [SetUp]
        public void Setup()
        {

        }
        
        
        [Test]
        public void ShouldPrintUser()
        {
            ConsoleUiStub consoleUiStub = new ConsoleUiStub();
            consoleUiStub.ShowRegisteUserMenu();
        }

        [Test]
        public void ShouldSaveUser()
        {
            ConsoleUiStub consoleUiStub = new ConsoleUiStub();
            consoleUiStub.AddUserMenu();
        }
        
    }
    
    
    
}
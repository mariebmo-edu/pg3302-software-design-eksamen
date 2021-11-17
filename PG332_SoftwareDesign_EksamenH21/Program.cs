using System;
using System.Collections.Generic;
using System.Linq;
using PG332_SoftwareDesign_EksamenH21.Controllers;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21
{
    class Program
    {
    
        static void Main(string[] args)
        {
            
            AddDummyData();
            using TrackerContext trackerContext = new();
            ConsoleUi ui = new ConsoleUi();
            var userController = new UserController();
            ui.SetUserController(userController);
            
            ui.start();
            
            
        }


        private static void AddDummyData()
        {
            ConfigFile cf = new();
            cf.AddDummyData();
        }
    }
}
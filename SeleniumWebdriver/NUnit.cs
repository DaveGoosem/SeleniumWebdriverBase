using System;
using System.Xml;
using NUnit.Framework;
using System.Net.Mail;

namespace SeleniumWebdriver
{

    [SetUpFixture]
    public class HouseKeeping
    {
        
        [TearDown]
        public void RunOnFinish()
        {

            // Will run at the completion of all NUnit tests

        }

    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VoteappAPI.Models;
using VoteappAPI.Context;

namespace VoteappAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Vote()
        {
            var vote = new Vote();
            
        }

        [TestMethod]
        public void Choices()
        {
            var choice = new Choice();
            choice.Text = "kudde är bög";
            choice.Timestamp = DateTime.Today;
            var context = new VoteContext();
            context.Choices.Add(choice);
            context.SaveChanges();

        }
    }
}

using CinemaTicketSystem.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Tests.Models {
    [TestClass]
    public class SurveyStatisticsTest {
        [TestMethod()]
        public void TestToStatistics() {
            List<Survey> surveys = CreateSurveys();
            SurveyStatisticsViewModel stats = SurveyStatisticsViewModel.ToStatistics(surveys);

            Assert.AreEqual(10, stats.TotalSurveys);
            Assert.AreEqual(10, stats.Comments.Count());
            Assert.IsTrue(IsBetween(5, 10, stats.AverageBathroom));
            Assert.IsTrue(IsBetween(5, 10, stats.AverageFood));
            Assert.IsTrue(IsBetween(5, 10, stats.AverageMovie));
            Assert.IsTrue(IsBetween(5, 10, stats.AverageOverall));
            Assert.IsTrue(IsBetween(5, 10, stats.AverageShop));
            Assert.IsTrue(IsBetween(5, 10, stats.AverageStaff));
            Assert.IsTrue(IsBetween(5, 10, stats.AverageTravel));
        }

        private bool IsBetween(int low, int high, double number) {
            return (number >= low && number <= high);
        }

        private List<Survey> CreateSurveys() {
            List<Survey> surveys = new List<Survey>();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++) {
                surveys.Add(CreateSurvey(i, rnd.Next(5, 10), "Comment nr " + i));
            }
            return surveys;
        }

        private Survey CreateSurvey(int id, int scores, string comment) {
            return new Survey { Id = id, OverallExperience = scores, MovieExperience = scores, BathroomExperience = scores, FoodExperience = scores, ShopExperience = scores, StaffExperience = scores, TravelExperience = scores, Comment = comment };
        }
    }
}

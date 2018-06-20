using CinemaTicketSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models {
    public class SurveyStatisticsViewModel {
        public int Id { get; set; }
        public int TotalSurveys { get; set; }
        public double AverageOverall { get; set; }
        public double AverageMovie { get; set; }
        public double AverageTravel { get; set; }
        public double AverageBathroom { get; set; }
        public double AverageShop { get; set; }
        public double AverageFood { get; set; }
        public double AverageStaff { get; set; }
        public List<string> Comments { get; set; }

        public SurveyStatisticsViewModel (int totalSurveys, double overall, double movie, double travel, double bathroom, double shop, double food, double staff, List<string> comments) {
            this.Comments = comments;
            this.TotalSurveys = totalSurveys;
            this.AverageOverall = overall / totalSurveys;
            this.AverageMovie = movie / totalSurveys;
            this.AverageTravel = travel / totalSurveys;
            this.AverageBathroom = bathroom / totalSurveys;
            this.AverageShop = shop / totalSurveys;
            this.AverageFood = food / totalSurveys;
            this.AverageStaff = staff / totalSurveys;
        }

        public static SurveyStatisticsViewModel ToStatistics(List<Survey> surveys) {
            int totalSurveys = 0;
            double averageOverall = 0;
            double averageMovie = 0;
            double averageTravel = 0;
            double averageBathroom = 0;
            double averageShop = 0;
            double averageStaff = 0;
            double averageFood = 0;
            List<string> comments = new List<string>();
            foreach (var survey in surveys) {
                totalSurveys++;
                averageOverall += survey.OverallExperience;
                averageMovie += survey.MovieExperience;
                averageTravel += survey.TravelExperience;
                averageBathroom += survey.BathroomExperience;
                averageShop += survey.ShopExperience;
                averageStaff += survey.StaffExperience;
                averageFood += survey.FoodExperience;
                if (survey.Comment != null) {
                    comments.Add(survey.Comment);
                }
            }
            return new SurveyStatisticsViewModel(totalSurveys, averageOverall, averageMovie, averageTravel, averageBathroom, averageShop, averageFood, averageStaff, comments);
        }

        public Dictionary<string, double> GetNumbers() {
            Dictionary<string, double> results = new Dictionary<string, double>();
            results.Add("Total", this.TotalSurveys);
            results.Add("Overall", this.AverageOverall);
            results.Add("Movie", this.AverageMovie);
            results.Add("Travel", this.AverageTravel);
            results.Add("Bathroom", this.AverageBathroom);
            results.Add("Shop", this.AverageShop);
            results.Add("Staff", this.AverageStaff);
            results.Add("Food", this.AverageFood);
            return results;
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExoGradeTDD;

namespace ExoGradeTDD.Test
{
    [TestClass]
    public class GradingCalculatorTests
    {
        [TestMethod]
        public void WhenScore_95_Presence_90_Then_A()
        {
            // Arrange
            var gradingCalculator = new GradingCalculator();
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;

            // Act
            var grade = gradingCalculator.GetGrade();
            // Assert
            Assert.AreEqual('A', grade);
        }


        [TestMethod]
        public void WhenScore_85_Presence_90_Then_B()
        {
            // Arrange
            var gradingCalculator = new GradingCalculator();
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;

            // Act
            var grade = gradingCalculator.GetGrade();
            // Assert
            Assert.AreEqual('B', grade);
        }

        [TestMethod]
        public void WhenScore_65_Presence_90_Then_C()
        {
            // Arrange
            var gradingCalculator = new GradingCalculator();
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;

            // Act
            var grade = gradingCalculator.GetGrade();
            // Assert
            Assert.AreEqual('C', grade);
        }

        [TestMethod]
        public void WhenScore_95_Presence_65_Then_B()
        {
            // Arrange
            var gradingCalculator = new GradingCalculator();
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;

            // Act
            var grade = gradingCalculator.GetGrade();
            // Assert
            Assert.AreEqual('B', grade);
        }

        [TestMethod]
        public void WhenScore_95_Presence_55_Then_F()
        {
            // Arrange
            var gradingCalculator = new GradingCalculator();
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 55;

            // Act
            var grade = gradingCalculator.GetGrade();
            // Assert
            Assert.AreEqual('F', grade);
        }

        [TestMethod]
        public void WhenScore_65_Presence_55_Then_F()
        {
            // Arrange
            var gradingCalculator = new GradingCalculator();
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 55;

            // Act
            var grade = gradingCalculator.GetGrade();
            // Assert
            Assert.AreEqual('F', grade);
        }

        [TestMethod]
        public void WhenScore_50_Presence_90_Then_F()
        {
            // Arrange
            var gradingCalculator = new GradingCalculator();
            gradingCalculator.Score = 50;
            gradingCalculator.AttendancePercentage = 90;

            // Act
            var grade = gradingCalculator.GetGrade();
            // Assert
            Assert.AreEqual('F', grade);
        }
    }
}
﻿using API.Controllers;
using BusinessLogic.Models;
using DataAccess.Repositories;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTests
{
    [TestClass]
    public class CourseValidatorTests
    {
        private readonly CourseValidator _validator;
        private readonly InstanceCreator _instanceCreator;
        private readonly CourseVisualizer _visualizer;

        public CourseValidatorTests()
        {
            _validator = new CourseValidator();
            _instanceCreator = new InstanceCreator();
            _visualizer = new CourseVisualizer();
        }



        [TestMethod]
        public void TestValidateLengthOfExerciseListTrue()
        {
            // Arrange
            Course course = _instanceCreator.CreateBeginnerCourse();

            // Act
            bool result = _validator.ValidateLengthOfExerciseList(course);

            // Assert
            Assert.IsTrue(result);
        }



        [TestMethod]
        public void TestValidateLenghtOfExerciseListFalse()
        {
            // Arrange
            Course course = new Course(LevelEnum.Expert);

            Exercise nullExercise = new Exercise(1, "", "", DefaultHandlingPositionEnum.Left, false, false, null, null);
            for (int i = 1; i <= 7; i++)
            {
                course.ExerciseList.Add(nullExercise);
            }

            // Act
            bool result = _validator.ValidateLengthOfExerciseList(course);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestValidateRightHandlingOnlyBetweenTwoChangesOfPositions() 
        {
            //Arrange
            Course course = _instanceCreator.CreateBeginnerCourse();
            DefaultHandlingPositionEnum startPosition = DefaultHandlingPositionEnum.Left;  
            List<(int, int, string, bool)> visualizedCourse = _visualizer.VisualiseCourse(course, startPosition );
            List<(int, int, string, bool)> rightHandledexerises = _visualizer.VisualiseRightHandledExercises(visualizedCourse);

            //Act
            bool result = _validator.ValidateRightHandlingOnlyBetweenTwoChangesOfPositions(rightHandledexerises, course);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidateMaxNumberOfRepeatedRightHandledExercisesExpertTrue() 
        {
            //Arrange
            Course course = _instanceCreator.CreateExpertCourseWithTwoRightHandledExercises();
            DefaultHandlingPositionEnum startPosition = DefaultHandlingPositionEnum.Left;
            List<(int, int, string, bool)> visualizedCourse = _visualizer.VisualiseCourse(course, startPosition);
            List<(int, int, string, bool)> rightHandledexerises = _visualizer.VisualiseRightHandledExercises(visualizedCourse);

            //Act
            bool result = _validator.ValidateMaxNumberOfRepeatedRightHandledExercises(rightHandledexerises, course, startPosition);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidateMaxNumberOfRepeatedRightHandledExercisesExpertFalse()
        {
            //Arrange
            Course course = _instanceCreator.CreateExpertCourseWithThreeRightHandledExercises();
            DefaultHandlingPositionEnum startPosition = DefaultHandlingPositionEnum.Left;
            List<(int, int, string, bool)> visualizedCourse = _visualizer.VisualiseCourse(course, startPosition);
            List<(int, int, string, bool)> rightHandledexerises = _visualizer.VisualiseRightHandledExercises(visualizedCourse);

            //Act
            bool result = _validator.ValidateMaxNumberOfRepeatedRightHandledExercises(rightHandledexerises, course, startPosition);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestValidateMaxNumberOfRepeatedRightHandledExercisesChampionTrue()
        {
            //Arrange
            Course course = _instanceCreator.CreateChampionCourseWithThreeRightHandledExercises();
            DefaultHandlingPositionEnum startPosition = DefaultHandlingPositionEnum.Left;
            List<(int, int, string, bool)> visualizedCourse = _visualizer.VisualiseCourse(course, startPosition);
            List<(int, int, string, bool)> rightHandledexerises = _visualizer.VisualiseRightHandledExercises(visualizedCourse);

            //Act
            bool result = _validator.ValidateMaxNumberOfRepeatedRightHandledExercises(rightHandledexerises, course, startPosition);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidateMaxNumberOfRepeatedRightHandledExercisesChampionFalse()
        {
            //Arrange
            Course course = _instanceCreator.CreateChampionCourseWithFourRightHandledExercises();
            DefaultHandlingPositionEnum startPosition = DefaultHandlingPositionEnum.Left;
            List<(int, int, string, bool)> visualizedCourse = _visualizer.VisualiseCourse(course, startPosition);
            List<(int, int, string, bool)> rightHandledexerises = _visualizer.VisualiseRightHandledExercises(visualizedCourse);

            //Act
            bool result = _validator.ValidateMaxNumberOfRepeatedRightHandledExercises(rightHandledexerises, course, startPosition);

            //Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void TestMaxNumberOfStationyExercisesBeginnerTrue() 
        {
            //Arrange
            Course course = _instanceCreator.CreateBeginnerCourse();

            //Act
            bool result = _validator.ValidateMaxNumberOfStationaryExercises(course);

            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void TestMaxNumberOfStationyExercisesExpertFalse()
        {
            //Arrange
            Course course = _instanceCreator.CreateExpertCourseWithThreeRightHandledExercises();

            //Act
            bool result = _validator.ValidateMaxNumberOfStationaryExercises(course);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMaxNumberOfExercisesWithConeTrue()
        {
            //Arrange
            Course course = _instanceCreator.CreateExpertCourseWithThreeRightHandledExercises();

            //Act
            bool result = _validator.ValidateMaxNumberOfExercisesWithCone(course);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMaxNumberOfExercisesWithConeFalse()
        {
            //Arrange
            Course course = _instanceCreator.CreateChampionCourseWithFourRightHandledExercises();

            //Act
            bool result = _validator.ValidateMaxNumberOfExercisesWithCone(course);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMaxNumberOfExercisesInNonTypicalSpeedTrue() 
        {
            //Arrange
            Course course = _instanceCreator.CreateExpertCourseWithTwoRightHandledExercises();

            //Act
            bool result = _validator.ValidateMaxNumberOfExercisesInNonTypicalSpeed(course);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMaxNumberOfExercisesInNonTypicalSpeedFalse()
        {
            //Arrange
            Course course = _instanceCreator.CreateChampionCourseWithThreeRightHandledExercises();

            //Act
            bool result = _validator.ValidateMaxNumberOfExercisesInNonTypicalSpeed(course);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestValidateNumberOfRightHandletExercisesTrue() 
        {
            //Arrange
            Course course = _instanceCreator.CreateChampionCourseWithThreeRightHandledExercises();
            DefaultHandlingPositionEnum startPosition = DefaultHandlingPositionEnum.Right;
            List<(int, int, string, bool)> visualizedCourse = _visualizer.VisualiseCourse(course, startPosition);
            int min = course.GetMinNumberOfRightHandledExercises(course.Level);
            int max = course.GetMaxNumberOfRightHandledExercises(course.Level);
            List<(int, int, string, bool)> rightHandletExercises = visualizedCourse.Where(x => x.Item4 == false).ToList();

            //Act
            int countOfRightHandletExercises = rightHandletExercises.Count();
            bool result = countOfRightHandletExercises <= max && countOfRightHandletExercises >= min;

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidateNumberOfRightHandletExercisesFalse()
        {
            //Arrange
            Course course = _instanceCreator.CreateChampionCourseWithThreeRightHandledExercises();
            DefaultHandlingPositionEnum startPosition = DefaultHandlingPositionEnum.Right;
            List<(int, int, string, bool)> visualizedCourse = _visualizer.VisualiseCourse(course, startPosition);
            int min = course.GetMinNumberOfRightHandledExercises(course.Level);
            int max = course.GetMaxNumberOfRightHandledExercises(course.Level);
            List<(int, int, string, bool)> rightHandletExercises = visualizedCourse.Where(x => x.Item4 == false).ToList();

            //Act
            int countOfRightHandletExercises = rightHandletExercises.Count();
            bool result = countOfRightHandletExercises <= max && countOfRightHandletExercises >= min;

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidateLevelDistributionOfTheExercisesTrue() 
        {
            //Arrange
            Course course = _instanceCreator.CreateChampionCourseWithThreeRightHandledExercises();

            (int, int, int, int, int) min = course.GetMinimalAmountOfExercisesFromAllLevels(course.Level);
            (int, int, int, int, int) max = course.GetMaxAmountOfExercisesFromAllLevels(course.Level);

            //Act
            bool validator = _validator.ValidateLevelDistributionOfTheExercises(course);

            //Assert
            Assert.IsTrue(validator);
        }

        [TestMethod]
        public void TestValidateLevelDistributionOfTheExercisesFalse()
        {
            //Arrange
            Course course = _instanceCreator.CreateExpertCourseWithTwoRightHandledExercises();


            (int, int, int, int, int) min = course.GetMinimalAmountOfExercisesFromAllLevels(course.Level);
            (int, int, int, int, int) max = course.GetMaxAmountOfExercisesFromAllLevels(course.Level);

            //Act
            bool validator = _validator.ValidateLevelDistributionOfTheExercises(course);

            //Assert
            Assert.IsTrue(validator);
        }

        [TestMethod]
        public void TestValidateMaxNumberOfDifferentTypesOfJump() 
        {
            //Arrange
            Course course = _instanceCreator.CreateExpertCourseWithTwoRightHandledExercises();
            (int, int, int) maxOfSingleJumpDoubleJumpAndTotalJump = course.GetMaximunNumberOfDifferentJumps(course.Level);

            //Act
            bool validator = _validator.ValidateMaxNumberOfDifferentTypesOfJump(course);

            //Assert
            Assert.IsTrue(validator);

        }



       


    }
}

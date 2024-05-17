﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class CourseVisualizer
    {
        

        public  List<(int, int, string, bool)> VisualiseCourse(Course course, DefaultHandlingPositionEnum startPosition)
        {
            List<Exercise> newList = course.AssignIndexNumberAndLeftHandletProperties();
            newList[0].ActualHandlingPositionIsLeftHandlet = true;

            if (startPosition == DefaultHandlingPositionEnum.Right)
            {
               newList[0].ActualHandlingPositionIsLeftHandlet = false;
            }


            foreach (Exercise x in newList)
            {
                if(x.IndexNumber > 0 && x.IndexNumber < newList.Count) 
                {
                    x.ActualHandlingPositionIsLeftHandlet = 
                        newList[(x.IndexNumber)].DefaultHandlingPosition != DefaultHandlingPositionEnum.ChangeOfPosition ?
                        newList[x.IndexNumber - 1].ActualHandlingPositionIsLeftHandlet : !newList[(x.IndexNumber - 1)].ActualHandlingPositionIsLeftHandlet;
                }                
            }


            List<(int, int, string, bool)> courseVisualized = new List<(int, int, string, bool)> ();
            courseVisualized.Add((newList[0].ExerciseId, newList[0].IndexNumber, newList[0].Name, newList[0].ActualHandlingPositionIsLeftHandlet));
            courseVisualized.AddRange(newList.Skip(1).Select(x => (x.ExerciseId, x.IndexNumber, x.Name, x.ActualHandlingPositionIsLeftHandlet)).ToList());
            return courseVisualized;
        }

        public List<(int, int, string, jumpEnum?)> VisualiseJumpPropertyForExercise(Course course)
        {
            List<(int, int, string, jumpEnum?)> visualisedJumpExercises = course.ExerciseList.Select(x => 
            (x.ExerciseId, x.Number, x.Name, x.TypeOfJump)).ToList();
            return visualisedJumpExercises;
        }

        public (int, int, int, int, int) VisualiseLevelDistributionOfTheExercises(Course course)
        {
            int countOfBeginnerLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.Beginner);
            int countOfAdvancedLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.Advanced);
            int countOfExpertLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.Expert);
            int countOfChampionLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.Champion);
            int countOfOpeClassLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.OpenClass);
            return (countOfBeginnerLevelExercises, countOfAdvancedLevelExercises, countOfExpertLevelExercises,
                countOfChampionLevelExercises, countOfOpeClassLevelExercises);

        }

            

        public List<(int, int, string, bool)> VisualiseRightHandledExercises(List<(int, int, string, bool)> visualisedCourse)
        {
            List<(int, int, string, bool)> exercisesWithRightHandling = visualisedCourse.Where(item => !item.Item4).ToList();
            return exercisesWithRightHandling;
        }





        
    }
}

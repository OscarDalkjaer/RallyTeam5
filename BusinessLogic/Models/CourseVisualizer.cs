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
        public  List<(int, string, bool)> AssignHandlingPositionsToCourseExercises(Course course, HandlingPositionEnum startPosition)
        {
            List<Exercise> newList = course.AssignIndexNumbers();
            newList[0].LeftHandlet = true;

            if (startPosition == HandlingPositionEnum.Right)
            {
               newList[0].LeftHandlet = false;
            }


            foreach (Exercise x in newList)
            {
                if(x.IndexNumber > 0 && x.IndexNumber < newList.Count) 
                {
                    x.LeftHandlet = newList[(x.IndexNumber - 1)].HandlingPosition != HandlingPositionEnum.ChangeOfPosition ?
                    newList[x.IndexNumber - 1].LeftHandlet : !newList[(x.IndexNumber - 1)].LeftHandlet;
                }                
            }


            List<(int, string, bool)> result = new List<(int, string, bool)> ();
            result.Add((newList[0].ExerciseId, newList[0].Name, newList[0].LeftHandlet));
            result.AddRange(newList.Skip(1).Select(x => (x.ExerciseId, x.Name, x.LeftHandlet)).ToList());
            return result;


            //newList.Select(x => 
            //newList[(x.IndexNumber - 1)].HandlingPosition != HandlingPositionEnum.ChangeOfPosition ?
            //x.LeftHandlet = newList[x.IndexNumber - 1].LeftHandlet
            //: x.LeftHandlet = !newList[(x.IndexNumber - 1)].LeftHandlet);


        }

    }
}

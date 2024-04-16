﻿namespace BusinessLogic.Models
{
    public class Exercise
    {
        

        public Exercise()
        {
        }

        public Exercise(int number,  TypeEnum type)
        {
            
            Number = number;
            Type = type;
        }

        public int ExerciseId { get; private set; }
        public int Number { get; private set; }
       public TypeEnum Type { get; private set; }

        public Exercise(int exerciseId, int number, TypeEnum type)
        {
            ExerciseId = exerciseId;
            Number = number;
            Type = type;
        }
        }
    }

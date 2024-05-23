﻿using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateExerciseViewModel
    {
        public int UpdateExerciseViewModelId { get; set; }
        public int Number { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DefaultHandlingPositionEnum DefaultHandlingPosition { get; private set; }
        public bool Stationary { get; private set; }
        public bool WithCone { get; private set; }
        public jumpEnum? TypeOfJump { get; private set; }
        public LevelEnum? Level { get; private set; }
        

        public UpdateExerciseViewModel(int updateExerciseViewModelId, int number, string name, string description,
            DefaultHandlingPositionEnum defaultHandlingPosition, bool stationary, bool withCone, jumpEnum? typeOfJump, LevelEnum? level)
        {
            UpdateExerciseViewModelId = updateExerciseViewModelId;
            Number = number;
            Name = name;
            Description = description;
            DefaultHandlingPosition = defaultHandlingPosition;
            Stationary = stationary;
            WithCone = withCone;
            TypeOfJump = typeOfJump;
            Level = level;

        }
    }
}
﻿using BusinessLogic.Models;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class AddCourseRequestViewModel
    {
        [Range(1, 5, ErrorMessage = "Tast 1 for begynder, tast 2 for øvet, tast 3 for ekspert, tast 4 for champion, tast 5 for open class")]
        public LevelEnum Level { get; set; }


        public AddCourseRequestViewModel(LevelEnum level)
        {
            Level = level;
        }
    }
}


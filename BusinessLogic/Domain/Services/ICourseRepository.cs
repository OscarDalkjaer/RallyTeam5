﻿using Core.Domain.Entities;

namespace Core.Domain.Services
{
    public interface ICourseRepository
    {
        Task<Course?> AddCourse(Course course);
        Task<Course?> GetCourse(int courseId);
        Task<IEnumerable<Course>> GetAllCourses();
        Task UpdateCourse(Course course);
        Task DeleteCourse(int courseId);
        Task<List<Course>> GetAllCoursesWithSpecifiedTheme(ThemeEnum theme);
        Task<List<Course>> GetAllCoursesWithSpecifiedRangeOfExerciseCount(int rangeLow, int rangeHigh);
    }
}

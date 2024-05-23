﻿using BusinessLogic.Models;
using DataAccess.DataAccessModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessDbContext
{

    public class CourseContext : IdentityDbContext <IdentityUser>
    {
        public CourseContext(DbContextOptions<CourseContext> context) : base(context)
        {
        }

        

        public DbSet<Judge> Judges { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<ExerciseDataAccessModel> ExerciseDataAccessModels { get; set; }
        public DbSet<CourseDataAccessModel> CourseDataAccessModels { get; set; }
        public DbSet<CourseExerciseRelation> CourseExerciseRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
            modelBuilder.Entity<CourseDataAccessModel>()   
                .HasMany(x => x.CourseExerciseRelations);
           
            modelBuilder.Entity<CourseExerciseRelation>()  
                .HasOne(x => x.CourseDataAccessModel);
            
            modelBuilder.Entity<ExerciseDataAccessModel>().HasData(
                new ExerciseDataAccessModel
                {
                    ExerciseDataAccessModelId = 1,
                    Number = 0,                    
                    Name = "",
                    Description ="",
                    HandlingPosition = DefaultHandlingPositionEnum.Optional,
                    Stationary = false,
                    WithCone = false,
                    TypeOfJump = null,
                    Level = null
                },
                new ExerciseDataAccessModel
                {
                    ExerciseDataAccessModelId = 2,
                    Number = 2,
                    Name = "",
                    Description = "",
                    HandlingPosition = DefaultHandlingPositionEnum.Optional,
                    Stationary = false,
                    WithCone = false,
                    TypeOfJump = null,
                    Level = null
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

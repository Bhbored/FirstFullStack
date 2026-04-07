using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Share.Enums;
using Task = TaskFlow.Share.Entities.Task;

namespace TaskFlow.Shared.Entities
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var allTasks = new List<Task>
{
    new Task
    {
        Id = new Guid("a0000001-0000-0000-0000-000000000001"),
        Title = "Complete API Documentation",
        Description = "Write comprehensive documentation for all API endpoints including request/response examples",
        Priority = Priority.Meduim,
        DueDate = new DateTime(2025, 5, 12),
        Status = Status.PENDING,
        CreatedDate = new DateTime(2025, 4, 10)
    },
    new Task
    {
        Id = new Guid("a0000002-0000-0000-0000-000000000002"),
        Title = "Fix Authentication Bug",
        Description = "Resolve the JWT token expiration issue in the login endpoint",
        Priority = Priority.High,
        DueDate = new DateTime(2025, 4, 8),
        Status = Status.PENDING,
        CreatedDate = new DateTime(2025, 4, 7)
    },
    new Task
    {
        Id = new Guid("a0000003-0000-0000-0000-000000000003"),
        Title = "Implement Unit Tests",
        Description = "Add unit tests for the TaskService class with 90% code coverage",
        Priority = Priority.Meduim,
        DueDate = new DateTime(2025, 5, 17),
        Status = Status.PENDING,
        CreatedDate = new DateTime(2025, 4, 11)
    },
    new Task
    {
        Id = new Guid("a0000004-0000-0000-0000-000000000004"),
        Title = "Update NuGet Packages",
        Description = "Update all outdated NuGet packages to latest stable versions",
        Priority = Priority.Low,
        DueDate = new DateTime(2025, 5, 21),
        Status = Status.PENDING,
        CreatedDate = new DateTime(2025, 4, 5)
    },
    new Task
    {
        Id = new Guid("a0000005-0000-0000-0000-000000000005"),
        Title = "Optimize Database Queries",
        Description = "Review and optimize slow-performing database queries",
        Priority = Priority.Meduim,
        DueDate = new DateTime(2025, 5, 10),
        Status = Status.Completed,
        CreatedDate = new DateTime(2025, 3, 31)
    },
    new Task
    {
        Id = new Guid("a0000006-0000-0000-0000-000000000006"),
        Title = "Design New UI Components",
        Description = "Create reusable UI components for the task management dashboard",
        Priority = Priority.Meduim,
        DueDate = new DateTime(2025, 5, 15),
        Status = Status.PENDING,
        CreatedDate = new DateTime(2025, 4, 3)
    },
    new Task
    {
        Id = new Guid("a0000007-0000-0000-0000-000000000007"),
        Title = "Code Review Session",
        Description = "Review pull requests from team members and provide feedback",
        Priority = Priority.Meduim,
        DueDate = new DateTime(2025, 5, 9),
        Status = Status.PENDING,
        CreatedDate = new DateTime(2025, 4, 1)
    },
    new Task
    {
        Id = new Guid("a0000008-0000-0000-0000-000000000008"),
        Title = "Deploy to Production",
        Description = "Deploy latest version to production environment with zero downtime",
        Priority = Priority.Meduim,
        DueDate = new DateTime(2025, 5, 11),
        Status = Status.PENDING,
        CreatedDate = new DateTime(2025, 4, 11)
    },
    new Task
    {
        Id = new Guid("a0000009-0000-0000-0000-000000000009"),
        Title = "Write Release Notes",
        Description = "Document all changes and features for the upcoming v2.0 release",
        Priority = Priority.Low,
        DueDate = new DateTime(2025, 5, 19),
        Status = Status.PENDING,
        CreatedDate = new DateTime(2025, 4, 4)
    },
    new Task
    {
        Id = new Guid("a0000010-0000-0000-0000-000000000010"),
        Title = "Security Audit",
        Description = "Perform security audit and vulnerability assessment",
        Priority = Priority.Meduim,
        DueDate = new DateTime(2025, 5, 13),
        Status = Status.Completed,
        CreatedDate = new DateTime(2025, 3, 28)
    }
};

            foreach (var item in allTasks)
            {
                modelBuilder.Entity<Task>().HasData(item);
            }
        }
    }
}

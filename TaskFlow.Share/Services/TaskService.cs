using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Share.Contracts;
using TaskFlow.Share.DTO.Request;
using TaskFlow.Share.DTO.Response;
using TaskFlow.Share.Enums;
using TaskFlow.Share.Helpers;
using Task = TaskFlow.Share.Entities.Task;

namespace TaskFlow.Shared.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<Task> allTasks;
        public TaskService()
        {

            allTasks = new List<Task>
{
    new Task
    {
        Id = Guid.NewGuid(),
        Title = "Complete API Documentation",
        Description = "Write comprehensive documentation for all API endpoints including request/response examples",
        Priority = Priority.Meduim,
        DueDate = DateTime.Now.AddDays(5),
        Status = Status.PENDING,
        CreatedDate = DateTime.Now.AddDays(-2)
    },
    new Task
    {
        Id = Guid.NewGuid(),
        Title = "Fix Authentication Bug",
        Description = "Resolve the JWT token expiration issue in the login endpoint",
        Priority = Priority.High,
        DueDate = DateTime.Now.AddDays(1),
        Status = Status.PENDING,
        CreatedDate = DateTime.Now.AddDays(-3)
    },
    new Task
    {
        Id = Guid.NewGuid(),
        Title = "Implement Unit Tests",
        Description = "Add unit tests for the TaskService class with 90% code coverage",
        Priority = Priority.Meduim,
        DueDate = DateTime.Now.AddDays(10),
        Status = Status.PENDING,
        CreatedDate = DateTime.Now.AddDays(-1)
    },
    new Task
    {
        Id = Guid.NewGuid(),
        Title = "Update NuGet Packages",
        Description = "Update all outdated NuGet packages to latest stable versions",
        Priority = Priority.Low,
        DueDate = DateTime.Now.AddDays(14),
        Status = Status.PENDING,
        CreatedDate = DateTime.Now.AddDays(-5)
    },
    new Task
    {
        Id = Guid.NewGuid(),
        Title = "Optimize Database Queries",
        Description = "Review and optimize slow-performing database queries",
        Priority = Priority.Meduim,
        DueDate = DateTime.Now.AddDays(3),
        Status = Status.Completed,
        CreatedDate = DateTime.Now.AddDays(-7)
    },
    new Task
    {
        Id = Guid.NewGuid(),
        Title = "Design New UI Components",
        Description = "Create reusable UI components for the task management dashboard",
        Priority = Priority.Meduim,
        DueDate = DateTime.Now.AddDays(8),
        Status = Status.PENDING,
        CreatedDate = DateTime.Now.AddDays(-4)
    },
    new Task
    {
        Id = Guid.NewGuid(),
        Title = "Code Review Session",
        Description = "Review pull requests from team members and provide feedback",
        Priority = Priority.Meduim,
        DueDate = DateTime.Now.AddDays(2),
        Status = Status.PENDING,
        CreatedDate = DateTime.Now.AddDays(-6)
    },
    new Task
    {
        Id = Guid.NewGuid(),
        Title = "Deploy to Production",
        Description = "Deploy latest version to production environment with zero downtime",
        Priority = Priority.Meduim,
        DueDate = DateTime.Now.AddDays(4),
        Status = Status.PENDING,
        CreatedDate = DateTime.Now.AddDays(-1)
    },
    new Task
    {
        Id = Guid.NewGuid(),
        Title = "Write Release Notes",
        Description = "Document all changes and features for the upcoming v2.0 release",
        Priority = Priority.Low,
        DueDate = DateTime.Now.AddDays(12),
        Status = Status.PENDING,
        CreatedDate = DateTime.Now.AddDays(-3)
    },
    new Task
    {
        Id = Guid.NewGuid(),
        Title = "Security Audit",
        Description = "Perform security audit and vulnerability assessment",
        Priority = Priority.Meduim,
        DueDate = DateTime.Now.AddDays(6),
        Status = Status.Completed,
        CreatedDate = DateTime.Now.AddDays(-10)
    }
};
        }
        public TaskResponse? AddTask(TaskAddRequest? addRequest)
        {
            if (addRequest == null) throw new ArgumentNullException(nameof(addRequest));
            ValidationHelpers.ValidateObject(addRequest);
            var tobeadded = addRequest.ToTask();
            tobeadded.Id = Guid.NewGuid();
            tobeadded.CreatedDate = DateTime.Now;
            allTasks.Add(tobeadded);
            return tobeadded.ToTaskResponse();
        }

        public bool DeleteTask(Guid? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var tobedeleted = allTasks.Find(x => x.Id == id);
            if (tobedeleted == null)
                return false;
            else
            {
                allTasks.Remove(tobedeleted);
                return true;
            }
        }

        public List<TaskResponse> GetAllTasks(string? query = null, string? searchBy = null)
        {
            var response = allTasks.ConvertAll(x => x.ToTaskResponse());
            List<TaskResponse> tasks = new();
            if (!string.IsNullOrWhiteSpace(query) && !string.IsNullOrWhiteSpace(searchBy))
            {
                tasks = searchBy switch
                {
                    nameof(TaskResponse.Title) => response.Where(x =>
                        x.Title != null && x.Title.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList(),
                    nameof(TaskResponse.Description) => response.Where(x =>
                        x.Description != null && x.Description.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList(),
                    _ => response.ToList()
                };
                return tasks;
            }
            return response;
        }

        public TaskResponse? GetTaskById(Guid? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var task = allTasks.Find(x => x.Id == id);
            if (task != null)
                return task.ToTaskResponse();
            else throw new ArgumentException(string.Format("No Task Found with that Id", nameof(id)));
        }

        public List<TaskResponse> SortTasks(List<TaskResponse> tasks, string sortBy, SortOption sortOption)
        {
            if (!tasks.Any())
            {
                return tasks;
            }
            List<TaskResponse> taskResponses = new();
            taskResponses = sortBy switch
            {
                nameof(TaskResponse.Title) => sortOption == SortOption.Asc ? tasks.OrderBy(X => X.Title).ToList() : tasks.OrderByDescending(X => X.Title).ToList(),
                nameof(TaskResponse.DueDate) => sortOption == SortOption.Asc ? tasks.OrderBy(x => x.DueDate).ToList() : tasks.OrderByDescending(x => x.DueDate).ToList(),
                nameof(TaskResponse.CreatedDate) => sortOption == SortOption.Asc ? tasks.OrderBy(x => x.CreatedDate).ToList() : tasks.OrderByDescending(x => x.CreatedDate).ToList(),
                nameof(TaskResponse.Priority) => sortOption == SortOption.Asc ? tasks.OrderBy(x => x.Priority).ToList() : tasks.OrderByDescending(x => x.Priority).ToList(),
                nameof(TaskResponse.Status) => sortOption == SortOption.Asc ? tasks.OrderBy(x => x.Status).ToList() : tasks.OrderByDescending(x => x.Status).ToList(),
                _ => tasks
            };
            return taskResponses;
        }

        public TaskResponse? UpdateTask(TaskUpdateRequest? updateRequest)
        {
            if (updateRequest == null) throw new ArgumentNullException(nameof(updateRequest));
            ValidationHelpers.ValidateObject(updateRequest);
            var tobeupdate = allTasks.Find(x => x.Id == updateRequest.Id);
            if (tobeupdate == null)
                throw new ArgumentException(nameof(tobeupdate));
            tobeupdate.Priority = updateRequest.Priority;
            tobeupdate.Status = updateRequest.Status;
            tobeupdate.DueDate = updateRequest.DueDate;
            tobeupdate.Description = updateRequest.Description;
            tobeupdate.Title = updateRequest.Title;
            var index = allTasks.IndexOf(tobeupdate);
            allTasks.RemoveAt(index);
            allTasks.Insert(index, tobeupdate);
            return tobeupdate.ToTaskResponse();
        }
    }
}

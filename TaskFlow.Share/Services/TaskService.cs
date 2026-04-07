
using Microsoft.EntityFrameworkCore;
using TaskFlow.Share.Contracts;
using TaskFlow.Share.DTO.Request;
using TaskFlow.Share.DTO.Response;
using TaskFlow.Share.Enums;
using TaskFlow.Share.Helpers;
using TaskFlow.Shared.Entities;
using Task = TaskFlow.Share.Entities.Task;

namespace TaskFlow.Shared.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskDbContext _db;
        public TaskService(TaskDbContext db)
        {
            _db = db;

        }
        public async Task<TaskResponse?> AddTask(TaskAddRequest? addRequest)
        {
            if (addRequest == null) throw new ArgumentNullException(nameof(addRequest));
            ValidationHelpers.ValidateObject(addRequest);
            var tobeadded = addRequest.ToTask();
            tobeadded.Id = Guid.NewGuid();
            tobeadded.CreatedDate = DateTime.Now;
            await _db.Tasks.AddAsync(tobeadded);
            await _db.SaveChangesAsync();
            return tobeadded.ToTaskResponse();
        }

        public async Task<bool> DeleteTask(Guid? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var allTasks = await _db.Tasks.ToListAsync();
            var tobedeleted = allTasks.Find(x => x.Id == id);
            if (tobedeleted == null)
                return false;
            else
            {
                _db.Tasks.Remove(tobedeleted);
                await _db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<TaskResponse>> GetAllTasks(string? query = null, string? searchBy = null)
        {
            var allTasks = await _db.Tasks.ToListAsync();
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

        public async Task<TaskResponse?> GetTaskById(Guid? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var allTasks = await _db.Tasks.ToListAsync();
            var task = allTasks.Find(x => x.Id == id);
            if (task != null)
                return task.ToTaskResponse();
            else throw new ArgumentException(string.Format("No Task Found with that Id", nameof(id)));
        }

        public async Task<List<TaskResponse>> SortTasks(List<TaskResponse> tasks, string sortBy, SortOption sortOption)
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

        public async Task<TaskResponse?> UpdateTask(TaskUpdateRequest? updateRequest)
        {
            if (updateRequest == null) throw new ArgumentNullException(nameof(updateRequest));
            ValidationHelpers.ValidateObject(updateRequest);
            var tobeupdate = await _db.Tasks.FirstOrDefaultAsync(x => x.Id == updateRequest.Id);
            if (tobeupdate == null)
                throw new ArgumentException(nameof(tobeupdate));
            tobeupdate.Priority = updateRequest.Priority;
            tobeupdate.Status = updateRequest.Status;
            tobeupdate.DueDate = updateRequest.DueDate;
            tobeupdate.Description = updateRequest.Description;
            tobeupdate.Title = updateRequest.Title;
            await _db.SaveChangesAsync();
            return tobeupdate.ToTaskResponse();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Share.DTO.Request;
using TaskFlow.Share.DTO.Response;
using TaskFlow.Share.Enums;

namespace TaskFlow.Share.Contracts
{
    public interface ITaskService
    {
        Task<List<TaskResponse>> GetAllTasks(string? query = null, string? searchBy = null);
        Task<List<TaskResponse>> SortTasks(List<TaskResponse> tasks, string sortBy, SortOption sortOption);
        Task<TaskResponse?> AddTask(TaskAddRequest? addRequest);
        Task<TaskResponse?> UpdateTask(TaskUpdateRequest? updateRequest);
        Task<TaskResponse?> GetTaskById(Guid? id);
        Task<bool> DeleteTask(Guid? id);

    }
}

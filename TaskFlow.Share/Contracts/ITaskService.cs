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
        List<TaskResponse> GetAllTasks(string? query = null, string? searchBy = null);
        List<TaskResponse> SortTasks(List<TaskResponse> tasks, string sortBy, SortOption sortOption);
        TaskResponse? AddTask(TaskAddRequest? addRequest);
        TaskResponse? UpdateTask(TaskUpdateRequest? updateRequest);
        TaskResponse? GetTaskById(Guid? id);
        bool DeleteTask(Guid? id);

    }
}

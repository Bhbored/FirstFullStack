using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Share.DTO.Request;
using TaskFlow.Share.Entities;
using TaskFlow.Share.Enums;
namespace TaskFlow.Share.DTO.Response
{
    public class TaskResponse
    {
        private int daysLeft;

        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority? Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public Status? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int DaysLeft
        {
            get
            {
                if (!DueDate.HasValue)
                    return 0;

                return (int)(DueDate.Value.Date - DateTime.Today).TotalDays;
            }
            set => daysLeft = value;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            if (obj is not TaskResponse other)
                return false;

            return Id == other.Id &&
                   Title == other.Title &&
                   Description == other.Description &&
                   Priority == other.Priority &&
                   DueDate == other.DueDate &&
                   Status == other.Status &&
                   CreatedDate == other.CreatedDate;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Entities.Task ToTask()
        {
            return new Entities.Task()
            {
                Id = Id,
                Title = Title,
                Description = Description,
                Priority = Priority,
                DueDate = DueDate,
                Status = Status,
                CreatedDate = CreatedDate
            };
        }
        public TaskUpdateRequest ToTaskUpdateRequest()
        {
            return new TaskUpdateRequest()
            {
                Title = Title,
                Description = Description,
                Priority = Priority,
                DueDate = DueDate,
                Status = Status,
            };
        }
    }

    public static class TaskResponseExtension
    {

        public static TaskResponse ToTaskResponse(this Entities.Task task)
        {
            return new TaskResponse()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority,
                DueDate = task.DueDate,
                Status = task.Status,
                CreatedDate = task.CreatedDate
            };
        }
    }
}

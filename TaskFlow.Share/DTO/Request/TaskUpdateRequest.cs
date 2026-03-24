using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;
using TaskFlow.Share.CustomeValidators;
using TaskFlow.Share.Enums;

namespace TaskFlow.Share.DTO.Request
{
    public class TaskUpdateRequest
    {
        [Required(ErrorMessage = "Task Id can't be blank")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "{0} can't be null")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string? Title { get; set; }


        [StringLength(500, ErrorMessage = "{0} should be less than {1}")]
        public string? Description { get; set; }
        public Priority? Priority { get; set; }

        [Required(ErrorMessage = "{0} can't be empty.")]
        [DueDateValidator(ErrorMessage = "{0} must be greater than or equal to today's date.")]
        public DateTime? DueDate { get; set; }
        public Status? Status { get; set; }

        public Entities.Task ToTask()
        {
            return new Entities.Task()
            {
                Id =Id,
                Title = Title,
                Description = Description,
                Priority = Priority,
                DueDate = DueDate,
                Status = Status,
            };
        }
    }
}

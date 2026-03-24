using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskFlow.Share.CustomeValidators;
using TaskFlow.Share.DTO.Response;
using TaskFlow.Share.Enums;

namespace TaskFlow.Share.DTO.Request
{
    public class TaskAddRequest
    {
        private Priority? priority;
        private Status? status;

        [Required(ErrorMessage = "Tilte can't be null")]
        [StringLength( 100, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string? Title { get; set; }

        [StringLength(500, ErrorMessage = "{0} should be less than {1}")]
        public string? Description { get; set; }
        public Priority? Priority
        {
            get
            {
                return priority ?? Enums.Priority.Low;
            }
            set => priority = value;
        }

        [Required(ErrorMessage = "{0} can't be empty")] 
        [DueDateValidator(ErrorMessage = "{0} must be greater than or equal to today's date.")]
        public DateTime? DueDate { get; set; }
        public Status? Status
        {
            get
            {
                return status ?? Enums.Status.PENDING;
            }
            set => status = value;
        }
        public DateTime? CreatedDate { get; set; }
        public Entities.Task ToTask()
        {
            return new Entities.Task()
            {
                Title = Title,
                Description = Description,
                Priority = Priority,
                DueDate = DueDate,
                Status = Status,
                CreatedDate = CreatedDate
            };
        }

    }

}

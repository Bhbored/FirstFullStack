using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TaskFlow.Share.Enums;
using TaskFlow.Shared.Entities;

namespace TaskFlow.Share.Entities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority? Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public Status? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int EstimatedHours { get; set; }
        public Guid? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

    }
}

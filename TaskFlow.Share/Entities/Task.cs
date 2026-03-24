using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Share.Enums;

namespace TaskFlow.Share.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority? Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public Status? Status { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}

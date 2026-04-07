using System;
using System.Collections.Generic;
using System.Text;
using Task = TaskFlow.Share.Entities.Task;
namespace TaskFlow.Shared.Entities
{
    public class Category
    {

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Task>? Tasks { get; set; }
    }
}

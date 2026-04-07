using Microsoft.EntityFrameworkCore;
using TaskFlow.Share.Contracts;
using TaskFlow.Share.DTO.Request;
using TaskFlow.Share.DTO.Response;
using TaskFlow.Shared.Entities;
using TaskFlow.Shared.Services;

namespace TaskFlow.Tests
{
    public class TaskTest
    {
        private readonly ITaskService _taskService;
        public TaskTest()
        {
            _taskService = new TaskService(new TaskDbContext(new DbContextOptionsBuilder<TaskDbContext>().Options));
        }

        #region add tests
        [Fact]
        public async Task AddTask__NullRequest()
        {
            TaskAddRequest? addRequest = null;
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
             {
                 await _taskService.AddTask(addRequest);
             });
        }

        [Fact]
        public async Task AddTask__InvalidProperties()
        {
            TaskAddRequest? addRequest = new()
            {
                Description = "asasasaas"
            };
            await Assert.ThrowsAsync<ArgumentException>(async () =>
             {
                 await _taskService.AddTask(addRequest);
             });
        }

        [Fact]
        public async Task AddTask__Success()
        {
            TaskAddRequest? addRequest = new()
            {
                Title = "Fix Bug in Authentication Module",
                Description = "Resolve the token expiration issue in the JWT authentication middleware.",
                DueDate = DateTime.Now.AddDays(3),
            };
            TaskResponse? expected = await _taskService.AddTask(addRequest);
            var actual = await _taskService.GetAllTasks();
            Assert.Contains(expected, actual);
            Assert.NotNull(expected?.Id);
        }
        #endregion

    }
}

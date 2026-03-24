using TaskFlow.Share.Contracts;
using TaskFlow.Share.DTO.Request;
using TaskFlow.Share.DTO.Response;
using TaskFlow.Shared.Services;

namespace TaskFlow.Tests
{
    public class TaskTest
    {
        private readonly ITaskService _taskService;
        public TaskTest()
        {
            _taskService = new TaskService();
        }

        #region add tests
        [Fact]
        public void AddTask__NullRequest()
        {
            TaskAddRequest? addRequest = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                _taskService.AddTask(addRequest);
            });
        }

        [Fact]
        public void AddTask__InvalidProperties()
        {
            TaskAddRequest? addRequest = new()
            {
                Description = "asasasaas"
            };
            Assert.Throws<ArgumentException>(() =>
            {
                _taskService.AddTask(addRequest);
            });
        }

        [Fact]
        public void AddTask__Success()
        {
            TaskAddRequest? addRequest = new()
            {
                Title = "Fix Bug in Authentication Module",
                Description = "Resolve the token expiration issue in the JWT authentication middleware.",
                DueDate = DateTime.Now.AddDays(3),
            };
            TaskResponse? expected = _taskService.AddTask(addRequest);
            var actual = _taskService.GetAllTasks();
            Assert.Contains(expected, actual);
            Assert.NotNull(expected?.Id);
        }
        #endregion

    }
}

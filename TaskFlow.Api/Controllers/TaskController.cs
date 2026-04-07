using Microsoft.AspNetCore.Mvc;
using TaskFlow.Share.Contracts;
using TaskFlow.Share.DTO.Request;
using TaskFlow.Share.Enums;

namespace TaskFlow.Api.Controllers
{
    [Route("Tasks")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [Route("index")]
        [HttpGet]
        public async Task<IActionResult> GetallTasks(string? sortBy, SortOption sortOption = SortOption.Desc)
        {
            try
            {
                var responses = await _taskService.GetAllTasks();
                if (!string.IsNullOrEmpty(sortBy))
                {
                    responses = await _taskService.SortTasks(responses, sortBy, sortOption);
                }
                return Json(responses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> SearchTasks(string query, string searchBy)
        {
            try
            {
                var responses = await _taskService.GetAllTasks(query, searchBy);
                return Json(responses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("{id:csguid}")]
        [HttpGet]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            try
            {
                var response = await _taskService.GetTaskById(id);
                if (response == null)
                    return NotFound($"No task found with ID: {id}");
                return Json(response);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("delete/{id:csguid}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTaskById(Guid id)
        {
            try
            {
                var done =  await _taskService.DeleteTask(id);
                if (!done)
                    return BadRequest($"No task found with ID: {id}");
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] TaskUpdateRequest updateRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                    return BadRequest(errors);
                }
                var response = await _taskService.UpdateTask(updateRequest);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> addTask([FromBody] TaskAddRequest addRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                    return BadRequest(errors);
                }
                var response = await _taskService.AddTask(addRequest);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

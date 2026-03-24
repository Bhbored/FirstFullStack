using Microsoft.AspNetCore.Mvc;
using TaskFlow.Share.Contracts;
using TaskFlow.Share.DTO.Request;
using TaskFlow.Share.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public IActionResult GetallTasks(string? sortBy, SortOption sortOption = SortOption.Desc)
        {
            try
            {
                var responses = _taskService.GetAllTasks();
                if (!string.IsNullOrEmpty(sortBy))
                {
                    responses = _taskService.SortTasks(responses, sortBy, sortOption);
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
        public IActionResult SearchTasks(string query, string searchBy)
        {
            try
            {
                var responses = _taskService.GetAllTasks(query, searchBy);
                return Json(responses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("{id:csguid}")]
        [HttpGet]
        public IActionResult GetTaskById(Guid id)
        {
            try
            {
                var response = _taskService.GetTaskById(id);
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
        public IActionResult DeleteTaskById(Guid id)
        {
            try
            {
                var done = _taskService.DeleteTask(id);
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
        public IActionResult UpdateTask([FromBody] TaskUpdateRequest updateRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                    return BadRequest(errors);
                }
                var response = _taskService.UpdateTask(updateRequest);
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
        public IActionResult addTask([FromBody] TaskAddRequest addRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                    return BadRequest(errors);
                }
                var response = _taskService.AddTask(addRequest);
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

using Data.Entities.ToDoListDatabase;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListApi.Controllers
{
    public class ToDoListController(
        IGenericRepository<Location> locationRepository,
        IGenericRepository<Layout> layoutRepository,
        IGenericRepository<Data.Entities.ToDoListDatabase.Task> taskRepository,
        IGenericRepository<User> userRepository,
        IGenericRepository<WorkPosition> workPositionRepository
        ) : Controller
    {
        private readonly IGenericRepository<Location> _locationRepository = locationRepository;
        private readonly IGenericRepository<Layout> _layoutRepository = layoutRepository;
        private readonly IGenericRepository<Data.Entities.ToDoListDatabase.Task> _taskRepository = taskRepository;
        private readonly IGenericRepository<User> _userRepository = userRepository;
        private readonly IGenericRepository<WorkPosition> _workPositionRepository = workPositionRepository;

        [HttpGet("LocationList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Location>> RetriveLocationList()
        {
            var locationList = await _locationRepository.ListAllAsync();
            return Ok(locationList);
        }
        [HttpGet("LayoutList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Layout>> RetriveLayoutList()
        {
            var layoutList = await _layoutRepository.ListAllAsync();
            return Ok(layoutList);
        }
        [HttpGet("TaskList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Data.Entities.ToDoListDatabase.Task>> RetriveTaskList()
        {
            var taskList = await _taskRepository.ListAllAsync();
            return Ok(taskList);
        }
        [HttpGet("UserList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> RetriveUserList()
        {
            var userList = await _userRepository.ListAllAsync();
            return Ok(userList);
        }
        [HttpGet("WorkPositionList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<WorkPosition>> RetriveWorkPositionList()
        {
            var workPositionList = await _workPositionRepository.ListAllAsync();
            return Ok(workPositionList);
        }

    }
}

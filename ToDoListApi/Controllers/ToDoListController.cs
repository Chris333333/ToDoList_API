using AutoMapper;
using Data.DTOs;
using Data.Entities.ToDoListDatabase;
using Data.Interfaces;
using Data.Spec.ToDoList;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListApi.Controllers
{
    public class ToDoListController(
        IGenericRepository<Location> locationRepository,
        IGenericRepository<Layout> layoutRepository,
        IGenericRepository<Data.Entities.ToDoListDatabase.Task> taskRepository,
        IGenericRepository<User> userRepository,
        IGenericRepository<WorkPosition> workPositionRepository,
        IMapper mapper
        ) : Controller
    {
        private readonly IGenericRepository<Location> _locationRepository = locationRepository;
        private readonly IGenericRepository<Layout> _layoutRepository = layoutRepository;
        private readonly IGenericRepository<Data.Entities.ToDoListDatabase.Task> _taskRepository = taskRepository;
        private readonly IGenericRepository<User> _userRepository = userRepository;
        private readonly IGenericRepository<WorkPosition> _workPositionRepository = workPositionRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet("LocationList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LocationRetriveDTO>> RetriveLocationList()
        {
            var locationList = await _locationRepository.ListAllAsync();
            var data = _mapper.Map<List<Location>, List<LocationRetriveDTO>>(locationList);
            return Ok(data);
        }
        [HttpGet("LayoutList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LayoutRetriveDTO>> RetriveLayoutList()
        {
            var spec = new LayoutSpec();
            var layoutList = await _layoutRepository.ListAllWithSpecAsync(spec);
            var data = _mapper.Map<List<Layout>, List<LayoutRetriveDTO>>(layoutList);
            return Ok(data);
        }
        [HttpGet("TaskList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TaskRetriveDTO>> RetriveTaskList()
        {
            var spec = new TaskSpec();
            var taskList = await _taskRepository.ListAllWithSpecAsync(spec);
            var data = _mapper.Map<List<Data.Entities.ToDoListDatabase.Task>, List<TaskRetriveDTO>>(taskList);
            return Ok(data);
        }
        [HttpGet("UserList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserRetriveDTO>> RetriveUserList()
        {
            var spec = new UserSpec();
            var userList = await _userRepository.ListAllWithSpecAsync(spec);
            var data = _mapper.Map<List<User>, List<UserRetriveDTO>>(userList);
            return Ok(data);
        }
        [HttpGet("WorkPositionList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<WorkPositionRetriveDTO>> RetriveWorkPositionList()
        {
            var workPositionList = await _workPositionRepository.ListAllAsync();
            var data = _mapper.Map<List<WorkPosition>, List<WorkPositionRetriveDTO>>(workPositionList);
            return Ok(data);
        }

    }
}

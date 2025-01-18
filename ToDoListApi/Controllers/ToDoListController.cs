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
        IMapper mapper,
        ToDoListContext context
        ) : Controller
    {
        private readonly IGenericRepository<Location> _locationRepository = locationRepository;
        private readonly IGenericRepository<Layout> _layoutRepository = layoutRepository;
        private readonly IGenericRepository<Data.Entities.ToDoListDatabase.Task> _taskRepository = taskRepository;
        private readonly IGenericRepository<User> _userRepository = userRepository;
        private readonly IGenericRepository<WorkPosition> _workPositionRepository = workPositionRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ToDoListContext _context = context;

        [HttpGet("LocationList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<LocationRetriveDTO>> RetriveLocationList()
        {
            var locationList = await _locationRepository.ListAllAsync();
            var data = _mapper.Map<List<Location>, List<LocationRetriveDTO>>(locationList);
            if (data == null)
                return NoContent();
            return Ok(data);
        }

        [HttpPost("LocationAdd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LocationRetriveDTO>> CreateLocation([FromBody] LocationDTO locationCreateDTO)
        {
            var locationAdd = _mapper.Map<LocationDTO, Location>(locationCreateDTO);
            await _context.Locations.AddAsync(locationAdd);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("LayoutList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<LayoutRetriveDTO>> RetriveLayoutList()
        {
            var spec = new LayoutSpec();
            var layoutList = await _layoutRepository.ListAllWithSpecAsync(spec);
            var data = _mapper.Map<List<Layout>, List<LayoutRetriveDTO>>(layoutList);
            if (data == null)
                return NoContent();
            return Ok(data);
        }

        [HttpPost("LayoutAdd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AddLayout([FromBody] LayoutAddDTO layoutCreateDTO)
        {
            var layoutAdd = _mapper.Map<LayoutAddDTO, Layout>(layoutCreateDTO);
            await _context.Layouts.AddAsync(layoutAdd);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("TaskList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<TaskRetriveDTO>> RetriveTaskList()
        {
            var spec = new TaskSpec();
            var taskList = await _taskRepository.ListAllWithSpecAsync(spec);
            var data = _mapper.Map<List<Data.Entities.ToDoListDatabase.Task>, List<TaskRetriveDTO>>(taskList);
            if (data == null)
                return NoContent();
            return Ok(data);
        }

        [HttpPost("TaskAdd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AddTask([FromBody] TaskAddDTO taskCreateDTO)
        {
            var taskAdd = _mapper.Map<TaskAddDTO, Data.Entities.ToDoListDatabase.Task>(taskCreateDTO);
            await _context.Tasks.AddAsync(taskAdd);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("UserList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<UserRetriveDTO>> RetriveUserList()
        {
            var spec = new UserSpec();
            var userList = await _userRepository.ListAllWithSpecAsync(spec);
            var data = _mapper.Map<List<User>, List<UserRetriveDTO>>(userList);
            if (data == null)
                return NoContent();
            return Ok(data);
        }

        [HttpPost("UserAdd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AddUser([FromBody] UserAddDTO userCreateDTO)
        {
            var userAdd = _mapper.Map<UserAddDTO, User>(userCreateDTO);
            await _context.Users.AddAsync(userAdd);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("WorkPositionList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<WorkPositionRetriveDTO>> RetriveWorkPositionList()
        {
            var workPositionList = await _workPositionRepository.ListAllAsync();
            var data = _mapper.Map<List<WorkPosition>, List<WorkPositionRetriveDTO>>(workPositionList);
            if (data == null)
                return NoContent();
            return Ok(data);
        }

        [HttpPost("WorkPositionAdd")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AddWorkPositon([FromBody] WorkPositionDTO workPositionCreateDTO)
        {
            var workPositionAdd = _mapper.Map<WorkPositionDTO, WorkPosition>(workPositionCreateDTO);
            await _context.WorkPositions.AddAsync(workPositionAdd);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}

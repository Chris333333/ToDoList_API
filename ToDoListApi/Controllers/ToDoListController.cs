using App.Helpers;
using AutoMapper;
using Data.DTOs;
using Data.Entities.ToDoListDatabase;
using Data.Interfaces;
using Data.Spec;
using Data.Spec.ToDoList;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListApi.Controllers;

public class ToDoListController(
    IGenericRepository<Location> locationRepository,
    IGenericRepository<Layout> layoutRepository,
    IGenericRepository<Ticket> taskRepository,
    IGenericRepository<User> userRepository,
    IGenericRepository<WorkPosition> workPositionRepository,
    IGenericRepository<Comment> commentRepository,
    IMapper mapper,
    ToDoListContext context
    ) : Controller
{
    private readonly IGenericRepository<Location> _locationRepository = locationRepository;
    private readonly IGenericRepository<Layout> _layoutRepository = layoutRepository;
    private readonly IGenericRepository<Ticket> _taskRepository = taskRepository;
    private readonly IGenericRepository<User> _userRepository = userRepository;
    private readonly IGenericRepository<WorkPosition> _workPositionRepository = workPositionRepository;
    private readonly IGenericRepository<Comment> _commentRepository = commentRepository;
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

    [HttpGet("TicketsList")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<TicketRetriveDTO>> RetriveTicketList()
    {
        var spec = new TicketSpec();
        var ticketsList = await _taskRepository.ListAllWithSpecAsync(spec);
        var data = _mapper.Map<List<Ticket>, List<TicketRetriveDTO>>(ticketsList);
        if (data == null)
            return NoContent();
        return Ok(data);
    }

    [HttpPost("TicketAdd")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> AddTicket([FromBody] TicketAddDTO taskCreateDTO)
    {
        var taskAdd = _mapper.Map<TicketAddDTO, Ticket>(taskCreateDTO);
        await _context.Tickets.AddAsync(taskAdd);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch("TicketComplete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CompleteTask([FromBody] int ticketID)
    {
        var ticket = await _context.Tickets.FindAsync(ticketID);
        if (ticket == null)
            return NotFound();
        ticket.IsCompleted = true;
        ticket.CompletedDt = DateTime.Now;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("CommentList/{ticketID}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<Pagination<CommentsForTicketRetriveDTO>>> RetriveCommentList([FromQuery]BaseSpecParams baseSpecParams ,int ticketID)
    {
        var spec = new CommentsTicketSpec(baseSpecParams,ticketID);
        var countSpec = new CommentsTicketCountSpec(baseSpecParams, ticketID);
        var totalItems = await _commentRepository.CountAsync(countSpec);

        var commentList = await _commentRepository.ListAllWithSpecAsync(spec);
        var data = _mapper.Map<List<Comment>, List<CommentsForTicketRetriveDTO>>(commentList);
        if (data == null)
            return NoContent();

        return new Pagination<CommentsForTicketRetriveDTO>(baseSpecParams.PageIndex, baseSpecParams.PageSize, totalItems, data);
    }

    [HttpPost("CommentAdd")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddComment([FromBody] CommentAddDTO commentCreateDTO)
    {
        var user = await _context.Users.FindAsync(commentCreateDTO.UserId);
        if (user == null)
            return BadRequest("There is no user with ID: " + commentCreateDTO.UserId);
        var ticket = await _context.Tickets.FindAsync(commentCreateDTO.TicketId);
        if (ticket == null)
            return BadRequest("There is no ticket with ID: " + commentCreateDTO.TicketId);

        var commentAdd = _mapper.Map<CommentAddDTO, Comment>(commentCreateDTO);
        await _context.Comments.AddAsync(commentAdd);
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

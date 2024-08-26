using Application.UseCases.MyTask.Create;
using Application.UseCases.MyTask.Delete;
using Application.UseCases.MyTask.Find;
using Application.UseCases.MyTask.FindById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Presenters;
using System.Net;

namespace ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        private readonly IMediator _mediator;

        

        public TasksController(ILogger<TasksController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Model.Task task)
        {

            var result = await _mediator.Send(new CreateTaskCommand(task.Name));

            return await Presenter.Do(result, HttpStatusCode.OK);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteTaskCommand(id));

            return await Presenter.Do(result, HttpStatusCode.OK);

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new FindTaskCommand());

            return await Presenter.Do(result, HttpStatusCode.OK);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            var result = await _mediator.Send(new FindTaskByIdCommand(id));

            return await Presenter.Do(result, HttpStatusCode.OK);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Model.Task task)
        {
            var result = await _mediator.Send(new UpdateTaskCommand(id, task));

            return await Presenter.Do(result, HttpStatusCode.OK);
        }
    }
}

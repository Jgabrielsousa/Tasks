using Moq;
using Application.Results;
using Application.UseCases.MyTask.Create;
using Application.UseCases.MyTask.Delete;
using Application.UseCases.MyTask.Find;
using Application.UseCases.MyTask.FindById;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using System.Xml.Linq;

namespace Application.Tests
{
    public class TaskTest
    {
        private readonly Mock<ITaskRepository> _repo = new Mock<ITaskRepository>();
        private const string _name = "Task";
        private const int _id = 1;
        private const bool _done = false;

        public TaskEntity TaskEntity()
            => new TaskEntity() { Name = _name, Id = _id ,Done  = _done };

        #region CreateTask  

        private CreateTaskCommand CreateCommand(string name)
        {
            var command = new CreateTaskCommand();
            command.Name = name;
            return command;
        }

        public async Task<Result> RunCreateTask(CreateTaskCommand command)
        {
            var handler = new CreateTaskHandler(_repo.Object);
            return await handler.Handle(command, new CancellationToken());

        }

        [Fact]
        public async void ShouldCreateTask()
        {

            //Arrange
            var command = CreateCommand(_name);

            //Act
            var obj =
            _repo.Setup(c => c.Add(It.IsAny<TaskEntity>())).Returns(TaskEntity());

            var result = await RunCreateTask(command);

            var checkValue = ((CreateTaskCommand)result.Data).Name;
            //Assertion
            Assert.Equal(checkValue, _name);

        }

        #endregion

        #region FindTask



        public async Task<Result> RunFindTask(FindTaskCommand command)
        {
            var handler = new FindTaskHandler(_repo.Object);
            return await handler.Handle(command, new CancellationToken());

        }

        [Fact]
        public async void ShouldGetTasks()
        {

            //Arrange

            var list = new List<TaskEntity>() { TaskEntity() };

            //Act
            _repo.Setup(c => c.GetAll()).Returns(list);

            var result = await RunFindTask(new FindTaskCommand());
            var checkValue = ((List<TaskEntity>)result.Data).Any();
            //Assertion
            Assert.Equal(checkValue, true);
        }

        #endregion

        #region FindByIdTask



        private FindTaskByIdCommand CreateFindByIdCommand(int id)
        {
            return new FindTaskByIdCommand(id); ;
        }

        public async Task<Result> RunFindByIdTask(FindTaskByIdCommand command)
        {
            var handler = new FindTaskByIdHandler(_repo.Object);
            return await handler.Handle(command, new CancellationToken());

        }

        [Fact]
        public async void ShouldGetTaskById()
        {

            //Arrange
            var command = CreateFindByIdCommand(_id);

            //Act

            _repo.Setup(c => c.Find(It.IsAny<int>())).Returns(TaskEntity());

            var result = await RunFindByIdTask(command);

            var checkValue = ((TaskEntity)result.Data).Id;
            //Assertion
            Assert.Equal(checkValue, _id);

        }

        #endregion


        #region DeleteTask


        public async Task<Result> RunDeleteTask(DeleteTaskCommand command)
        {
            var handler = new DeleteTaskHandler(_repo.Object);
            return await handler.Handle(command, new CancellationToken());

        }

        [Fact]
        public async void ShouldDeleteTask()
        {
            //Arrange
            _repo.Setup(c => c.Find(It.IsAny<int>())).Returns(TaskEntity());

            _repo.Setup(c => c.Remove(It.IsAny<TaskEntity>()));

            //Act
            var result = await RunDeleteTask(new DeleteTaskCommand(_id));
            var checkValue = result.Notifications.Any();

            //Assertion
            Assert.Equal(checkValue, false);
        }
        #endregion
    }
}
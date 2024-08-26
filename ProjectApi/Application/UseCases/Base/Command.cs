using Flunt.Notifications;
using MediatR;
using Application.Results;

namespace Application.UseCases.Base
{
    public abstract class Command<T> : IRequest<Result>
       where T : Command<T>
      , new()
    {
    }
}

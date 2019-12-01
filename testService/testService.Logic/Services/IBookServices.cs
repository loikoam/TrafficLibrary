using testService.Models;

namespace testService.Logic.Services
{
    interface IBookServices
    {
        Book GetById(string id);
    }
}
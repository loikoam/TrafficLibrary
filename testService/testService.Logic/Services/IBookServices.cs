using testService.Models;

namespace testService.Logic.Services
{
    public interface IBookService
    {
        Book GetById(string id);
    }
}
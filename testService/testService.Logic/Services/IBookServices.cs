using System;
using testService.Models;

namespace testService.Logic.Services
{
    public interface IBookService : IDisposable
    {
        Book GetById(string id);
    }
}
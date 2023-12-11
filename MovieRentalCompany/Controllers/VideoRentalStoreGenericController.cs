using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalCompany.Domain.Interfaces.Services;

namespace MovieRentalCompany.Controllers
{
    [Route("api/[controller]")]
    public class VideoRentalStoreGenericController<T,TService> : ControllerBase
        where T : class
        where TService : class
    {
        private readonly IServices<T> _service;

        public VideoRentalStoreGenericController(IServices<T> services)
            => _service = services;

        [HttpGet]
        public async Task<ActionResult> GetAll()
            => Ok(_service.GetAll(null).ToList());

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
            => Ok(_service.GetById(id));
    }
}

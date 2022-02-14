using AutoMapper;
using FilmesAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private AppDbContext _cinemaContext;
        private IMapper _mapper;

        public CinemaController(AppDbContext cinemaContext, IMapper autoMapper)
        {
            this._cinemaContext = cinemaContext;
            this._mapper = autoMapper;
        }

        [HttpGet]
        public IEnumerable RecuperarFilmes()
        {
            return _cinemaContext.Cinemas;
        }
    }
}

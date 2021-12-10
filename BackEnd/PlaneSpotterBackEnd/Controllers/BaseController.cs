using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlaneSpotterBackEnd.Models.Database;
using PlaneSpotterBackEnd.Models.DatabaseContext;
using PlaneSpotterBackEnd.Repository;

namespace PlaneSpotterBackEnd.Controllers
{
    public class BaseController : Controller
    {
        protected readonly DatabaseContext dbContext;
        protected readonly IDataRepositoryWrapper dataWrapper;
        protected readonly IMapper autoMapper;

        public BaseController(DatabaseContext dbContext, IMapper autoMapper, IDataRepositoryWrapper dataWrapper) {
            this.dbContext = dbContext;
            this.autoMapper = autoMapper;
            this.dataWrapper = dataWrapper;
        }
    }
}

using DataAccess;
using DataAccess.Repositories;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    // ExampleController provides API endpoints for Example entities.
    // Uses UnitOfWork to coordinate repository operations and ensure atomicity.
    // The GetAll method retrieves all Example records from the data store.
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;

        public ExampleController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public List<Example> GetAll()
        {
            IExampleRepository e = (IExampleRepository)unitOfWork.GetRepository<Example>();
            return e.GetAll().ToList();
        }
    }
}

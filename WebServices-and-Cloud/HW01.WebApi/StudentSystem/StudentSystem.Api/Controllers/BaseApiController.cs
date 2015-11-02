namespace StudentSystem.Api.Controllers
{
    using System.Web.Http;
    using StudentSystem.Data;

    public abstract class BaseApiController : ApiController
    {
        protected readonly StudentSystemData Data;

        protected BaseApiController()
        {
            var context = new StudentSystemDbContext();
            this.Data = new StudentSystemData(context);
        }
    }
}
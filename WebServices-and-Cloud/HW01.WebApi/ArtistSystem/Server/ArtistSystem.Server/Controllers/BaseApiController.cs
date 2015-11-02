namespace ArtistSystem.Server.Controllers
{
    using System.Web.Http;
    using ArtistSystem.Data;
    using ArtistSystem.Data.Contracts;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
        {
            this.Data = new ArtistSystemData(new ArtistSystemDbContext());
        }

        protected IArtistSystemData Data { get; set; }
    }
}

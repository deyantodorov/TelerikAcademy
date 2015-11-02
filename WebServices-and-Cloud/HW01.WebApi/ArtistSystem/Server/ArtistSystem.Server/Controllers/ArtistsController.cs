using System.Web.Http;

namespace ArtistSystem.Server.Controllers
{
    using System.Linq;
    using System.Web.Http.Cors;
    using ArtistSystem.Models;
    using ArtistSystem.Server.Models.Artists;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    [EnableCors("*", "*", "*")]
    public class ArtistsController : BaseApiController
    {
        public IHttpActionResult Get()
        {
            var result = this.Data
                .Artists
                .All()
                .ProjectTo<ArtistShowResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            if (!this.Data.Artists.All().Any(x => x.Id == id))
            {
                return this.NotFound();
            }

            var result = this.Data
                .Artists
                .All()
                .Where(x => x.Id == id)
                .ProjectTo<ArtistShowResponseModel>()
                .SingleOrDefault();


            return this.Ok(result);
        }

        public IHttpActionResult Post(ArtistAddRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid model state");
            }

            var artist = Mapper.Map<ArtistAddRequestModel, Artist>(model);

            this.Data.Artists.Add(artist);
            this.Data.SaveChanges();

            return this.Ok(artist.Id);
        }

        public IHttpActionResult Put(int id, ArtistAddRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid model state");
            }

            var artist = this.Data.Artists.All().FirstOrDefault(x => x.Id == id);

            if (artist == null)
            {
                return this.NotFound();
            }

            artist.Name = model.Name;
            artist.BirthDate = model.BirthDate;
            artist.Country = model.Country;

            this.Data.Artists.Update(artist);
            this.Data.SaveChanges();

            return this.Ok(artist.Id);
        }

        public IHttpActionResult Delete(int id)
        {
            if (!this.Data.Artists.All().Any(x => x.Id == id))
            {
                return this.NotFound();
            }

            this.Data.Artists.Delete(id);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}

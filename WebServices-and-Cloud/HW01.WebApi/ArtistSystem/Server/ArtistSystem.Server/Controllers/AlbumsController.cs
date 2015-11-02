using System.Web.Http;

namespace ArtistSystem.Server.Controllers
{
    using System.Linq;
    using System.Web.Http.Cors;
    using ArtistSystem.Models;
    using ArtistSystem.Server.Models.Albums;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    [EnableCors("*", "*", "*")]
    public class AlbumsController : BaseApiController
    {
        public IHttpActionResult Get()
        {
            var result = this.Data
                .Albums
                .All()
                .ProjectTo<AlbumShowResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            if (!this.Data.Albums.All().Any(x => x.Id == id))
            {
                return this.NotFound();
            }

            var result = this.Data
                .Albums
                .All()
                .Where(x => x.Id == id)
                .ProjectTo<AlbumShowResponseModel>()
                .SingleOrDefault();


            return this.Ok(result);
        }

        public IHttpActionResult Post(AlbumAddRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid model state");
            }

            var album = Mapper.Map<AlbumAddRequestModel, Album>(model);

            this.Data.Albums.Add(album);
            this.Data.SaveChanges();

            return this.Ok(album.Id);
        }

        public IHttpActionResult Put(int id, AlbumAddRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid model state");
            }

            var album = this.Data.Albums.All().FirstOrDefault(x => x.Id == id);

            if (album == null)
            {
                return this.NotFound();
            }

            album.Title = model.Title;
            album.ReleaseDate = model.ReleaseDate;
            album.Producer = model.Producer;

            this.Data.Albums.Update(album);
            this.Data.SaveChanges();

            return this.Ok(album.Id);
        }

        public IHttpActionResult Delete(int id)
        {
            if (!this.Data.Albums.All().Any(x => x.Id == id))
            {
                return this.NotFound();
            }

            this.Data.Albums.Delete(id);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}

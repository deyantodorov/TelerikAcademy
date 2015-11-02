using System.Web.Http;

namespace ArtistSystem.Server.Controllers
{
    using System.Linq;
    using System.Web.Http.Cors;
    using ArtistSystem.Models;
    using ArtistSystem.Server.Models.Songs;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    [EnableCors("*", "*", "*")]
    public class SongsController : BaseApiController
    {
        public IHttpActionResult Get()
        {
            var result = this.Data
                .Songs
                .All()
                .ProjectTo<SongShowResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            if (!this.Data.Songs.All().Any(x => x.Id == id))
            {
                return this.NotFound();
            }

            var result = this.Data
                .Songs
                .All()
                .Where(x => x.Id == id)
                .ProjectTo<SongShowResponseModel>()
                .SingleOrDefault();


            return this.Ok(result);
        }

        public IHttpActionResult Post(SongAddRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid model state");
            }

            var song = Mapper.Map<SongAddRequestModel, Song>(model);

            this.Data.Songs.Add(song);
            this.Data.SaveChanges();

            return this.Ok(song.Id);
        }

        public IHttpActionResult Put(int id, SongAddRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid model state");
            }

            var song = this.Data.Songs.All().FirstOrDefault(x => x.Id == id);

            if (song == null)
            {
                return this.NotFound();
            }

            song.Title = model.Title;
            song.Year = model.Year;
            song.Genre = model.Genre;

            this.Data.Songs.Update(song);
            this.Data.SaveChanges();

            return this.Ok(song.Id);
        }

        public IHttpActionResult Delete(int id)
        {
            if (!this.Data.Songs.All().Any(x => x.Id == id))
            {
                return this.NotFound();
            }

            this.Data.Songs.Delete(id);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}
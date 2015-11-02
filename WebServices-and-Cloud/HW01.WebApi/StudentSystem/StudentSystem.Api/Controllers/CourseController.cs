namespace StudentSystem.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using StudentSystem.Api.Models;
    using StudentSystem.Models;

    [RoutePrefix("api/course")]
    public class CourseController : BaseApiController
    {
        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get()
        {
            var items = this.Data.Courses.All()
                .Select(x => new CourseModel()
                {
                    Name = x.Name,
                    Description = x.Description
                });

            if (!items.Any())
            {
                return this.NotFound();
            }

            return this.Ok(items);
        }

        [HttpGet]
        [Route("get/{id:Guid}")]
        public IHttpActionResult Get(Guid id)
        {
            var item = this.Data.Courses.GetById(id);

            if (item != null)
            {
                var result = new CourseModel()
                {
                    Name = item.Name,
                    Description = item.Description
                };

                return this.Ok(result);
            }

            return this.NotFound();
        }

        [HttpPost]
        [Route("post")]
        public IHttpActionResult Post(CourseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Incorrect data");
            }

            var item = new Course()
            {
                Name = model.Name,
                Description = model.Description
            };

            this.Data.Courses.Add(item);
            this.Data.SaveChanges();

            return this.Ok("Record added");
        }

        [HttpPut]
        [Route("update/{id:Guid}")]
        public IHttpActionResult Update(Guid id, CourseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid model");
            }

            var item = this.Data.Courses.GetById(id);

            if (item == null)
            {
                return this.NotFound();
            }

            item.Name = model.Name;
            item.Description = model.Description;

            this.Data.Courses.Update(item);
            this.Data.SaveChanges();

            return this.Ok("Updated");
        }

        [HttpDelete]
        [Route("delete/{id:Guid}")]
        public IHttpActionResult Delete(Guid id)
        {
            var item = this.Data.Courses.GetById(id);

            if (item == null)
            {
                return this.NotFound();
            }

            this.Data.Courses.Delete(item);
            this.Data.SaveChanges();

            return this.Ok("Deleted");
        }
    }
}

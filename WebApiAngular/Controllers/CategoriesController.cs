using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiAngular.Models;
using project.Models;
using System.Web.Http.Cors;

namespace WebApiAngular.Controllers
{
    
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Categories
        public IHttpActionResult GetCategorys()
        {
            //var Categorys = db.Categorys.ToList();
            //List<Categories_ProductsDTO> CatS_DTO = new List<Categories_ProductsDTO>();
            //foreach (var Category in Categorys)
            //{
            //    Categories_ProductsDTO Cat = new Categories_ProductsDTO();
            //    Cat.ID = Category.ID;
            //    Cat.CategoryName = Category.CategoryName;
            //    Cat.Description = Category.Description;
            //    Cat.Picture = Category.Picture;
                
            //    foreach (var prd in Category.Products)
            //    {
                    
            //    }

            //}
            return Ok( db.Categorys);
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = db.Categorys.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        [Authorize]
        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.ID)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        [Authorize]
        // POST: api/Categories
        //  [EnableCors("*", "*", "*")]
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categorys.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.ID }, category);
        }
        [Authorize]
        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categorys.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categorys.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }
        [Authorize]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [Authorize]
        private bool CategoryExists(int id)
        {
            return db.Categorys.Count(e => e.ID == id) > 0;
        }
    }
}
using SuperStore_API.Web.Models;
using SuperStore_API.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace SuperStore_API.Web.Controllers
{
    public class UsersController : ApiController
    {
        // 1. create an instance of the UserService
        readonly IUsersService usersService; 

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [Route("api/users/{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            usersService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/users/{id:int}"), HttpPut]
        public HttpResponseMessage Update(int id, UsersUpdateRequest usersUpdateRequest)
        {
            if(usersUpdateRequest == null)
            {
                ModelState.AddModelError("", "no body data");
            }
            else if (id != usersUpdateRequest.Id)
            {
                ModelState.AddModelError("id", "ID in the URL doesnt match the id in the body");
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            usersService.Update(usersUpdateRequest);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/users"), HttpGet]
        public HttpResponseMessage GetAll()
        {

            // 2. call the method on the service instance to get back the list of users
            List<User> users = usersService.GetAll();

            // 3. create a httpresponseMessage and put the list of users into that message
            // 4. return (and profit!)
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [Route("api/users/{userId:int}"), HttpGet]
        public HttpResponseMessage GetById(int userId)
        {
            User user = usersService.GetById(userId);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Route("api/users"), HttpPost]
        public HttpResponseMessage Create(UsersCreateRequest usersCreateRequest)
        {
            // 1. Validate data that came from the client
            if (usersCreateRequest == null)
            {
                ModelState.AddModelError("", "Missing Data");
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            //if the code gets to this point, the code data is present and valid

            // 2. Call the method on the service instance to create the user
            int id = usersService.Create(usersCreateRequest);

            // 3. Create a HttpResponseMessage and put the new user's Id into that message
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}
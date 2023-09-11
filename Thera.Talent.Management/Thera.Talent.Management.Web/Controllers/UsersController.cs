using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Thera.Talent.Management.Web.ExternalService.AppApi.Interfaces;
using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Request;
using Thera.Talent.Management.Web.Models;

namespace Thera.Talent.Management.Web.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IAppApiService _appApiService;

        public UsersController(
            IAppApiService appApiService)
        {
            _appApiService = appApiService;
        }

        // GET: Users
        public async Task<ActionResult> Index()
        {
            try
            {
                var data = await _appApiService.GetUsers(HeaderAuthenticatedRequest);
                List<User> users = new List<User>();

                foreach (var item in data.Users)
                {
                    users.Add(new User
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Email = item.Email,
                        Password = item.Password,
                        Profile = item.Profile
                    });
                }

                return View(users);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { @errorMessage = ex.Message });
            }
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var data = await _appApiService.GetUser(HeaderAuthenticatedRequest, id);
                var result = new User()
                {
                    Id = data.User.Id,
                    Name = data.User.Name,
                    Email = data.User.Email,
                    Password = data.User.Password,
                    Profile = data.User.Profile
                };

                return View(result);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Error", new { @errorMessage = ex.Message });
            }
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ValidateSession();

            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                var request = new CreateUserRequest
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    Profile = user.Profile
                };

                await _appApiService.CreateUser(HeaderAuthenticatedRequest, request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { @errorMessage = ex.Message });
            }
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var data = await _appApiService.GetUser(HeaderAuthenticatedRequest, id);
                var result = new User()
                {
                    Id = data.User.Id,
                    Name = data.User.Name,
                    Email = data.User.Email,
                    Password = data.User.Password,
                    Profile = data.User.Profile
                };

                return View(result);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Error", new { @errorMessage = ex.Message });
            }
        }

        // POST: Users/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, User user)
        {
            try
            {
                var request = new UpdateUserRequest
                {
                    Id = id,
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    Profile = user.Profile
                };

                await _appApiService.UpdateUser(HeaderAuthenticatedRequest, request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { @errorMessage = ex.Message });
            }
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var data = await _appApiService.GetUser(HeaderAuthenticatedRequest, id);
                var result = new User()
                {
                    Id = data.User.Id,
                    Name = data.User.Name,
                    Email = data.User.Email,
                    Password = data.User.Password,
                    Profile = data.User.Profile
                };

                return View(result);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { @errorMessage = ex.Message });
            }
        }

        // POST: Users/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, User user)
        {
            try
            {
                await _appApiService.DeleteUser(HeaderAuthenticatedRequest, id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { @errorMessage = ex.Message });
            }
        }
    }
}
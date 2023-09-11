using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Thera.Talent.Management.Web.Common;
using Thera.Talent.Management.Web.ExternalService.AppApi.Interfaces;
using Thera.Talent.Management.Web.ExternalService.AppApi.Models.Request;

namespace Thera.Talent.Management.Web.Controllers
{
    public class TalentsController : ControllerBase
    {
        private readonly IAppApiService _appApiService;

        public TalentsController(
            IAppApiService appApiService)
        {
            _appApiService = appApiService;
        }

        // GET: Talents
        public async Task<ActionResult> Index()
        {
            try
            {
                var data = await _appApiService.GetTalents(HeaderAuthenticatedRequest);
                List<Models.Talent> talents = new List<Models.Talent>();

                foreach (var item in data.Talents)
                {
                    talents.Add(new Models.Talent
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Email = item.Email,
                        PathFile = item.PathFile,
                        //File = item.File
                    });
                }

                return View(talents);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { @errorMessage = ex.Message });
            }
        }

        // GET: Talents/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var data = await _appApiService.GetTalent(HeaderAuthenticatedRequest, id);
                var result = new Models.Talent()
                {
                    Id = data.Talent.Id,
                    Name = data.Talent.Name,
                    Email = data.Talent.Email,
                    PathFile = data.Talent.PathFile
                };

                return View(result);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { @errorMessage = ex.Message });
            }
        }

        // GET: Talents/Create
        public ActionResult Create()
        {
            ValidateSession();

            return View();
        }

        // POST: Talents/Create
        [HttpPost]
        public async Task<ActionResult> Create(Models.Talent talent)
        {
            try
            {
                if (talent.File.ContentLength > 0)
                {
                    var fileName = System.IO.Path.GetFileName(talent.File.FileName);
                    var pathTemp = System.IO.Path.Combine(Server.MapPath($"~/App_Data/temp"), fileName);
                    var newFile = $"{System.IO.Path.Combine(Server.MapPath($"~/App_Data/uploads"), DateTime.Now.Ticks.ToString())}{Utils.GetExtension(fileName)}";
                    talent.File.SaveAs(pathTemp);
                    System.IO.File.Move(pathTemp, newFile);
                    System.IO.File.Delete(pathTemp);
                    talent.PathFile = newFile;
                }

                var request = new CreateTalentRequest
                {
                    Name = talent.Name,
                    Email = talent.Email,
                    PathFile = talent.PathFile
                };

                await _appApiService.CreateTalent(HeaderAuthenticatedRequest, request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { @errorMessage = ex.Message });
            }
        }

        // GET: Talents/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var data = await _appApiService.GetTalent(HeaderAuthenticatedRequest, id);
                var result = new Models.Talent()
                {
                    Id = data.Talent.Id,
                    Name = data.Talent.Name,
                    Email = data.Talent.Email,
                    PathFile = data.Talent.PathFile
                };

                return View(result);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { @errorMessage = ex.Message });
            }
        }

        // POST: Talents/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Models.Talent talent)
        {
            try
            {
                if (talent.File.ContentLength > 0)
                {
                    var fileName = System.IO.Path.GetFileName(talent.File.FileName);
                    var pathTemp = System.IO.Path.Combine(Server.MapPath($"~/App_Data/temp"), fileName);
                    var newFile = $"{System.IO.Path.Combine(Server.MapPath($"~/App_Data/uploads"), DateTime.Now.Ticks.ToString())}{Utils.GetExtension(fileName)}";
                    talent.File.SaveAs(pathTemp);
                    System.IO.File.Move(pathTemp, newFile);
                    System.IO.File.Delete(pathTemp);
                    talent.PathFile = newFile;
                }

                var request = new UpdateTalentRequest
                {
                    Id = id,
                    Name = talent.Name,
                    Email = talent.Email,
                    PathFile = talent.PathFile
                };

                await _appApiService.UpdateTalent(HeaderAuthenticatedRequest, request);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { @errorMessage = ex.Message });
            }
        }

        // GET: Talents/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var data = await _appApiService.GetTalent(HeaderAuthenticatedRequest, id);
                var result = new Models.Talent()
                {
                    Id = data.Talent.Id,
                    Name = data.Talent.Name,
                    Email = data.Talent.Email,

                    PathFile = data.Talent.PathFile
                };

                return View(result);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { @errorMessage = ex.Message });
            }
        }

        // POST: Talents/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Models.Talent talent)
        {
            try
            {
                await _appApiService.DeleteTalent(HeaderAuthenticatedRequest, id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { @errorMessage = ex.Message });
            }
        }

        public FileResult DownloadFile(string path)
        {
            string contentType = $"application/{Utils.GetExtension(path).Replace(".", "")}";

            return File(path, contentType, $"document{Utils.GetExtension(path)}");
        }
    }
}
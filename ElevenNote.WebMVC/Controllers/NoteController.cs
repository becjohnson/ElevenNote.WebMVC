using ElevenNote.Models.Note;
using ElevenNote.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{
    public class NoteController : Controller
    {
        [Authorize]
        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            return service;
        }
        // GET: Note
        public ActionResult Index()
        {   var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            var model = new NoteListItem[0];
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(NoteCreate model)
        {
            if (ModelState.IsValid) return View(model);
            var service = CreateNoteService();
            if (service.CreateNote(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateNoteService();
            var model = svc.GetNoteById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateNoteService();
            var detail = service.GetNoteById(id);
            var model =
                new NoteEdit
                {
                    NoteId = detail.NoteId,
                    Title = detail.Title,
                    Content = detail.Content,
                };
            return View(model);
        }
    }
}
﻿using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Geres4U.Data;
using Geres4U.Data.DataModels;
using Geres4U.Models;
using Microsoft.AspNetCore.Mvc;

namespace Geres4U.Controllers
{
    public class ClientController : Controller
    {
        private readonly IDataAccess _db = new DataAccess();
        public string Email { get; set; }
        public IActionResult Index()
        {
            Email = (string) TempData["user"];
            return View();
        }

        public List<PointOfInterest> GetPointsOfInterestOfDB()
        {
            PointOfInterestData pd = new PointOfInterestData(_db);
            List<PointOfInterestDataModel> points = pd.GetPointsOfInterest().Result;
            List<PointOfInterest> ans = new List<PointOfInterest>();
            if (points.Count > 0)
            {
                PointOfInterestCategoryData pcd = new PointOfInterestCategoryData(_db);
                foreach (PointOfInterestDataModel pdm in points)
                {
                    List<CategoryDataModel> cats = pcd.getCategoriesFromPointOfInterest(pdm.ID);
                    PointOfInterest p = new PointOfInterest(pdm.ID, pdm.Name, pdm.Images, pdm.Lat, pdm.Long, pdm.isSugestion == 1, pdm.Description);
                    if (cats.Count > 0)
                    {
                        List<Category> cat = new List<Category>();
                        foreach (CategoryDataModel cdm in cats)
                        {
                            cat.Add(new Category(cdm.ID, cdm.Name));
                        }

                        foreach (Category c in cat)
                        {
                            p.addCategory(c);
                        }
                    }
                    ans.Add(p);
                }
            }
            return ans;
        }

        public IActionResult GetPointsOfInterest()
        {
            List<PointOfInterest> ans = GetPointsOfInterestOfDB();

            return View(ans);
        }

        public IActionResult GetSpecificPointOfInterest()
        {
            ViewBag.Message = "Point of Interest";
            return View();
        }

        public PointOfInterest GetSpecificPointOfInterestDB(int id)
        {
            PointOfInterestData pd = new PointOfInterestData(_db);
            List<PointOfInterestDataModel> points = pd.getPointOfInterest(new PointOfInterestDataModel(id)).Result;
            if (points.Count > 0)
            {
                PointOfInterest ans = new PointOfInterest(); // vai sempre avançar para o for pq count > 0, mas sou obrigado a inicializar aqui senão não dá pra adicionar categorias
                foreach (PointOfInterestDataModel pdm in points)
                {
                    ans = new PointOfInterest(pdm.ID, pdm.Name, pdm.Images, pdm.Lat, pdm.Long, pdm.isSugestion == 1,
                        pdm.Description);
                }
                PointOfInterestCategoryData pcd = new PointOfInterestCategoryData(_db);
                List<CategoryDataModel> cats = pcd.getCategoriesFromPointOfInterest(id);
                foreach (CategoryDataModel c in cats)
                    ans.addCategory(new Category(c.ID, c.Name));
                return ans;
            }

            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetSpecificPointOfInterest(SpecificPointOfInterestQuery p)
        {
            if (ModelState.IsValid)
            {
                PointOfInterest pi = GetSpecificPointOfInterestDB(p.ID);
                return View(pi);
            }

            return View();
        }

        public IActionResult AddPointVisited()
        {
            ViewBag.Message = "Add Point of Interest to History";
            return View();
        }

        public async Task<bool> AddPointVisitedToDB(int id)
        {
            PointOfInterestData pd = new PointOfInterestData(_db);
            List<PointOfInterestDataModel> points = await pd.getPointOfInterest(new PointOfInterestDataModel(id));
            if (points.Count > 0)
            {
                ClientHistoryData chD = new ClientHistoryData(_db);
                await chD.InsertHistory(new ClientHistoryDataModel(Email, id));
                return true;
            }

            return false;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPointVisited(SpecificPointOfInterestQuery p)
        {
            if (ModelState.IsValid)
            {
                bool resultOfOp = AddPointVisitedToDB(p.ID).Result;
                return View(resultOfOp);
            }

            return View();
        }

        public IActionResult RemovePointVisited()
        {
            ViewBag.Message = "Remove Point of Interest of History";
            return View();
        }

        public async Task<bool> removePointVisitedDB(int id)
        {
            bool exists = false;
            ClientHistoryData chD = new ClientHistoryData(_db);
            List<PointOfInterestDataModel> points = chD.getHistoryFromClient(Email);
            foreach (PointOfInterestDataModel point in points)
                if (point.ID == id)
                {
                    exists = true;
                    break;
                }

            if (exists)
            {
                await chD.RemoveHistory(new ClientHistoryDataModel(Email, id));
                return true;
            }

            return false;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemovePointVisited(SpecificPointOfInterestQuery p)
        {
            if (ModelState.IsValid)
            {
                bool resultOfOp = removePointVisitedDB(p.ID).Result;
                return View(resultOfOp);
            }
            return View();
        }

        public List<PointOfInterest> getHistoryFromClient()
        {
            ClientHistoryData chD = new ClientHistoryData(_db);
            List<PointOfInterest> ans = new List<PointOfInterest>();
            List<PointOfInterestDataModel> points = chD.getHistoryFromClient(Email);
            if (points.Count > 0)
            {
                PointOfInterestCategoryData pcd = new PointOfInterestCategoryData(_db);
                foreach (PointOfInterestDataModel pid in points)
                {
                    PointOfInterest p = new PointOfInterest(pid.ID, pid.Name, pid.Images, pid.Lat, pid.Long,
                        pid.isSugestion == 1, pid.Description);
                    List<CategoryDataModel> cats = pcd.getCategoriesFromPointOfInterest(pid.ID);
                    if(cats.Count > 0)
                        foreach (CategoryDataModel cat in cats)
                        {
                            p.addCategory(new Category(cat.ID, cat.Name));
                        }
                    ans.Add(p);
                }

                return ans;
            }

            return null;
        }

        public IActionResult GetPointsVisited()
        {
            List<PointOfInterest> points = getHistoryFromClient();
            return View(points);
        }

        public IActionResult SugestPointOfInterest()
        {
            return View();
        }
    }
}

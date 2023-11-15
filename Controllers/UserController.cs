﻿using Microsoft.AspNetCore.Mvc;
using PFD_GroupA.DAL;
using PFD_GroupA.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics;


namespace PFD_GroupA.Controllers
{
    public class UserController : Controller
    {
        TransactionsDAL transactionsContext = new TransactionsDAL();
        UserKeybindsDAL keybindContext = new UserKeybindsDAL();
		private List<SelectListItem> pageList = new List<SelectListItem>();

		// GET: UserController
		public ActionResult Index()
        {
            /*if ((HttpContext.Session.GetString("AccountType") == null))
            {

            } */
            return View();
        }

        public ActionResult Transfer()
        {
            /*string Object = HttpContext.Session.GetString("AccountObject");
            User AccountObject = JsonSerializer.Deserialize<User>(Object);
			List<Transactions> OutgoingTransactions = transactionsContext.GetSenderTransactions(AccountObject.UserID);
            */
            return View();
        }

        [HttpGet]
        public IActionResult GetKeybindData()
        {
            string kData = HttpContext.Session.GetString("Keybinds");
            return Json(new { myData = kData });
        }

        [HttpGet]
        public ActionResult Keybind()
        {
            UserKeybinds keybinds = keybindContext.GetUserKeybinds("1234");
            return View(keybinds);
        }


        [HttpPost]
        public ActionResult Keybind([FromBody] List<string> keys)
        {
            // Process the received keys
            Console.WriteLine("Keys received: " + string.Join(", ", keys));

            // You can return a response if needed
            return Json(new { success = true, message = "Keys received successfully" });
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Confirmation()
        {
            /*string Object = HttpContext.Session.GetString("AccountObject");
            User AccountObject = JsonSerializer.Deserialize<User>(Object);
			List<Transactions> OutgoingTransactions = transactionsContext.GetSenderTransactions(AccountObject.UserID);
            */
            return View();
        }

        public ActionResult ExecutePython()
        {
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            //python interprater location
            start.FileName = @"C:\Users\Katana\AppData\Local\Microsoft\WindowsApps\python.exe";
            //argument with file name and input parameters
            start.Arguments = string.Format("{ 0} {1} {2}", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pythontest.py"), 5, 10);
            start.UseShellExecute = false;// Do not use OS shell
            start.CreateNoWindow = true; // We don't need new window
            start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
            start.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)
            start.LoadUserProfile = true;
            Console.ReadLine();
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using NewListing.Models;
using NewListing.Models.NHibernate;


namespace NewListing.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var user = session.Query<Users>().ToList(); 
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Users user)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(user);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var user = session.Get<Users>(id);
                return View(user);
            }

        }


        [HttpPost]
        public ActionResult Edit(int id, Users user)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    var usertoUpdate = session.Get<Users>(id);

                    usertoUpdate.username = user.username;
                    usertoUpdate.email = user.email;
                    usertoUpdate.password = user.password;
                    //usertoUpdate.Task = user.Task;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(usertoUpdate);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var user = session.Get<Users>(id);
                return View(user);
            }
        }

        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var user = session.Get<Users>(id);
                return View(user);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, Users user)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(user);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }
    }
}
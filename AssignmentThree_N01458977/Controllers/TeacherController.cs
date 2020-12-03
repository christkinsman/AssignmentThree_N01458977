using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentThree_N01458977.Controllers
{
    public class TeacherController : Controller
    {
        // GET: /Teacher/Index
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns selected teacher name.
        /// <example> 6/Teacher/Show?id=2 </example>
        /// </summary>
        /// <param>?id=2</param>
        /// <return>Selected Teachers name</return>
        public ActionResult Show(int? id)
        {

            Models.Teacher NewTeacher = null;

            if (id == null) NewTeacher = null;
            else
            {
                TeacherDataController controller = new TeacherDataController();
                NewTeacher = controller.ShowTeacher((int)id);
            }

            return View(NewTeacher);
        }


        /// <summary>
        /// Returns list of teacher names from database.
        /// <example> /Teacher/List </example>
        /// </summary>
        /// <param></param>
        /// <return>List of all teacher names</return>
        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();
            ViewBag.ListTeachers = controller.ListTeachers();

            return View();
        }
    }
}
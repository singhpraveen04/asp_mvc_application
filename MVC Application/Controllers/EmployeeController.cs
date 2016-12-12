using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Application.Models;
using MVC_Application.ViewModels;

namespace MVC_Application.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Test
        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }
        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if(ModelState.IsValid)
                    { 
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("CreateEmployee");
                    }
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }

        public ActionResult Index()
        {
            //Employee Business Layer Implementation
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach(Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }

                employeeViewModels.Add(empViewModel);
            }

            employeeListViewModel.Employees = employeeViewModels;
            //employeeListViewModel.UserName = "Admin";

            return View("Index", employeeListViewModel);
            
            //View Bag Implementation
            //Employee emp = new Employee();
            //emp.FirstName = "Praveen";
            //emp.LastName = "Singh";
            //emp.Salary = 3500;

            //ViewBag.EMPLOYEE = emp;
            //return View("MyView");

            //Strongly Typed Views Implementation
            //Employee emp = new Employee();
            //emp.FirstName = "Praveen";
            //emp.LastName = "Singh";
            //emp.Salary = 3500;

            //EmployeeViewModel vmEmp = new EmployeeViewModel();
            //vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
            //vmEmp.Salary = emp.Salary.ToString("C");
            //if(emp.Salary>15000)
            //{
            //    vmEmp.SalaryColor = "yellow";
            //}
            //else
            //{
            //    vmEmp.SalaryColor = "green";
            //}

            //vmEmp.UserName = "Admin";

            //return View("MyView", vmEmp);



        }
    }
}
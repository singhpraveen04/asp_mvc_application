using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Application.DataAccessLayer;

namespace MVC_Application.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees() {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
            //List<Employee> EmpList = new List<Employee>();
            //Employee emp1 = new Employee();
            //emp1.FirstName = "Praveen";
            //emp1.LastName = "Singh";
            //emp1.Salary = 3500;
            //EmpList.Add(emp1);

            //Employee emp2 = new Employee();
            //emp2.FirstName = "Jane";
            //emp2.LastName = "Smith";
            //emp2.Salary = 40000;
            //EmpList.Add(emp2);

            //return EmpList;
        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
    }
}
using System;
using System.Web.Mvc;

namespace WhatsMySalary.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public int GetElapsedTime(int salaryDay)
        {
            int elapsedTime;

            if (salaryDay > DateTime.Today.Day)
            {
                var dif = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) - salaryDay;

                elapsedTime = (DateTime.Now.Day * 24 * 60 * 60) + (DateTime.Now.Hour * 60 * 60) + (DateTime.Now.Minute * 60) + (DateTime.Now.Second) 
                    + (dif * 24 * 60 * 60);
            }
            else
            {
                elapsedTime = (DateTime.Now.Day * 24 * 60 * 60) + (DateTime.Now.Hour * 60 * 60) + (DateTime.Now.Minute * 60) + (DateTime.Now.Second) 
                    - (salaryDay * 24 * 60 * 60); ;
            }

            return elapsedTime;
        }

        [HttpGet]
        public int GetRemainTime(int salaryDay)
        {
            int remainTime;

            if (salaryDay > DateTime.Today.Day)
            {
                var dif = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) - salaryDay;

                remainTime = (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) * 24 * 60 * 60) 
                    - ((DateTime.Now.Day * 24 * 60 * 60) + (DateTime.Now.Hour * 60 * 60) + (DateTime.Now.Minute * 60) + (DateTime.Now.Second)) 
                    - (dif * 24 * 60 * 60);
            }
            else
            {
                remainTime = (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) * 24 * 60 * 60) 
                    - ((DateTime.Now.Day * 24 * 60 * 60) + (DateTime.Now.Hour * 60 * 60) + (DateTime.Now.Minute * 60) + (DateTime.Now.Second)) 
                    + (salaryDay * 24 * 60 * 60);
            }

            return remainTime;
        }
    }
}
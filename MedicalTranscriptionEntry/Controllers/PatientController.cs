﻿using MedicalTranscriptionEntry.Helper;
using MedicalTranscriptionEntry.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalTranscriptionEntry.Controllers
{
    public class PatientController : Controller
    {
        List<string> Gender;
        List<string> Departments;
        List<string> SubDepartment;

        public PatientController()
        {
            string male = "Male";
            string female = "Female";

            Gender = new List<string>();
            Gender.Add(male);
            Gender.Add(female);

            string dep1 = "Neurology";
            string dep2 = "Emergency";
            string dep3 = "CardioVascular";
            string dep4 = "General";

            Departments = new List<string>();
            Departments.Add(dep1);
            Departments.Add(dep2);
            Departments.Add(dep3);
            Departments.Add(dep4);

            string sDep1 = "Room1";
            string sDep2 = "Room2";
            string sDep3 = "Room3";

            SubDepartment = new List<string>();
            SubDepartment.Add(sDep1);
            SubDepartment.Add(sDep2);
            SubDepartment.Add(sDep3);

        }
        // GET: Patient
        public ActionResult PatientInfo(int? page)
        {
            DataAccessHelper daHlpr = new DataAccessHelper();
            ViewBag.Gender = Gender;
            ViewBag.AllRecords = daHlpr.GetAllData(1, 10,true,false,false,false,false);
            ViewBag.Department = Departments;
            ViewBag.SubDepartment = SubDepartment;
            return View();
        }

        public ActionResult PatientView()
        {
            ViewBag.Gender = Gender;
            ViewBag.Department = Departments;
            ViewBag.SubDepartment = SubDepartment;
            return View();
        }

        [HttpPost]
        public ActionResult PatientView(Patient updatePtData)
        {
            ViewBag.Gender = Gender;
            ViewBag.Department = Departments;
            ViewBag.SubDepartment = SubDepartment;
            return View("EditPatient", updatePtData);
        }

        public ActionResult EditPatient()
        {
            ViewBag.Gender = Gender;
            ViewBag.Department = Departments;
            ViewBag.SubDepartment = SubDepartment;
            return View();
        }

        [HttpPost]
        public ActionResult PatientInfo(Patient P, int? page)
        {
            DataAccessHelper daHlpr = new DataAccessHelper();
            bool isSuccess = daHlpr.SubmitData(P);

            if (isSuccess)
            {
                ViewBag.isSuccess = true;
            }
            else
            {
                ViewBag.isSuccess = false;
            }
            ViewBag.Name = P.Name;
            ViewBag.Gender = Gender;
            ViewBag.Department = Departments;
            ViewBag.SubDepartment = SubDepartment;
            ViewBag.AllRecords = daHlpr.GetAllData(1, 10,true, false, false, false, false);
            if (ModelState.IsValid)
            {
                ModelState.Clear();
            }
            return View(new Patient());
        }


        public ActionResult GetAllData(int pageNumber, int recordCount, bool nameSort = false, bool depSort = false, bool ageSort = false, bool subDepSort = false, bool genderSort = false)
        {
            DataAccessHelper daHlpr = new DataAccessHelper();
            var allRecords = daHlpr.GetAllData(pageNumber, recordCount,nameSort,depSort,ageSort,subDepSort,genderSort);

            return new JsonResult()
            {
                Data = new { Message = allRecords, Result = "SUCCESS" },
                MaxJsonLength = Int32.MaxValue
            };
        }

        [HttpPost]
        public ActionResult SearchPatient(string patientName, string patientId)
        {
            DataAccessHelper daHlpr = new DataAccessHelper();
            var allRecords = daHlpr.SearchPatient(patientName, patientId);

            ViewBag.Gender = Gender;
            ViewBag.Department = Departments;
            ViewBag.SubDepartment = SubDepartment;
            if (allRecords == null)
            {
                return new JsonResult()
                {
                    Data = new { Message = false, Result = "FAILED" },
                    MaxJsonLength = Int32.MaxValue
                };
            }
            else
            {
                return new JsonResult()
                {
                    Data = new { Message = allRecords, Result = "SUCCESS" },
                    MaxJsonLength = Int32.MaxValue
                };
            }
        }

        [HttpPost]
        public ActionResult UpdateData(Patient ptInfo)
        {
            DataAccessHelper daHlpr = new DataAccessHelper();
            var updateRecords = daHlpr.UpdateData(ptInfo);

            return new JsonResult()
            {
                Data = new { Message = updateRecords, Result = "SUCCESS" },
                MaxJsonLength = Int32.MaxValue
            };
        }

        [HttpPost]
        public ActionResult DeleteData(int patientId)
        {
            DataAccessHelper daHlpr = new DataAccessHelper();
            var updateRecords = daHlpr.DeleteData(patientId);

            return new JsonResult()
            {
                Data = new { Message = updateRecords, Result = "SUCCESS" },
                MaxJsonLength = Int32.MaxValue
            };
        }


    }


}
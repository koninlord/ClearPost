using ClearPost.Models.Data.FlearanceDbContext;
using ClearPost.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearPost.Models.Services
{
    public class SportsService
    {
        private FlearanceContext _context;
        private StudentService _studentService;

        public SportsService(FlearanceContext context, StudentService studentService)
        {
            _context = context;
            _studentService = studentService;

        }

        public List<SportsViewModel> GetSports()
        {
            try
            {
                List<Sports> sports = _context.Sports.Include(x => x.Student).ToList();
                List<SportsViewModel> viewModel = sports.Select(x => new SportsViewModel
                {
                    SportID=x.SportId,
                    SportsType = x.SportsType,
                    IsOwingKit = x.IsOwingKit,
                    StudentID = x.StudentId,
                    FullName = x.Student.FullName
                }).ToList();


                return viewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SportsViewModel GetSportsDetails(int id)
        {
            try
            {
                Sports sports = _context.Sports
                                        .Where(x => x.SportId == id)
                                       .Include(x => x.Student)
                                        .FirstOrDefault();

                SportsViewModel model = new SportsViewModel
                {
                    SportID = sports.SportId,
                    SportsType = sports.SportsType,
                    IsOwingKit = sports.IsOwingKit,                
                    StudentID = sports.StudentId,
                    FullName = sports.Student.FullName,

                    StudentIndexList = new SelectList(_studentService.GetStudents(), "StudentID", "FullName", sports.SportId),
                    StudentDepartList = new SelectList(_studentService.GetStudents(), "StudentID", "StudentId", sports.SportId)


                };

                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public SportsViewModel Create()
        {
            SportsViewModel model = new SportsViewModel();
            model.StudentIndexList = new SelectList(_studentService.GetStudents(), "StudentID", "FullName");

            return model;
        }

        public bool AddSports(SportsViewModel model)
        {
            try
            {
                Sports sports = new Sports
                {
                    SportId = model.SportID,
                    SportsType = model.SportsType,
                    IsOwingKit = model.IsOwingKit,
                    
                    StudentId = model.StudentID

                };

                _context.Sports.Add(sports);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateSports(SportsViewModel model)
        {
            try
            {
                Sports sports = _context.Sports.Where(x => x.SportId == model.SportID).FirstOrDefault();
                sports.SportId = model.SportID;
                sports.SportsType = model.SportsType;
                sports.IsOwingKit = model.IsOwingKit;
                sports.StudentId = model.StudentID;

                _context.Sports.Update(sports);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteSports(int id)
        {
            try
            {
                Sports sports = _context.Sports.Where(x => x.SportId == id).FirstOrDefault();


                _context.Sports.Remove(sports);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

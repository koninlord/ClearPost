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
    public class HallService
    {
        private FlearanceContext _context;
        private StudentService _studentService;

        public HallService(FlearanceContext context, StudentService studentService)
        {
            _context = context;
            _studentService = studentService;

        }

        public List<HallViewModel> GetHalls()
        {
            try
            {
                List<Halls> halls = _context.Halls.Include(x => x.Student).ToList();
                List<HallViewModel> viewModel = halls.Select(x => new HallViewModel
                {
                    HallID = x.HallId,
                    HallName = x.HallName,
                    KeyReturned = x.KeyReturned,
                    IsOwing = x.IsOwing,
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
    

        public HallViewModel GetHallDetails(int id)
        {
            try
            {
                Halls halls = _context.Halls
                                        .Where(x => x.HallId == id)
                                       .Include(x => x.Student)
                                        .FirstOrDefault();

                HallViewModel model = new HallViewModel
                {
                    HallID = halls.HallId,
                    HallName = halls.HallName,
                    KeyReturned = halls.KeyReturned,
                    IsOwing = halls.IsOwing,
                    StudentID = halls.StudentId,
                    FullName = halls.Student.FullName,

                    StudentIndexList = new SelectList(_studentService.GetStudents(), "StudentID", "FullName", halls.HallId),
                   // StudentDepartList = new SelectList(_studentService.GetStudents(), "StudentID", "StudentId", fees.FeeId)


                };

                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public HallViewModel Create()
        {
            HallViewModel model = new HallViewModel();
            model.StudentIndexList = new SelectList(_studentService.GetStudents(), "StudentID", "FullName");

            return model;
        }

        public bool AddHalls(HallViewModel model)
        {
            try
            {
                Halls halls = new Halls
                {
                  
                    HallId= model.HallID,
                    HallName = model.HallName,
                    KeyReturned = model.KeyReturned,
                    IsOwing = model.IsOwing,
                    StudentId = model.StudentID
                };

                _context.Halls.Add(halls);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateHalls(HallViewModel model)
        {
            try
            {
                Halls halls = _context.Halls.Where(x => x.HallId == model.HallID).FirstOrDefault();

                halls.HallId = model.HallID;
                halls.HallName = model.HallName;
                halls.KeyReturned = model.KeyReturned;
                halls.IsOwing = model.IsOwing;
                halls.StudentId = model.StudentID;

                _context.Halls.Update(halls);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteHalls(int id)
        {
            try
            {
                Halls halls = _context.Halls.Where(x => x.HallId == id).FirstOrDefault();


                _context.Halls.Remove(halls);
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

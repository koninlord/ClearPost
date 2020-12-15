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
    public class FeesService
    {
        private FlearanceContext _context;
        private StudentService _studentService;

        public FeesService(FlearanceContext context, StudentService studentService)
        {
            _context = context;
            _studentService = studentService;

        }

        public List<FeesViewModel> GetFees()
        {
            try
            {
                List<Fees> fees = _context.Fees.Include(x => x.Student).ToList();
                List<FeesViewModel> viewModel = fees.Select(x => new FeesViewModel
                {
                    FeeID = x.FeeId,
                    FeeAmount = x.FeeAmount,
                    IsOwing = x.IsOwing,
                    AmountPaid = x.AmountPaid,
                    AmountOwing = x.AmountOwing,
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

        public FeesViewModel GetFeeDetails(int id)
        {
            try
            {
                Fees fees = _context.Fees
                                        .Where(x => x.FeeId == id)
                                       .Include(x => x.Student)
                                        .FirstOrDefault();

                FeesViewModel model = new FeesViewModel
                {
                    FeeID = fees.FeeId,
                    FeeAmount = fees.FeeAmount,
                    IsOwing = fees.IsOwing,
                    AmountPaid = fees.AmountPaid,
                    AmountOwing = fees.AmountOwing,
                   StudentID = fees.StudentId,
                   FullName = fees.Student.FullName,

                    StudentIndexList = new SelectList(_studentService.GetStudents(), "StudentID", "FullName", fees.FeeId),
                    StudentDepartList = new SelectList(_studentService.GetStudents(), "StudentID", "StudentId", fees.FeeId)


                };

                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public FeesViewModel Create()
        {
            FeesViewModel model = new FeesViewModel();
            model.StudentIndexList = new SelectList(_studentService.GetStudents(), "StudentID", "FullName");
           
            return model;
        }

        public bool AddFees(FeesViewModel model)
        {
            try
            {
                Fees fees = new Fees
                {
                    FeeId = model.FeeID,
                    FeeAmount = model.FeeAmount,
                    IsOwing = model.IsOwing,
                    AmountPaid = model.AmountPaid,
                    AmountOwing=model.AmountOwing,
                    StudentId = model.StudentID

                };

                _context.Fees.Add(fees);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public bool UpdateFees(FeesViewModel model)
        {
            try
            {
                Fees fees = _context.Fees.Where(x => x.FeeId == model.FeeID).FirstOrDefault();
                fees.FeeId = model.FeeID;
                fees.FeeAmount = model.FeeAmount;
                fees.IsOwing = model.IsOwing;
                fees.AmountPaid = model.AmountPaid;
                fees.AmountOwing = model.AmountOwing;
                fees.StudentId = model.StudentID;

         

                _context.Fees.Update(fees);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteFees(int id)
        {
            try
            {
                Fees fees = _context.Fees.Where(x => x.FeeId == id).FirstOrDefault();


                _context.Fees.Remove(fees);
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

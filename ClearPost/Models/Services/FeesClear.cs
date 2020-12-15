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
    public class FeesClear
    {
        private FlearanceContext _context;
        private StudentService _studentService;

        public FeesClear(FlearanceContext context, StudentService studentService)
        {
            _context = context;
            _studentService = studentService;

        }

        public List<FeesViewModel> GetFees()
        {
            try
            {
             
                List<Fees> fees = _context.Fees.Include(x => x.Student).Where(x => x.RecStatus == 'A').ToList();
                List<FeesViewModel> viewModel = fees.Select(x => new FeesViewModel
                {
                    FeeID = x.FeeId,
                    FeeAmount = x.FeeAmount,
                    IsOwing = x.IsOwing,
                    AmountPaid = x.AmountPaid,
                    AmountOwing = x.AmountOwing,
                    StudentID= x.StudentId,
                    FullName = x.Student.FullName,

                }).ToList();


                return viewModel;
            }
            catch (Exception)
            {
                List<FeesViewModel> emptyModel = new List<FeesViewModel>();
                return emptyModel;
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
                    StudentIndexList = new SelectList(_studentService.GetStudents(), "StudentID", "FullName", fees.FeeId)

                };

                return model;

            }
            catch (Exception)
            {
                FeesViewModel emptyModel = new FeesViewModel();
                return emptyModel;
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

using ClearPost.Models.Data.FlearanceDbContext;
using ClearPost.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearPost.Models.Services
{
    public class DepartmentService
    {
        private FlearanceContext _context;

        public DepartmentService(FlearanceContext context)
        {
            _context = context;
        }

        public bool AddDepartment(DepartmentViewModel model)
        {
            try
            {
                Departments departments = new Departments();

                departments.DepartName = model.DepartName;


                _context.Departments.Add(departments);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DepartmentViewModel> GetDepartments()
        {
            try
            {
                var departments = _context.Departments.ToList();

                List<DepartmentViewModel> model = departments.Select(x => new DepartmentViewModel
                {
                   DepartmentID = x.DepartmentId,
                   DepartName = x.DepartName

                }).ToList();

                return model;
            }
            catch (Exception)
            {
                List<DepartmentViewModel> emptyModel = new List<DepartmentViewModel>();
                return emptyModel;
            }
        }

        public DepartmentViewModel GetDepartmentDetails(int id)
        {
            try
            {
                Departments departments = _context.Departments.Where(x => x.DepartmentId == id).First();
        

                DepartmentViewModel model = new DepartmentViewModel
                {
                   DepartmentID = departments.DepartmentId,
                   DepartName = departments.DepartName
                };

                return model;
            }
            catch (Exception)
            {
                DepartmentViewModel emptyModel = new DepartmentViewModel();
                return emptyModel;
            }
        }
        public bool UpdateDepartment(DepartmentViewModel model)
        {
            try
            {
                Departments departments = _context.Departments.Where(x => x.DepartmentId == model.DepartmentID).First();
                departments.DepartName = model.DepartName;
          
                _context.Departments.Update(departments);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveDepartment(int id)
        {
            try
            {
                Departments departments = _context.Departments.Where(x => x.DepartmentId == id).First();

                _context.Departments.Remove(departments);
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

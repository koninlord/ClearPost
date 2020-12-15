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
  
   public class StudentService
    {
        private FlearanceContext _context;
        private DepartmentService _departmentService;

        public StudentService(FlearanceContext context, DepartmentService departmentService)
        {
            _context = context;
            _departmentService = departmentService;

        }
        public List<StudentViewModel> GetStudents()
        {
            try
            {
                List<Student> students = _context.Student.Include(x => x.Department).ToList();
                List<StudentViewModel> viewModel = students.Select(x => new StudentViewModel
                {
                    StudentID = x.StudentId,
                    FullName = x.FullName,
                    Email = x.Email,
                    DepartmentID =x.DepartmentId,
                    DepartName = x.Department.DepartName
            
                }).ToList();


                return viewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public StudentViewModel GetStudentDetails(int id)
        {
            try
            {
                Student student = _context.Student
                                        .Where(x => x.StudentId == id)
                                       .Include(x => x.Department)
                                        .FirstOrDefault();

                StudentViewModel model = new StudentViewModel
                {
                    StudentID = student.StudentId,
                    FullName = student.FullName,
                    Email = student.Email,
                    DepartmentID = student.DepartmentId,
                    DepartName = student.Department.DepartName,
                    DepartList = new SelectList(_departmentService.GetDepartments(), "DepartmentID", "DepartName", student.StudentId)


                };

                return model;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public StudentViewModel Create()
        {
            StudentViewModel model = new StudentViewModel();
            model.DepartList = new SelectList(_departmentService.GetDepartments(), "DepartmentID", "DepartName"); 
            return model;
        }

        public bool AddStudent(StudentViewModel model)
        {
            try
            {
                Student student = new Student
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    DepartmentId = model.DepartmentID

                };

                _context.Student.Add(student);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateStudent(StudentViewModel model)
        {
            try
            {
                Student student = _context.Student.Where(x => x.StudentId == model.StudentID).FirstOrDefault();

                student.FullName = model.FullName;
                student.Email = model.Email;
                student.DepartmentId = model.DepartmentID;

                _context.Student.Update(student);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteStudent(int id)
        {
            try
            {
                Student student = _context.Student.Where(x => x.StudentId == id).FirstOrDefault();
               

                _context.Student.Remove(student);
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

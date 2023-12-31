using Contracts.Models;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CourseService 
    {
        private bool InputCheck(string name,int comission)
        {
            if (name == "")
            {
                throw new Exception("You must complete the name space");
            }
            if (comission < 1)
            {
                throw new Exception("The comission number must be greater than 0");
            }
            return true;
        }
        
        public async Task<Course> CreateAsync(string name,int comission)//TODO Check
        {
            if (!InputCheck(name, comission)) { throw new Exception(); }
            Course course = new Course(name, comission);
            return await DataBase.GetInstance().courseRepository.CreateAsync(course);
            
        }

        public async Task<bool> DeleteAsync(int id, string name, int comission)
        {
            if (!await DataBase.GetInstance().courseRepository.ValidateInfoAsync(id, name, comission))
            { 
                throw new Exception("The input is wrong, please check the info provided"); 
            }
            return await DataBase.GetInstance().courseRepository.DeleteAsync(id);
        }

        public async Task<Course> UpdateAsync(string oldName,int oldComission,string newName,int newComission,int idCourse)//TODO check
        {
            if(!await DataBase.GetInstance().courseRepository.ValidateInfoAsync(idCourse, oldName, oldComission))
            {
                throw new Exception("The input is wrong, please check the info provided");//TODO como le hago llegar eso al usuario?
            }
            if (!InputCheck(newName, newComission)) { throw new Exception(); }
            Course course = new Course(newName, newComission,idCourse);
            return await DataBase.GetInstance().courseRepository.UpdateAsync(course);
            
        }

        public async Task GetStudentCoursesAsync(int idStudent)
        {
            await DataBase.GetInstance().courseRepository.GetStudentCoursesAsync(idStudent);
        }

        public async Task GetProfessorCoursesAsync(int idProfessor)
        {
            await DataBase.GetInstance().courseRepository.GetProfessorCoursesAsync(idProfessor);
        }
    }
}

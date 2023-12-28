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
        public async Task CreateAsync(Course course)//TODO Pasar a pedir datos,hacer chequeos correspondientes
        {
            await DataBase.GetInstance().courseRepository.CreateAsync(course);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return DataBase.GetInstance().courseRepository.DeleteAsync(id);
        }

        public Task<bool> UpdateAsync(Course course)//TODO Pasar a pedir datos
        {
            return DataBase.GetInstance().courseRepository.UpdateAsync(course);
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

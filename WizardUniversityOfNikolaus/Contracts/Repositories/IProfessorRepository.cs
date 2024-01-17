﻿using UniSmart.Contracts.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSmart.Contracts.Repositories
{
    public interface IProfessorRepository
    {
        public Task<Professor> CreateAsync(Professor professor);
        public Task<bool> DeleteAsync(int idProfessor);

        public Task<Professor> UpdateAsync(Professor professor);

        public Task<List<Professor>> GetStudentProfessorsAsync(int idStudent);

        public Task<List<Professor>> GetCourseProfessorsAsync(int idCourse);

        public Task<bool> TakeCourseAsync(int idProfessor, int idCourse);

        public Task<bool> LeaveCourseAsync(int idProfessor, int idCourse);

        public Task<bool> ValidateInfoAsync(int id, string name, int edad);

        public Task<Professor> GetByIdAsync(int idProfessor);

        public Task<bool> CheckPasswordAsync(string user, string password);
    }
}

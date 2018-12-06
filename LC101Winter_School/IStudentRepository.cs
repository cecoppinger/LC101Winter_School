﻿using LC101Winter_School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LC101Winter_School
{
    public interface IStudentRepository
    {
        void Add(Student student);
        void Delete(int studentId);
        List<Student> GetStudents();
        Student GetStudent(int studentId);
    }
}

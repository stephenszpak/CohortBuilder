using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CohortBuilder.DAL;
using CohortBuilder.Models;
using System.Data.Entity;
using System.Linq;

namespace CohortBuilder.Tests.DAL
{
    // testing the database using moq
    [TestClass]
    public class CohortContextTests
    {
        public CohortRepository repo { get; set; }
        public Mock<CohortContext> mockContext { get; set; }
        public List<Cohort> mockCohortList { get; set; }
        public List<Student> mockStudentList { get; set; }
        public List<Instructor> mockInstructorList { get; set; }
        public Mock<DbSet<Cohort>> mockCohortSet { get; set; }
        public Mock<DbSet<Student>> mockStudentSet { get; set; }
        public Mock<DbSet<Instructor>> mockInstructorSet { get; set; }
        public IQueryable<Cohort> queryCohort { get; set; }
        public IQueryable<Student> queryStudent { get; set; }
        public IQueryable<Instructor> queryInstructor { get; set; }

        [TestInitialize]
        public void Setup()
        {
            mockContext = new Mock<CohortContext>();

            mockCohortList = new List<Cohort>();
            mockStudentList = new List<Student>();
            mockInstructorList = new List<Instructor>();
           
            mockCohortSet = new Mock<DbSet<Cohort>>();
            mockStudentSet = new Mock<DbSet<Student>>();
            mockInstructorSet = new Mock<DbSet<Instructor>>();

            repo = new CohortRepository(mockContext.Object);
        }

        public void CreateMockDatabase()
        {
            queryCohort = mockCohortList.AsQueryable();
            queryStudent = mockStudentList.AsQueryable();
            queryInstructor = mockInstructorList.AsQueryable();

            mockCohortSet.As<IQueryable<Cohort>>().Setup(c => c.Provider).Returns(queryCohort.Provider);
            mockCohortSet.As<IQueryable<Cohort>>().Setup(c => c.Expression).Returns(queryCohort.Expression);
            mockCohortSet.As<IQueryable<Cohort>>().Setup(c => c.ElementType).Returns(queryCohort.ElementType);
            mockCohortSet.As<IQueryable<Cohort>>().Setup(c => c.GetEnumerator()).Returns(queryCohort.GetEnumerator());

            mockStudentSet.As<IQueryable<Student>>().Setup(s => s.Provider).Returns(queryStudent.Provider);
            mockStudentSet.As<IQueryable<Student>>().Setup(s => s.Expression).Returns(queryStudent.Expression);
            mockStudentSet.As<IQueryable<Student>>().Setup(s => s.ElementType).Returns(queryStudent.ElementType);
            mockStudentSet.As<IQueryable<Student>>().Setup(s => s.GetEnumerator()).Returns(queryStudent.GetEnumerator());

            mockInstructorSet.As<IQueryable<Instructor>>().Setup(i => i.Provider).Returns(queryInstructor.Provider);
            mockInstructorSet.As<IQueryable<Instructor>>().Setup(i => i.Expression).Returns(queryInstructor.Expression);
            mockInstructorSet.As<IQueryable<Instructor>>().Setup(i => i.ElementType).Returns(queryInstructor.ElementType);
            mockInstructorSet.As<IQueryable<Instructor>>().Setup(i => i.GetEnumerator()).Returns(queryInstructor.GetEnumerator());

            //Add Cohort
            mockCohortSet.Setup(c => c.Add(It.IsAny<Cohort>())).Callback((Cohort cohort) => mockCohortList.Add(cohort));

            //Add Student
            mockStudentSet.Setup(s => s.Add(It.IsAny<Student>())).Callback((Student student) => mockStudentList.Add(student));

            //Add Instructor
            mockInstructorSet.Setup(i => i.Add(It.IsAny<Instructor>())).Callback((Instructor instructor) => mockInstructorList.Add(instructor));

            mockContext.Setup(c => c.Cohort).Returns(mockCohortSet.Object); //Context.Cohort returns a list of cohorts
            mockContext.Setup(s => s.Student).Returns(mockStudentSet.Object); //Context.Student returns a list of students
            mockContext.Setup(i => i.Instructor).Returns(mockInstructorSet.Object); //Context.Instructor returns a list of instructors
        }

        [TestMethod]
        public void EnsureICanCreateAnInstance()
        {
            //Arrange
            var repo = new CohortRepository();

            //Act
            var context = repo.Context;

            //Assert
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void EnsureICanInjectContext()
        {
            //Arrange
            var context = new CohortContext();
            var repo = new CohortRepository(context);

            //Assert
            Assert.IsNotNull(repo.Context);
        }

        [TestMethod]
        public void EnsureICanAddACohort()
        {

        }



    }
}

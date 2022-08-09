﻿namespace FullstackProjectWeek2.DTO
{
    public class StudentsWithEnrollmentsDTO
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public List<EnrollmentDTO> Enrollments { get; set; }
    }
}

using FileService.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Models
{
    public class Score
    {
        public List<Course> Courses { get; set; }

        public Sum Sum { get; set; }
    }

    public class Course
    {
        [CSVSite(0)]
        [Length(4)]
        public string CourseName { get; set; }

        [CSVSite(1)]
        [Length(2)]
        public string ScoreDisplay => Score.ToString();

        public int Score { get; set; }
    }

    public class Sum
    {
        public double AverageScore { get; set; }

        [CSVSite(0)]
        [Length(5)]
        public string AverageScoreDisplay => AverageScore.ToString("N2");
    }
}
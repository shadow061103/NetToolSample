using FileService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileService.Extensions;
using System.IO;

namespace FileService
{
    public class CreateFileService
    {
        public void CreateFile()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var data = GetData();

            var lines = new List<string>();
            foreach (var detail in data.Courses)
            {
                var row = detail.ToCourseString();
                lines.Add(row);
            }
            lines.Add(data.Sum.AverageScoreDisplay);
            var fileString = string.Join("\r\n", lines);
            var stream = fileString.ToStream();

            var fileName = "test.csv";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            File.AppendAllLines(path, lines, Encoding.GetEncoding(950));
        }

        public Score GetData()
        {
            var courses = new List<Course>()
            {
                new Course(){ CourseName="國文",Score=80},
                 new Course(){ CourseName="英文",Score=90},
                  new Course(){ CourseName="數學",Score=85},
            };
            var sum = new Sum
            {
                AverageScore = courses.Average(c => c.Score)
            };
            var file = new Score()
            {
                Courses = courses,
                Sum = sum
            };
            return file;
        }
    }
}
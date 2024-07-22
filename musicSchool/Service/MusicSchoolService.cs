using musicSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static musicSchool.Configuration.AppConfiguration;

namespace musicSchool.Service
{
    internal static class MusicSchoolService
    {
        public static void CreateXmlIfNotExist()
        {
            if (!File.Exists(musicSchoolPath))
            {
                XDocument document = new();  // יצירת קובץ חדש
                XElement musicSchool = new("MusicSchool"); // יצירת אלמנט / אובייקט
                document.Add(musicSchool); // הוספת האלמנט לקובץ
                document.Save(musicSchoolPath); // שמירת הקובץ והשינויים, בנתיב שהוגדר בקופיגורציה
            }
        }

        public static void InsertClassroom(string classroomName)
        {
            XDocument doc = XDocument.Load(musicSchoolPath);
            XElement? musicSchool =
                doc.Descendants("MusicSchool").FirstOrDefault();

            if (musicSchool == null) { return; }

            XElement classroom = new(
                "class-room",
                new XAttribute("Name", classroomName)
                );
            musicSchool.Add(classroom);
            doc.Save(musicSchoolPath);
        }

/*        public static bool IsExistTeacherInClass(string classroomName, string teacherName)
        {
            XDocument doc = XDocument.Load(musicSchoolPath);
            XElement? musicSchool =
                doc.Descendants("MusicSchool").FirstOrDefault();

            if (musicSchool == null) { return; }

            XElement? classroom = musicSchool.Descendants("class-room")
                .FirstOrDefault(element => element.Attribute("Name")?.Value == classroomName);

            if (classroom == null) { return; }
        }*/

        public static void AddTeacher(string classroomName, string teacherName)
        {
            XDocument doc = XDocument.Load(musicSchoolPath);
       
            XElement? classroom = doc.Descendants("class-room")
                .FirstOrDefault(element => element.Attribute("Name")?.Value == classroomName);

            if (classroom == null) { return; }

            XElement teacher = new(
                "Teacher",
                new XAttribute("Name", teacherName)
                );

            classroom.Add(teacher);
            doc.Save(musicSchoolPath);
        }

        public static void AddStudent(string classroomName, string studentName, string instrumentName)
        {
            XDocument? doc = XDocument.Load(musicSchoolPath);

            XElement? classroom = doc.Descendants("class-room")
                .FirstOrDefault(element => element.Attribute("Name")?.Value == classroomName);

            if (classroom == null) { return; }

            XElement student = new(
                "Student", 
                new XAttribute("Name", studentName),
                instrumentName
                );

            classroom.Add(student);
            doc.Save(musicSchoolPath);
        }

        public static void AddManyStudents(string classroomName, params Student[] students)
        {
            XDocument? doc = XDocument.Load(musicSchoolPath);

            XElement? classroom = doc.Descendants("class-room")
                .FirstOrDefault(element => element.Attribute("Name")?.Value == classroomName);

            if (classroom == null) { return; }

            classroom.Add(
                students.Select(student => new XElement(
                "Student",
                new XAttribute("Name", student.Name),
                student.InstrumentName.instrumentName
                )).ToList()
            );

            doc.Save(musicSchoolPath);
        }

        public static void UpDataInstrument(string classroomName, string studentName, string newInstrumentName)
        {
            XDocument? doc = XDocument.Load(musicSchoolPath);

            XElement? classroom = doc.Descendants("class-room")
                .FirstOrDefault(element => element.Attribute("Name")?.Value == classroomName);

            if (classroom == null) { return; }

            XElement? student = classroom.Descendants("Student")
                .FirstOrDefault(element => element.Attribute("Name")?.Value == studentName);

            if (student == null) { return; }

            student.Value = newInstrumentName;

            doc.Save(musicSchoolPath);
        }

        public static void UpDataTeacher(string currentName, string newName)
        {
            XDocument? doc = XDocument.Load(musicSchoolPath);

            XElement? teacher = doc.Descendants("Teacher")
                .FirstOrDefault(e => e.Attribute("Name")?.Value == currentName);

            if (teacher == null) { return; };

            teacher.SetAttributeValue("Name", newName);

            doc.Save(musicSchoolPath);
        }

        public static void ReplaceStudent(Student student)
        {

        }

        private static Student ConvertElementToStudent(XElement studentElement)
        {
            string? name = studentElement.Attribute("Name")?.Value;
            string? instrumentName = studentElement.Value;

            return new Student(name, new Instrument(instrumentName));
        }

        private static XElement ConvertStudentToElement(Student student)
        {
            return new XElement(
                "Student",
                new XAttribute("Name", student.Name),
                student.InstrumentName
                );
        }
    }
}

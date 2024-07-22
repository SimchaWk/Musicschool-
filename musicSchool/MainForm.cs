using System.Linq;
using static musicSchool.Service.Practice;
using static musicSchool.Service.MusicSchoolService;
using musicSchool.Model;

namespace musicSchool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            MusicSchool();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static void MusicSchool()
        {
            CreateXmlIfNotExist();
            // InsertClassroom("Guitar-Jazz");
            // AddTeacher("Guitar-Jazz", "Yosi Levi");
            // AddStudent("Guitar-Jazz", "Enosh", "Guitar");


            Student st1 = new("Avi", new Instrument("Guitar"));
            Student st2 = new("Eli", new Instrument("Piano"));
            Student st3 = new("Zevi", new Instrument("Flute"));

            // AddManyStudents("Guitar-Jazz", st1, st2, st3);

            UpDataInstrument("Guitar-Jazz", "Avi", "Accordion");

            UpDataTeacher("Yosi LeviLevi", "Yosi Levi");
            
        }

        public static void Foo()
        {
            bool a = IsStartWith_a("asd");
            //MessageBox.Show($"{a}");

            List<string> list = ["sdf", "dsf", "iubhn", "asd", ""];

            // MessageBox.Show(list.Join(", ", list));

            bool b = IsAnyStartWith_a(list);
            MessageBox.Show($"{b}", "IsAnyStartWith_a");

            bool c = IsAnyEmptyString(list);
            MessageBox.Show($"{c}", "IsAnyEmptyString");

            bool d = IsAllcontain_a(list);
            MessageBox.Show($"{d}", "IsAllcontain_a");

            List<string> newString = new List<string>(list);
            MessageBox.Show($"{newString}");
            List<string> e = ListToUpper(newString);
            MessageBox.Show($"{e}", "ListToUpper");
        }
    }
}

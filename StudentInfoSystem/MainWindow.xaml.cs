using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Student Inforamtion System";
        }

        private void ClearFields()
        {
            foreach(var item in personalInfoGrid.Children)
            {
                if (item is TextBox)
                    ((TextBox)item).Text = String.Empty;
            }

            foreach (var item in studentInfoGrid.Children)
            {
                if (item is TextBox)
                    ((TextBox)item).Text = String.Empty;
            }
        }

        private StudentRepository.Student SearchStudent(String num)
        {
            foreach (var student in StudentRepository.StudentData.testStudents)
            {
                if (student.facNum == num)
                    return student;//(StudentRepository.Student)
            }
            return null;
        }

        private void EnableFields()
        {
            foreach(var item in personalInfoGrid.Children)
            {
                if (item is TextBox)
                {
                    if (((TextBox)item).IsEnabled == true)
                        ((TextBox)item).IsEnabled = false;
                    else
                        ((TextBox)item).IsEnabled = true;
                }
            }

            foreach (var item in studentInfoGrid.Children)
            {
                if (item is TextBox)
                {
                    if (((TextBox)item).IsEnabled == true)
                        ((TextBox)item).IsEnabled = false;
                    else
                        ((TextBox)item).IsEnabled = true;
                }
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ButtonActivate_Click(object sender, RoutedEventArgs e)
        {
            EnableFields();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            String n = null;
            //n = Convert.ToString(txtFac.Text);
            n = txtFac.Text.ToString();
            //var searchStudent = SearchStudent(n);
            StudentRepository.Student find = StudentRepository.StudentData.testStudents[0];//SearchStudent(n);//StudentRepository.StudentData.isThereStudent(n);
            txtName.Text = find.name;
            txtSecondName.Text = find.secondName;
            txtLastName.Text = find.lastName;
            txtFac.Text = find.faculty;
            txtSpec.Text = find.spec;
            txtOKS.Text = find.eqDegree;
            txtStatus.Text = find.status;
            txtFacNum.Text = find.facNum;
            txtCourse.Text = find.course.ToString();
            txtStream.Text = find.stream.ToString();
            txtGroup.Text = find.group.ToString();

            //String n = (String)txtFac.Text;
            //txtName.Text = StudentRepository.StudentData.isThereStudent(n).name;
            //txtSecondName.Text = StudentRepository.StudentData.isThereStudent(n).secondName;
            //txtLastName.Text = StudentRepository.StudentData.isThereStudent(n).lastName;
            //txtFac.Text = StudentRepository.StudentData.isThereStudent(n).faculty;
            //txtSpec.Text = StudentRepository.StudentData.isThereStudent(n).spec;
            //txtOKS.Text = StudentRepository.StudentData.isThereStudent(n).eqDegree;
            //txtStatus.Text = StudentRepository.StudentData.isThereStudent(n).status;
            //txtCourse.Text = StudentRepository.StudentData.isThereStudent(n).course.ToString();
            //txtStream.Text = StudentRepository.StudentData.isThereStudent(n).stream.ToString();
            //txtGroup.Text = StudentRepository.StudentData.isThereStudent(n).group.ToString();
        }
    }
}

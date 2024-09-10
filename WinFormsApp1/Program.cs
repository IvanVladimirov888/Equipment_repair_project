// �� �� �� 0.2 - ������������� ���������� ����������� �������
// �� ����: ���� �������������� ������������ ������
// ����������: ���������� ���� ���������
// ������: ���-62
// ���� � ����� ������: 30.02.2024 v1.0
// ����: C#
// ������� ��������: ��������� ������������� ��� ������� �������������� ��
//
// �������:
// 1) ������� ������� ����� ����������
// 2) ������� ����� ��� ����������� � ����������� ������������� �������
// 3) ������� ���������������� �����, ��������������� ��������
// ���� ������, c ������������ ���������, ����������, ��������,
// ����������, ������, ���������� ������� � �������� ���� ������
// 4) ������� ����� ��� ���������� ����������� �������
//
// �������������� �����:
// AdminMenuForm, UsersMenuForm, EmployeeMenuForm - ������������� �����
// AdminsProfileForm, EmployeeProfileForm, UsersProfileForm - ����� �������
// UsersProfileAdminForm, EmployeeProfileAdminForm, EditApplicationAdminForm, 
// EditApplicationForm, - ����� ��������������
// ApplicationForm- ����� �������� ������
// ApplicationListForm - ����� ������ ���� ������
// LoginForm - ����� �����������
// RegisterForm - ����� �����������
// StaticticsForm - ����� ����������
// StatusApplicationForm, StatusApplicationEmployeeForm - ����� ������� ������
//
// �������������� ����. ��������:
// Form � �����
// Label - ��������� �������
// Button - ������
// TextBox - ���� �����
// ComboBox - ���������� ������
// DateTimePicker - ���� ������ ���� � �������
// Panel - ������������ �������
// DataGridView - �������
//
// ������ ���� �������� ������ ������ ����������
// �������:
// Initialize - ������������� ������������ ����������
// Run(form: Form) - ������ ���������� 
namespace WinFormsApp1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration. 
	        Application.EnableVisualStyles();
	        Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
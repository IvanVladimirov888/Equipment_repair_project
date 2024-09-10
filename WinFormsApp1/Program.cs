// УП по ПМ 0.2 - Осуществление интеграции программных модулей
// по теме: Учет неисправностей компьютерных систем
// Разработал: Владимиров Иван Сергеевич
// Группа: ТИП-62
// Дата и номер версии: 30.02.2024 v1.0
// Язык: C#
// Краткое описание: программа предназначена для записей неисправностей КС
//
// Задание:
// 1) Создать главную форму приложения
// 2) Создать формы для авторизации и регистрации пользователей системы
// 3) Создать пользовательские формы, соответствующие таблицам
// базы данных, c возможностью просмотра, добавления, удаления,
// обновления, поиска, фильтрации записей в таблицах базы данных
// 4) Создать формы для выполнения вычисляемой функции
//
// Использованные формы:
// AdminMenuForm, UsersMenuForm, EmployeeMenuForm - Навигационные форма
// AdminsProfileForm, EmployeeProfileForm, UsersProfileForm - Формы профиля
// UsersProfileAdminForm, EmployeeProfileAdminForm, EditApplicationAdminForm, 
// EditApplicationForm, - Формы редактирования
// ApplicationForm- Форма создания заявки
// ApplicationListForm - Форма списка всех заявок
// LoginForm - Форма авторизации
// RegisterForm - Форма регистрации
// StaticticsForm - Форма статистики
// StatusApplicationForm, StatusApplicationEmployeeForm - Форма статуса заявки
//
// Использованные граф. элементы:
// Form – Форма
// Label - Текстовый элемент
// Button - кнопка
// TextBox - Поле ввода
// ComboBox - Выпадающий список
// DateTimePicker - Поле выбора даты и времени
// Panel - Группирующий элемент
// DataGridView - таблица
//
// Данный файл является точкой старта приложения
// Функции:
// Initialize - Инициализация конфигурации приложения
// Run(form: Form) - Запуск приложения 
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
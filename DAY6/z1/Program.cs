using System;

delegate bool AccessControl(string username, string password);

class AdminAccess
{
    public bool CheckAccess(string username, string password)
    {
        return username == "admin" && password == "12345";
    }
}

class UserAccess
{
    public bool CheckAccess(string username, string password)
    {
        return username == "user" && password == "54321";
    }
}

class Program
{
    static void Main()
    {
        AdminAccess admin = new AdminAccess();
        UserAccess user = new UserAccess();

        AccessControl access = admin.CheckAccess;
        Console.WriteLine($"Админ: {access("admin", "12345")}");

        access = user.CheckAccess;
        Console.WriteLine($"Пользователь: {access("user", "54321")}");

        access = admin.CheckAccess;
        access += user.CheckAccess;
        Console.WriteLine($"Комбинированная проверка: {access("admin", "12345")}");
    }
}
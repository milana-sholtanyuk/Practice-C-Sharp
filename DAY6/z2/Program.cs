using System;

delegate void AccountManager(int accountId);

class AccountService
{
    public void DeleteAccount(int id) => Console.WriteLine($"Аккаунт {id} удалён");
    public void RestoreAccount(int id) => Console.WriteLine($"Аккаунт {id} восстановлен");
}

class Program
{
    static void ManageAccount(int accountId, AccountManager manager)
    {
        Console.Write($"Обработка аккаунта {accountId}: ");
        manager(accountId);
    }

    static void Main()
    {
        AccountService service = new AccountService();

        ManageAccount(1001, service.DeleteAccount);
        ManageAccount(1002, service.RestoreAccount);
        ManageAccount(1003, id => Console.WriteLine($"Аккаунт {id} заблокирован"));
    }
}
using System;

class StatusChangedEventArgs : EventArgs
{
    public int OrderId { get; set; }
    public string OldStatus { get; set; }
    public string NewStatus { get; set; }
    public StatusChangedEventArgs(int id, string oldStatus, string newStatus)
    {
        OrderId = id;
        OldStatus = oldStatus;
        NewStatus = newStatus;
    }
}

class OrderStatusManager
{
    public event EventHandler<StatusChangedEventArgs> StatusChanged;

    public void ChangeStatus(int orderId, string oldStatus, string newStatus)
    {
        Console.WriteLine($"\nЗаказ {orderId}: {oldStatus} → {newStatus}");
        StatusChanged?.Invoke(this, new StatusChangedEventArgs(orderId, oldStatus, newStatus));
    }
}

class CustomerNotifier
{
    public void OnStatusChanged(object sender, StatusChangedEventArgs e)
    {
        Console.WriteLine($"  Клиент: Статус заказа {e.OrderId} изменён на '{e.NewStatus}'");
    }
}

class AdminLogger
{
    public void OnStatusChanged(object sender, StatusChangedEventArgs e)
    {
        Console.WriteLine($"  Лог: Заказ {e.OrderId} | {e.OldStatus} → {e.NewStatus}");
    }
}

class StatusObserver
{
    public StatusObserver(OrderStatusManager manager, CustomerNotifier customer, AdminLogger logger)
    {
        manager.StatusChanged += customer.OnStatusChanged;
        manager.StatusChanged += logger.OnStatusChanged;
    }
}

class Program
{
    static void Main()
    {
        OrderStatusManager manager = new OrderStatusManager();
        CustomerNotifier customer = new CustomerNotifier();
        AdminLogger logger = new AdminLogger();

        StatusObserver observer = new StatusObserver(manager, customer, logger);

        manager.ChangeStatus(101, "Оформлен", "Оплачен");
        manager.ChangeStatus(102, "Оплачен", "Доставляется");
    }
}
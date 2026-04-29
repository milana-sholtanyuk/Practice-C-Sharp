using System;

interface ICommand
{
    void Execute();
}

class IrrigationSystem
{
    public void StartIrrigation() => Console.WriteLine("💧 Полив ВКЛЮЧЁН");
    public void StopIrrigation() => Console.WriteLine("💧 Полив ВЫКЛЮЧЕН");
}

class StartIrrigationCommand : ICommand
{
    private IrrigationSystem _system;
    public StartIrrigationCommand(IrrigationSystem system) => _system = system;
    public void Execute() => _system.StartIrrigation();
}

class StopIrrigationCommand : ICommand
{
    private IrrigationSystem _system;
    public StopIrrigationCommand(IrrigationSystem system) => _system = system;
    public void Execute() => _system.StopIrrigation();
}

class IrrigationController
{
    private ICommand _command;

    public void SetCommand(ICommand command) => _command = command;
    public void PressButton() => _command?.Execute();
}

class Program
{
    static void Main()
    {
        IrrigationSystem system = new IrrigationSystem();
        IrrigationController controller = new IrrigationController();

        controller.SetCommand(new StartIrrigationCommand(system));
        controller.PressButton();

        controller.SetCommand(new StopIrrigationCommand(system));
        controller.PressButton();
    }
}
using System;
using System.Text;

interface IDataProcessor
{
    string ProcessData(string data);
}

class BasicDataProcessor : IDataProcessor
{
    public string ProcessData(string data) => data;
}

abstract class DataProcessorDecorator : IDataProcessor
{
    protected IDataProcessor _processor;
    public DataProcessorDecorator(IDataProcessor processor) => _processor = processor;
    public virtual string ProcessData(string data) => _processor.ProcessData(data);
}

class EncryptionDecorator : DataProcessorDecorator
{
    public EncryptionDecorator(IDataProcessor processor) : base(processor) { }
    public override string ProcessData(string data)
    {
        var encrypted = Convert.ToBase64String(Encoding.UTF8.GetBytes(_processor.ProcessData(data)));
        return $"[Encrypted:{encrypted}]";
    }
}

class CompressionDecorator : DataProcessorDecorator
{
    public CompressionDecorator(IDataProcessor processor) : base(processor) { }
    public override string ProcessData(string data)
    {
        var compressed = _processor.ProcessData(data).Replace(" ", "");
        return $"[Compressed:{compressed}]";
    }
}

class Program
{
    static void Main()
    {
        string original = "Hello World from Decorator Pattern!";

        IDataProcessor processor = new BasicDataProcessor();
        Console.WriteLine($"Исходные: {processor.ProcessData(original)}");

        IDataProcessor encrypted = new EncryptionDecorator(new BasicDataProcessor());
        Console.WriteLine($"Зашифрованные: {encrypted.ProcessData(original)}");

        IDataProcessor compressed = new CompressionDecorator(new BasicDataProcessor());
        Console.WriteLine($"Сжатые: {compressed.ProcessData(original)}");

        IDataProcessor encryptedAndCompressed = new CompressionDecorator(new EncryptionDecorator(new BasicDataProcessor()));
        Console.WriteLine($"Зашифрованные + сжатые: {encryptedAndCompressed.ProcessData(original)}");
    }
}
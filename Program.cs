// Разработка сетевого приложения на C# (семинары)
// Урок 1. Работа с сетью: чтение и запись данных в сеть. Клиентские и серверные приложения
// Попробуйте переработать приложение, добавив подтверждение об отправке сообщений как в сервер, так и в клиент.

using System;

public class MessageService
{
    public event EventHandler<MessageEventArgs> MessageSent;

    public void SendMessage(string message)
    {
        Console.WriteLine("Sending message: " + message);

        // Send message to server
        SendToServer(message);

        // Send message to client
        SendToClient(message);

        // Raise event to notify message was sent
        OnMessageSent(message);
    }

    private void SendToServer(string message)
    {
        // Simulate sending message to server
        Console.WriteLine("Message sent to server: " + message);
    }

    private void SendToClient(string message)
    {
        // Simulate sending message to client
        Console.WriteLine("Message sent to client: " + message);
    }

    protected virtual void OnMessageSent(string message)
    {
        MessageSent?.Invoke(this, new MessageEventArgs { Message = message });
    }
}

public class MessageEventArgs : EventArgs
{
    public string Message { get; set; }
}

public class Program
{
    public static void Main()
    {
        MessageService messageService = new MessageService();
        messageService.MessageSent += HandleMessageSent;

        messageService.SendMessage("Hello, world!");
    }

    private static void HandleMessageSent(object sender, MessageEventArgs e)
    {
        Console.WriteLine("Message sent event handler: " + e.Message);
    }
}

// Добавили в класс MessageService событие MessageSent и метод OnMessageSent для отправки уведомления о том, что сообщение было отправлено. 
// При отправке сообщения вызываем этот метод и отправляем сообщение как на сервер, так и на клиент. 
// В методе Main создаем экземпляр класса MessageService, подписываемся на событие MessageSent и отправляем сообщение. 
// При получении уведомления вызываем метод HandleMessageSent, который просто выводит сообщение в консоль.

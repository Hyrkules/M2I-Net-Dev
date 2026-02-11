using System;
using System.Collections.Generic;
using System.Text;

namespace GestionFacture.Notification
{
    internal class NotificationConsole
    {
        public void EnvoyerNotification(string destinataire, string message)
        {
            Console.WriteLine($"[Notification pour {destinataire}] {message}");
        }
    }
}

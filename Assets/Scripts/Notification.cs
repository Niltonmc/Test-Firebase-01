using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class Notification : MonoBehaviour
{
    AndroidNotificationChannel notificationChannel;
    void Start()
    {
        channelNregisterCreation();
    }
    public void sendNotification() 
    {
        AndroidNotification notificationPrueba = new AndroidNotification()
        {
            Title = "¡ECLOSIONO TU DRAGON!",
            Text = "Acaba de nacer un nuevo dragon, ven a verlo",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = System.DateTime.Now
        };
        AndroidNotificationCenter.SendNotification(notificationPrueba, notificationChannel.Id);
    }
    public void channelNregisterCreation()
    {
        notificationChannel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Oyeeeee",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);
    }
}

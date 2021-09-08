﻿using System.Collections.Generic;
using System.Linq;

namespace Origin.Common.Notifications
{
    public class NotificationContext
    {
		private readonly List<string> _notifications;
		public IReadOnlyCollection<string> Notifications => _notifications;
		public bool HasNotifications => _notifications.Any();

		public NotificationContext()
		{
			_notifications = new List<string>();
		}

		public void AddNotification(string message)
		{
			_notifications.Add(message);
		}

		public void AddNotifications(ICollection<string> notifications)
		{
			_notifications.AddRange(notifications);
		}
	}
}

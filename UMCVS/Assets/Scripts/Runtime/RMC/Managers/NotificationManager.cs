using RMC.Notifications;
using System.Collections.Generic;

namespace RMC.Managers
{
	/// <summary>
	/// Available without permission. Write to code@RivelloMultimediaConsulting.com
	/// </summary>
	public class NotificationManager
	{
		public void AddNotificationListener<T>(EventDelegate<T> del) where T : Notification
		{
			AddNotificationListenerImpl(del);
		}

		public void RemoveNotificationListener<T>(EventDelegate<T> del) where T : Notification
		{
			RemoveNotificationListenerImpl(del);
		}

		public void InvokeNotification(Notification e)
		{
			InvokeNotificationImpl(e);
		}
		public delegate void EventDelegate<T>(T e) where T : Notification;
		private delegate void EventDelegate(Notification e);

		private Dictionary<System.Type, EventDelegate> delegates = new Dictionary<System.Type, EventDelegate>();

		private Dictionary<System.Delegate, EventDelegate> delegateLookup = new Dictionary<System.Delegate, EventDelegate>();

		private void AddNotificationListenerImpl<T>(EventDelegate<T> del) where T : Notification
		{

			if (delegateLookup.ContainsKey(del))
			{
				return;
			}

			EventDelegate internalDelegate = (e) => del((T)e);
			delegateLookup[del] = internalDelegate;

			EventDelegate tempDel;
			if (delegates.TryGetValue(typeof(T), out tempDel))
			{
				delegates[typeof(T)] = tempDel += internalDelegate;
			}
			else
			{
				delegates[typeof(T)] = internalDelegate;
			}
		}

		private void RemoveNotificationListenerImpl<T>(EventDelegate<T> del) where T : Notification
		{
			EventDelegate internalDelegate;

			if (delegateLookup.TryGetValue(del, out internalDelegate))
			{
				EventDelegate tempDel;
				if (delegates.TryGetValue(typeof(T), out tempDel))
				{
					tempDel -= internalDelegate;
					if (tempDel == null)
					{
						delegates.Remove(typeof(T));
					}
					else
					{
						delegates[typeof(T)] = tempDel;
					}
				}

				delegateLookup.Remove(del);
			}
		}

		public int DelegateLookupCount { get { return delegateLookup.Count; } }

		private void InvokeNotificationImpl(Notification e)
		{
			EventDelegate del;
			if (delegates.TryGetValue(e.GetType(), out del))
			{
				del.Invoke(e);
			}
		}
	}
}
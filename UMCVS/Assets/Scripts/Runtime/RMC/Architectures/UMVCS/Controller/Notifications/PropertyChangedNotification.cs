
namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Notifications
{
	/// <summary>
	/// Holds the before and after value during a property chagnge
	/// </summary>
	public abstract class PropertyChangedNotification<T> : RMC.Notifications.Notification
	{
		public T PreviousValue { get { return _previousValue; } }
		public T CurrentValue { get { return _currentValue; } }

		private T _previousValue;
		private T _currentValue;

		public PropertyChangedNotification(T previousValue, T currentValue)
		{
			_previousValue = previousValue;
			_currentValue = currentValue;
		}
	}
}
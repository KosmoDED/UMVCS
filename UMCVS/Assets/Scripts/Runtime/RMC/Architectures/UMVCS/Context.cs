using RMC.Managers;

namespace RMC.Architectures.UMVCS
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class Context  
	{
		public ModelLocator ModelLocator { get { return _modelLocator; } }
		public NotificationManager NotificationManager { get { return _notificationManager; } }

		private ModelLocator _modelLocator = null;
		private NotificationManager _notificationManager = null;

		public Context()
		{
			_modelLocator = new ModelLocator();
			_notificationManager = new NotificationManager();
		}
	}
}
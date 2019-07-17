
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Notifications;

public class BounceCountChangedNotification : PropertyChangedNotification<int>
{
	public BounceCountChangedNotification(int previousValue, int currentValue) : base(previousValue, currentValue) { }
}

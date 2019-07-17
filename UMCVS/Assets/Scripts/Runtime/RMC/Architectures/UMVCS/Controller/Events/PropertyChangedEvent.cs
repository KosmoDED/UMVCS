
using UnityEngine.Events;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Events
{
	/// <summary>
	/// Holds the before and after value during a property chagnge
	/// </summary>
	public abstract class PropertyChangedEvent<T> : UnityEvent<T,T>
	{
	}
}
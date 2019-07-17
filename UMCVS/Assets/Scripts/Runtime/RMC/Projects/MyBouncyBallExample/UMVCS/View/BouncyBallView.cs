using RMC.Architectures.UMVCS.View;
using UnityEngine;
using UnityEngine.Events;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.View
{
	public class BounceEvent : UnityEvent { }

	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BouncyBallView : BaseView
	{
		public BounceEvent OnBounce = new BounceEvent();

		protected void OnCollisionEnter (Collision collision)
		{
			OnBounce.Invoke();
		}
	}
}
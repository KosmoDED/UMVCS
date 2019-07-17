using RMC.Architectures.UMVCS.View;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Events;
using UnityEngine;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.View
{ 
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
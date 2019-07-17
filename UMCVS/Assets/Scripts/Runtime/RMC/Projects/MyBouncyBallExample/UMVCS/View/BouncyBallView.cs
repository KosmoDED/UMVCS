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
		public BouncedEvent OnBounce = new BouncedEvent();

		protected void OnCollisionEnter (Collision collision)
		{
			OnBounce.Invoke();
		}
	}
}
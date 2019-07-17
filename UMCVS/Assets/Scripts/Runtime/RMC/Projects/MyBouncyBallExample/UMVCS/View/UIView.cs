using RMC.Architectures.UMVCS.View;
using UnityEngine;
using UnityEngine.UI;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.View
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class UIView : BaseView
	{
		public Text BounceCountText { get { return _bounceCountText; } }

		[SerializeField]
		private Text _bounceCountText = null;
	}
}
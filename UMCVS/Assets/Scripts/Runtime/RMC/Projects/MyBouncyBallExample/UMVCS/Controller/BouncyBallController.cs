using RMC.Projects.MyBouncyBallExample.UMVCS.View;
using RMC.Architectures.UMVCS.Model;
using RMC.Architectures.UMVCS.Controller;
using RMC.Projects.MyBouncyBallExample.UMVCS.Model;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Commands;
using RMC.Architectures.UMVCS.Service;
using System;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BouncyBallController : BaseController<NullModel, BouncyBallView, NullService>
	{
		private BouncyBallView _bouncyBallView { get { return BaseView as BouncyBallView; } }

		protected void Start()
		{
			_bouncyBallView.OnBounce.AddListener(BouncyBallView_OnBounce);
		}

		private void BouncyBallView_OnBounce()
		{
			Context.CommandManager.InvokeCommand(new BouncedCommand());
		}
	}
}
using RMC.Projects.MyBouncyBallExample.UMVCS.View;
using RMC.Architectures.UMVCS.Model;
using RMC.Architectures.UMVCS.Controller;
using RMC.Projects.MyBouncyBallExample.UMVCS.Model;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Commands;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class UIController : BaseController<NullModel, UIView>
	{
		private UIView _uiView { get { return BaseView as UIView; } }

		protected void Start()
		{
			Context.CommandManager.AddCommandListener<BounceCountChangedCommand>(
				EventManager_OnBounceCountChanged);

			SetBounceCountText(0);	
		}

		private void SetBounceCountText(int count)
		{
			int bounceCountMax = Context.ModelLocator.
				GetModel<MainModel>().MainConfigData.BounceCountMax;

			_uiView.BounceCountText.text = string.Format("BounceCount: {0:00}/{1:00}", count, bounceCountMax);
		}

		private void EventManager_OnBounceCountChanged(BounceCountChangedCommand e)
		{
			SetBounceCountText(e.CurrentValue);
		}
	}
}
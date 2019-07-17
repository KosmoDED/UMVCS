using RMC.Architectures.UMVCS.Controller;
using RMC.Managers;
using RMC.Projects.MyBouncyBallExample.UMVCS.Model;
using RMC.Projects.MyBouncyBallExample.UMVCS.View;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class MainController : BaseController<MainModel, MainView>
	{
		private MainModel _mainModel { get { return BaseModel as MainModel; } }
		private MainView _mainView { get { return BaseView as MainView; } }

		protected void Start()
		{
			_mainModel.BouncyBallView = Instantiate(_mainView.BouncyBallViewPrefab) as BouncyBallView;
			_mainModel.BouncyBallView.transform.SetParent(_mainView.BouncyBallParent);

			_mainModel.BouncyBallView.OnBounce.AddListener(BouncyBallView_OnBounce);
			_mainModel.OnBounceCountChanged.AddListener(MainModel_OnBounceCountChanged);

			_mainModel.BounceCount = 0;
		}

		private void MainModel_OnBounceCountChanged(int previousValue, int currentValue)
		{
			if (currentValue > _mainModel.MainConfigData.BounceCountMax)
			{
				return;
			}

			Context.NotificationManager.InvokeNotification(
				new BounceCountChangedNotification(previousValue, currentValue));
		}

		//TODO: Move this per the comment?
		// As the project scales up the "BouncyBall" Concept would likely 
		// have its own Controller to handle this and would use a notification
		private void BouncyBallView_OnBounce()
		{
			_mainModel.BounceCount++;
		}
	}
}
using System;
using RMC.Architectures.UMVCS.Controller;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Commands;
using RMC.Projects.MyBouncyBallExample.UMVCS.Model;
using RMC.Projects.MyBouncyBallExample.UMVCS.Service;
using RMC.Projects.MyBouncyBallExample.UMVCS.View;
using UnityEngine;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class MainController : BaseController<MainModel, MainView, MainService>
	{
		private MainModel _mainModel { get { return BaseModel as MainModel; } }
		private MainView _mainView { get { return BaseView as MainView; } }
		private MainService _mainService { get { return BaseService as MainService; } }

		protected void Start()
		{
			Context.CommandManager.AddCommandListener<BouncedCommand>(
				CommandManager_OnBounced);
			Context.CommandManager.AddCommandListener<RestartApplicationCommand>(
				CommandManager_OnRestartApplication);

			_mainModel.OnBounceCountChanged.AddListener(MainModel_OnBounceCountChanged);
			_mainModel.OnCaptionTextChanged.AddListener(MainModel_OnCaptionTextChanged);
			_mainService.OnLoadCompleted.AddListener(MainService_OnLoadCompleted);

			RestartApplication();
		}

		private void RestartApplication()
		{
			if (_mainModel.BouncyBallView != null)
			{
				Destroy(_mainModel.BouncyBallView.gameObject);
			}

			_mainModel.BouncyBallView = Instantiate(_mainView.BouncyBallViewPrefab) as BouncyBallView;
			_mainModel.BouncyBallView.transform.SetParent(_mainView.BouncyBallParent);
			_mainModel.BouncyBallView.transform.position =
				_mainModel.MainConfigData.InitialBouncyBallPosition;

			_mainModel.BounceCount = 0;

			_mainService.OnLoadCompleted.AddListener(MainService_OnLoadCompleted);
			_mainService.Load();
		}

		private void CommandManager_OnRestartApplication(RestartApplicationCommand e)
		{
			RestartApplication();
		}

		private void MainService_OnLoadCompleted(string text)
		{
			_mainModel.CaptionText = text;
		}

		private void MainModel_OnCaptionTextChanged(string previousValue, string currentValue)
		{
			Context.CommandManager.InvokeCommand(
				new CaptionTextChangedCommand(previousValue, currentValue));
		}

		private void MainModel_OnBounceCountChanged(int previousValue, int currentValue)
		{
			// Reset the count here, this is a contrived example
			// of a Controller mitigating changes to a Model
			if (currentValue > _mainModel.MainConfigData.BounceCountMax)
			{
				currentValue = 0;
			}

			Context.CommandManager.InvokeCommand(
				new BounceCountChangedCommand(previousValue, currentValue));
		}

		private void CommandManager_OnBounced(BouncedCommand e)
		{
			_mainModel.BounceCount++;
		}
	}
}
using RMC.Architectures.UMVCS.Model;
using RMC.Attributes;
using RMC.Events;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Events;
using RMC.Projects.MyBouncyBallExample.UMVCS.View;
using UnityEngine;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Model
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class MainModel : BaseModel
	{
		public MainConfigData MainConfigData { get { return ConfigData as MainConfigData; } }
		public BounceCountChangedEvent OnBounceCountChanged = new BounceCountChangedEvent();
		public CaptionTextChangedEvent OnCaptionTextChanged = new CaptionTextChangedEvent();

		public int BounceCount
		{
			get
			{
				return _bounceCount;
			}
			set
			{
				if (_bounceCount != value)
				{
					int previousValue = _bounceCount;
					_bounceCount = value;
					OnBounceCountChanged.Invoke(previousValue, _bounceCount);
				}
			}
		}
		public string CaptionText
		{
			get
			{
				return _captionText;
			}
			set
			{
				if (_captionText != value)
				{
					string previousValue = _captionText;
					_captionText = value;
					OnCaptionTextChanged.Invoke(previousValue, _captionText);
				}
			}
		}

		public BouncyBallView BouncyBallView { get { return _bouncyBallView; } set { _bouncyBallView = value; } }

		[ReadOnly]
		[SerializeField]
		private string _captionText = "";

		[ReadOnly]
		[SerializeField]
		private int _bounceCount = 0;

		[ReadOnly]
		[SerializeField]
		private BouncyBallView _bouncyBallView = null;
	}
}
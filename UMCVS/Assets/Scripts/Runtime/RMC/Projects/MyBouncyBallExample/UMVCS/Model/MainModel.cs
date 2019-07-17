using RMC.Architectures.UMVCS.Model;
using RMC.Attributes;
using RMC.Events;
using RMC.Projects.MyBouncyBallExample.UMVCS.View;
using UnityEngine;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Model
{
	public class BounceCountChangedEvent : PropertyChangedEvent<int> { }

	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class MainModel : BaseModel
	{
		public MainConfigData MainConfigData { get { return ConfigData as MainConfigData; } }

		public BounceCountChangedEvent OnBounceCountChanged = new BounceCountChangedEvent();

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
					int oldBounceCount = _bounceCount;
					_bounceCount = value;
					OnBounceCountChanged.Invoke(oldBounceCount, _bounceCount);
				}
			}
		}

		public BouncyBallView BouncyBallView { get { return _bouncyBallView; } set { _bouncyBallView = value; } }

		[ReadOnly]
		[SerializeField]
		private int _bounceCount = 0;

		[ReadOnly]
		[SerializeField]
		private BouncyBallView _bouncyBallView = null;
	}
}
using RMC.Architectures.UMVCS.Model;
using RMC.Attributes;
using RMC.Data.Types;
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

		/// <summary>
		/// Using Observable<T> is optional. It includes a built-in 
		/// event notification upon change and is useful.
		/// </summary>
		// Want to the the OnChanged in the inspector? Use this [ObservableShowAllChildren]
		[SerializeField]
		public ObservableInt BounceCount = new ObservableInt();

		/// <summary>
		/// Using Observable<T> is optional. It includes a built-in 
		/// event notification upon change and is useful.
		/// </summary>
		// Want to the the OnChanged in the inspector? Use this [ObservableShowAllChildren]
		[SerializeField]
		public ObservableString CaptionText = new ObservableString();

		public BouncyBallView BouncyBallView { get { return _bouncyBallView; } set { _bouncyBallView = value; } }

		[ReadOnly]
		[SerializeField]
		private BouncyBallView _bouncyBallView = null;
	}
}
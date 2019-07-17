using RMC.Architectures.UMVCS.Model.Data;
using UnityEngine;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Model
{
	[CreateAssetMenu(fileName = "MainConfigData", 
		menuName = Constants.CreateAssetMenuPath + "MainConfigData", 
		order = Constants.CreateAssetMenuOrder)]

	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class MainConfigData : ConfigData
	{
		public int BounceCountMax { get { return _bounceCountMax; }  }

		[SerializeField]
		private int _bounceCountMax = 10;

	}
}
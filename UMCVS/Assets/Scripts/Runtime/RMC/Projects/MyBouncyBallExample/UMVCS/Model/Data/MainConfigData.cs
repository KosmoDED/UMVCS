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

		public Vector3 InitialBouncyBallPosition { get { return _initialBouncyBallPosition; } }

		[SerializeField]
		private int _bounceCountMax = 10;

		[SerializeField]
		private Vector3 _initialBouncyBallPosition = new Vector3(0, 5, 0);

	}
}
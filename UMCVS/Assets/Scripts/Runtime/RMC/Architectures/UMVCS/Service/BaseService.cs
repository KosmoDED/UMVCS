using UnityEngine;

namespace RMC.Architectures.UMVCS.Service
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BaseService : MonoBehaviour
	{
		protected bool IsInitialized { get { return _isInitialized; } }
		private bool _isInitialized = false;

		public virtual void Initialize()
		{
			if (!_isInitialized)
			{
				_isInitialized = true;
			}
		}
	}
}
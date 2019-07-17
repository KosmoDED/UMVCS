using RMC.Architectures.UMVCS.Model.Data;
using UnityEngine;

namespace RMC.Architectures.UMVCS.Model
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BaseModel : MonoBehaviour
	{
		protected ConfigData ConfigData { get { return _configData; } }
		protected bool IsInitialized { get { return _isInitialized; } }

		[SerializeField]
		private ConfigData _configData = null;

		private bool _isInitialized = false;

		public virtual void Initialize()
		{
			if (!_isInitialized)
			{
				_isInitialized = true;
				BaseApp.Instance.Context.ModelLocator.AddModel(this);
			}
		}

		private void UnInitialize()
		{
			if (_isInitialized)
			{
				_isInitialized = false;
				BaseApp.Instance.Context.ModelLocator.AddModel(this);
			}
		}

		protected void Awake ()
		{
			Initialize();
		}

		protected void OnDestroy()
		{
			_isInitialized = false;
			BaseApp.Instance.Context.ModelLocator.RemoveModel(this);
		}
	}
}
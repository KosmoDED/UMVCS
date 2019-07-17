using RMC.Architectures.UMVCS.Model;
using RMC.Architectures.UMVCS.View;
using UnityEngine;

namespace RMC.Architectures.UMVCS.Controller
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BaseController : MonoBehaviour
	{
	}

	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class BaseController<M, V> : BaseController where M : BaseModel where V : BaseView
	{
		public Context Context { get { return BaseApp.Instance.Context; } }

		public M BaseModel { get { return _baseModel; } set { _baseModel = value; } }

		public V BaseView { get { return _baseView; } set { _baseView = value; } }

		[SerializeField]
		private M _baseModel = null;

		[SerializeField]
		private V _baseView = null;

	}
}
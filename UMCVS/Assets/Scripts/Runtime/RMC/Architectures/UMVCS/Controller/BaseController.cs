using RMC.Architectures.UMVCS.Model;
using RMC.Architectures.UMVCS.Service;
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
	public class BaseController<M, V, S> : BaseController 
		where M : BaseModel where V : BaseView where S : BaseService
	{
		public Context Context { get { return BaseApp.Instance.Context; } }

		public M BaseModel { get { return _model; } set { _model = value; } }

		public V BaseView { get { return _view; } set { _view = value; } }

		public S BaseService { get { return _service; } set { _service = value; } }

		[SerializeField]
		private M _model = null; //Keep this short naming for inspector

		[SerializeField]
		private V _view = null; //Keep this short naming for inspector

		[SerializeField]
		private S _service = null; //Keep this short naming for inspector

	}
}
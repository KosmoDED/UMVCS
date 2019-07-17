using RMC.Architectures.UMVCS.Model;
using RMC.Architectures.UMVCS.Controller;
using RMC.Projects.MyBouncyBallExample.UMVCS.Controller.Commands;
using RMC.Architectures.UMVCS.Service;
using RMC.Projects.MyBouncyBallExample.UMVCS.View;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.Controller
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class AudioController : BaseController<NullModel, AudioView, NullService>
	{
		private AudioView _audioView { get { return BaseView as AudioView; } }

		protected void Start()
		{
			Context.CommandManager.AddCommandListener<BouncedCommand>(
				CommandManager_OnBounced);

		}
		private void CommandManager_OnBounced(BouncedCommand e)
		{
			_audioView.PlayAudioClip();
		}
	}
}
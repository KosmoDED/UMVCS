using RMC.Architectures.UMVCS.View;
using UnityEngine;

namespace RMC.Projects.MyBouncyBallExample.UMVCS.View
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	public class AudioView : BaseView
	{
		[SerializeField]
		private AudioSource _audioSource;

		[SerializeField]
		private AudioClip _audioClip;

		public void PlayAudioClip ()
		{
			_audioSource.clip = _audioClip;
			_audioSource.Play();
		}
	}
}
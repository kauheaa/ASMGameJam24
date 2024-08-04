using UnityEngine;

public class PlayAudioClip : MonoBehaviour
{

	public AudioSource audioSource;
	public AudioClip audioClip;

	public void PlaySoundEffect()
	{
		audioSource.PlayOneShot(audioClip);
	}
}
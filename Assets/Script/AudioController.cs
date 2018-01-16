using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class AudioController : MonoBehaviour {
	float minAttenuationFX = 0;
	float minAttenuationMusic = 0;
	const float maxAttenuation = -80f;
	const string idEffectsVolume = "FXVolume";
	const string idMusicVolume = "MusicVolume";

	[SerializeField]
	AudioMixer mixer;
	[SerializeField]
	AudioMixerGroup _musicGroup;
	[SerializeField]
	AudioMixerGroup _effectsGroup;
	[SerializeField]
	float pauseAttenuation;

	public static AudioController instance{ get; private set;}

	public AudioMixerGroup musicGroup{get{ return _musicGroup;}}
	public AudioMixerGroup effectsGroup{get{ return _effectsGroup;}}

	public float effectsVolume{
		get{ 
			float value;
			mixer.GetFloat(idEffectsVolume, out value);
			return value;
		}
		set{ mixer.SetFloat (idEffectsVolume, Mathf.Clamp(value, maxAttenuation, minAttenuationFX));}
	}

	public float musicVolume{
		get{ 
			float value;
			mixer.GetFloat(idMusicVolume, out value);
			return value;
		}
		set{ mixer.SetFloat (idMusicVolume, value);}
	}

	void Awake(){
		instance = this;
	}

	void Start(){

		GetMaxVolumeFromMixer ();

		UpVolume();
	}

	void GetMaxVolumeFromMixer () {
		float value;
		mixer.GetFloat (idEffectsVolume, out value);
		minAttenuationFX = value;
		mixer.GetFloat (idEffectsVolume, out value);
		minAttenuationMusic = value;
	}

	public void EnableEffects (bool enable){
		effectsVolume = enable?minAttenuationFX:maxAttenuation;

	}

	public void EnableMusic (bool enable){
		musicVolume = enable?minAttenuationMusic:maxAttenuation;

	}


	public void UpVolume() {
		EnableEffects (true);
		EnableMusic (true);
	}

}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class AudioController : MonoBehaviour {
	float minAttenuationFX = 0;
	float minAttenuationMusic = 0;
	const float maxAttenuation = -80f;
	const string idEffectsVolume = "FxVolume";
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
		set{ mixer.SetFloat (idEffectsVolume, (40*value) - 40);}
	}

	public float musicVolume{
		get{ 
			
			float value;
			mixer.GetFloat(idMusicVolume, out (value));
			return value;
		}
		set{ mixer.SetFloat (idMusicVolume, (40*value) - 40);}
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
		effectsVolume = enable?1:0;

	}

	public void EnableMusic (bool enable){
		musicVolume = enable?1:0;

	}


	public void UpVolume() {
		EnableEffects (true);
		EnableMusic (true);
	}


    float musicVolumen = 0;

    public void FadeInMusic()
    {
        StartCoroutine("FadeInMusicCorroutine");
    }

    IEnumerator FadeInMusicCorroutine()
    {
        float initial;
        mixer.GetFloat(idMusicVolume, out initial);

        for (float i = initial; i < 0; i++)
        {
            //musicVolumen 
            mixer.SetFloat(idMusicVolume, i);
            yield return null;
        }
             
    }

    public void FadeOutMusic()
    {
        StartCoroutine("FadeOutMusicCorroutine");
    }

    IEnumerator FadeOutMusicCorroutine()
    {
        float initial;
        mixer.GetFloat(idMusicVolume, out initial);

        for (float i = initial; i > -80; i--)
        {
            //musicVolumen 
            mixer.SetFloat(idMusicVolume, i);
            yield return null;
        }

    }

}
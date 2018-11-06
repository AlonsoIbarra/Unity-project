using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	//Reproductores de sonido
	[HideInInspector]
	AudioSource[] audios;

	void Start(){
		audios=this.GetComponents<AudioSource>();
		audios [0].volume = 0.5f;
		audios [0].loop = true;
		audios [1].volume = 1.0f;
        audios[2].volume = 0.5f;
        audios[2].loop = true;
        //        audios[1].Stop();// para apagar audio

    }
    public void encenderReloj() {
        audios[2].loop = true;
        audios[2].Play();
    }
    public void apagarReloj()
    {
        audios[2].loop = false;
        audios[2].Stop();
    }


    //Manda a llamar el sonido en el audioSource indicado
    public void playSound(string soundName, int audioSource)
	{
        StartCoroutine(pSound(soundName, audioSource));
	}

	private IEnumerator pSound(string soundName, int audioSource)
	{
		
		string pathToDownload = "";
		
		pathToDownload = Application.platform == RuntimePlatform.Android ? Application.persistentDataPath : Application.streamingAssetsPath;
		


		//string newName = soundName.Replace(",", " ");
		WWW audio = new WWW("file://" + pathToDownload + "/" + soundName + ".mp3");
		yield return audio;
		try{
			audios[audioSource].Stop ();
			audios[audioSource].clip = audio.GetAudioClip(true, true, AudioType.MPEG);
//			print (audio.error);
			audios[audioSource].Play();
		} catch {
			Debug.Log ("Fallo al reproducir el sonido");
		}
	}
}

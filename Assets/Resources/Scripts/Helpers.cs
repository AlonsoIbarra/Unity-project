using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Helpers : MonoBehaviour
{
    public void playSound(string soundName, AudioSource audioSource)
    {
        StartCoroutine(pSound(soundName, audioSource));
    }

    private IEnumerator pSound(string soundName, AudioSource audioSource)
    {
        string pathToDownload = "";
        if (Application.platform == RuntimePlatform.Android)
        {
            pathToDownload = Application.persistentDataPath;
        }
        else
        {
            pathToDownload = Application.streamingAssetsPath;
        }
        string newName = soundName.Replace(" ", "_");

        print("path: " + pathToDownload);
        WWW audio = new WWW("file://" + pathToDownload + "/" + newName + ".mp3");
        yield return audio;
        audioSource.clip = audio.GetAudioClip(true, true, AudioType.MPEG);
        audioSource.Play();
    }
}
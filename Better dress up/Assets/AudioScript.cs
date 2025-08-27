using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource musicsrc, fxsrc;
    public AudioClip music, win, lose, wear, click, money;
    public bool toggled = false;

    public static AudioScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            PlayMusic();
            Screen.SetResolution(1920, 1080, true);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayFx(AudioClip clip)
    {
        fxsrc.PlayOneShot(clip);
    }

    public void PlayMusic()
    {
        musicsrc.clip = music;
        musicsrc.loop = true;
        musicsrc.Play();
    }
}

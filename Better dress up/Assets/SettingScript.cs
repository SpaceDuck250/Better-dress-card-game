using UnityEngine;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    public Slider musicslider;
    public Slider fxslider;
    public Toggle fullscreentoggle;

    private void Start()
    {
        FixValues();
    }

    public void FixValues()
    {
        musicslider.value = AudioScript.instance.musicsrc.volume;
        fxslider.value = AudioScript.instance.fxsrc.volume;
        fullscreentoggle.isOn = AudioScript.instance.toggled;
    }

    public void OnMusicChange(float volume)
    {
        AudioScript.instance.musicsrc.volume = volume;
    }

    public void OnFXChange(float volume)
    {
        AudioScript.instance.fxsrc.volume = volume;
    }

    public void OnToggleChange(bool toggle)
    {
        AudioScript.instance.PlayFx(AudioScript.instance.click);
        Screen.fullScreen = toggle;
        AudioScript.instance.toggled = toggle;
    }

    public void OpenPanel()
    {
        AudioScript.instance.PlayFx(AudioScript.instance.click);
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        AudioScript.instance.PlayFx(AudioScript.instance.click);
        gameObject.SetActive(false);
    }

    public void LeaveGame()
    {
        AudioScript.instance.PlayFx(AudioScript.instance.click);
        Debug.Log("Left game");
        Application.Quit();
    }

}

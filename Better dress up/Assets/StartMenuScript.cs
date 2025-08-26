using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        AudioScript.instance.PlayFx(AudioScript.instance.click);
        SceneManager.LoadScene("SampleScene");

    }
}

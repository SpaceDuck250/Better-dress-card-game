using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public Image pic;

    public Sprite[] tutorialpics = new Sprite[4];

    int currentindex = 0;

    public GameObject tutorialscreen;

    public TextMeshProUGUI pagetext;

    public void NextPic()
    {
        AudioScript.instance.PlayFx(AudioScript.instance.click);
        currentindex++;

        if (currentindex >= tutorialpics.Length)
        {
            currentindex = 0;
        }

        pic.sprite = tutorialpics[currentindex];
        pagetext.text = currentindex + 1 + "/4";


    }

    public void OpenScreen()
    {
        AudioScript.instance.PlayFx(AudioScript.instance.click);
        tutorialscreen.SetActive(true);
    }

    public void CloseScreen()
    {
        AudioScript.instance.PlayFx(AudioScript.instance.click);
        tutorialscreen.SetActive(false);
    }
}

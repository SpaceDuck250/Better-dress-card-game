using UnityEngine;
using UnityEngine.SceneManagement;

public class goback : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

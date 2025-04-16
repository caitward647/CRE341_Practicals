using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string Level_1;
    public void PlayNewGame()
    {
        SceneManager.LoadScene("Level_1");
    }
}

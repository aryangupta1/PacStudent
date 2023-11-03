using UnityEngine;
using UnityEngine.SceneManagement;


public class Level1 : MonoBehaviour
{

    public void OnClick()
    {
        // DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Game");
    }
}

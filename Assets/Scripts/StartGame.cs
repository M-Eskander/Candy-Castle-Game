using UnityEngine;
using UnityEngine.SceneManagement;  

public class StartGame : MonoBehaviour
{

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }   
    
}

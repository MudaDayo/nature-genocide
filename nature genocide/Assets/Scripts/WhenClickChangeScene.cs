using UnityEngine;
using UnityEngine.SceneManagement;

public class WhenClickChangeScene : MonoBehaviour
{
    public string sceneName;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextScene();
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

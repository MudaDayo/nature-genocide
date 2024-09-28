using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private int hearts;

    [SerializeField]
    private GameObject Heart1, Heart2;

    [SerializeField]
    private GameObject SceneManager;

    private void Start()
    {
        hearts = 3;
    }

    public void LoseHP()
    {

        hearts--;

        switch (hearts) 
        {
            case 0:
                SceneManager.GetComponent<SceneManagement>().NextScene();
                break;

            case 1:
                Heart1.SetActive(false);
                break;
            case 2:
                Heart2.SetActive(false);
                break;
        }
    }
}

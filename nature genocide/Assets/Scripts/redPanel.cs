using UnityEngine;

public class redPanel : MonoBehaviour
{
    public GameObject red;


    public void Enable()
    {
        red.SetActive(true);
    }

    public void Disable()
    {
        red.SetActive(false); 
    }
}

using TMPro;
using UnityEngine;

public class killCountManager : MonoBehaviour
{
    public int killCount;

    public GameObject kkText;

    public void AddKill()
    {
        killCount++;
        kkText.GetComponent<TextMeshProUGUI>().text = killCount.ToString() + " KILLS";
    }
}

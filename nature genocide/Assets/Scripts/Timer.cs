using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer;
    public GameObject timerText;

    public void Start()
    {
        timer = 0;
    }

    public void Update()
    {
        timer += Time.deltaTime;

        float seconds = Mathf.FloorToInt(timer % 60);

        timerText.GetComponent<TextMeshProUGUI>().text = seconds.ToString();
    }
}

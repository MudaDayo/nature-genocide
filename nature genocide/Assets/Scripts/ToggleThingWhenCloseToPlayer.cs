using UnityEngine;

public class ToggleThingWhenCloseToPlayer : MonoBehaviour
{
    
    private GameObject ButtonPromptE, player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ButtonPromptE = GameObject.Find("ButtonPromptSeed");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < 5)
        {
            ButtonPromptE.SetActive(true);
        }
    }
}

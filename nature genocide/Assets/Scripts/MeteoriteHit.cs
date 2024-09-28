using UnityEngine;

public class MeteoriteHit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Touchy wooky");

        if (other.gameObject.tag == "Floor")
        {
            Explode();
        }
    }
    private void Explode()
    {
        Debug.Log("boooom");
        Destroy(this.transform.parent.gameObject);
    }
}

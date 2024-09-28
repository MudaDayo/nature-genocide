using UnityEngine;

public class BloodDrop : MonoBehaviour
{
    [SerializeField] private float _timeUntillDestroy;
    private float _timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Blood Spawned");
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > _timeUntillDestroy)
        {
            Destroy(gameObject);
        }

        else
        {
            _timer += Time.deltaTime;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Plant")
    //    {
    //        TryGetComponent<Seed>(out Seed seedScript);
    //        TryGetComponent<GrownPlant>(out GrownPlant grownPlantScript);

    //        if (seedScript != null)
    //        {
    //            Debug.Log("SeedScript rahhhhhhhhh");
    //        }

    //        if (grownPlantScript != null)
    //        {
    //            Debug.Log("GrownplantScript wooooooooo");
    //        }
    //    }
    //}
}

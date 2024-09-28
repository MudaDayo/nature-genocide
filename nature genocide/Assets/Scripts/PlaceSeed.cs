using UnityEngine;

public class PlaceSeed : MonoBehaviour
{
    [SerializeField] GameObject _rayCastStartPos;
    [SerializeField] GameObject _seedSpawnPos;

    public GameObject seedPot;
    public GameObject previewHoldedSeed;
    private GameObject _previewGameObject;

    private bool _isPreviewing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // holdedSeed = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && seedPot != null)
        {
            Physics.Raycast(_rayCastStartPos.transform.position, Vector3.down, out RaycastHit hitInfo);
            Instantiate(seedPot, new Vector3(_seedSpawnPos.transform.position.x, 
                hitInfo.point.y, _seedSpawnPos.transform.position.z), Quaternion.identity);

            seedPot = null;
        }
    }
}
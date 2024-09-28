using UnityEngine;

public class PlaceSeed : MonoBehaviour
{
    [SerializeField] GameObject _rayCastStartPos;
    [SerializeField] GameObject _seedSpawnPos;

    [SerializeField] GameObject handHoldEmpty, handHoldFull, handGrab, grabPrefab;

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
        if (Input.GetKeyDown(KeyCode.E) && seedPot != null)
        {
            Physics.Raycast(_rayCastStartPos.transform.position, Vector3.down, out RaycastHit hitInfo);
            Instantiate(seedPot, new Vector3(_seedSpawnPos.transform.position.x, 
                hitInfo.point.y, _seedSpawnPos.transform.position.z), Quaternion.identity);

            seedPot = null;
        }
        else if (Input.GetKey(KeyCode.E) && seedPot == null)
        {
            Instantiate(grabPrefab, transform.position, Quaternion.identity);
            handHoldEmpty.SetActive(false);
            handHoldFull.SetActive(false);
            handGrab.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E)){
            if(seedPot == null)
            {
                handHoldEmpty.SetActive(true);
            }
            else if(seedPot != null) {
                handHoldFull.SetActive(true);
            }
            
            handGrab.SetActive(false);
        }
    }
}
using UnityEngine;

public class PlaceSeed : MonoBehaviour
{
    [SerializeField] GameObject _rayCastStartPos;
    [SerializeField] GameObject _seedSpawnPos;

    [SerializeField] GameObject handHoldEmpty, handHoldFull, handGrab, grabPrefab, ButtonPromptE;

    public GameObject seedPot;
    public GameObject previewHoldedSeed;
    private GameObject _previewGameObject;

    private bool _isPreviewing = false;

    private GameObject[] _droppedSeeds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seedPot = null;

        handHoldFull.SetActive(false);
        handHoldEmpty.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && seedPot != null)
        {
            ButtonPromptE.SetActive(false);

            Physics.Raycast(_rayCastStartPos.transform.position, Vector3.down, out RaycastHit hitInfo);
            Instantiate(seedPot, new Vector3(_seedSpawnPos.transform.position.x,
                hitInfo.point.y, _seedSpawnPos.transform.position.z), Quaternion.identity);

            handGrab.SetActive(false);
            handHoldFull.SetActive(false);
            handHoldEmpty.SetActive(true);


            seedPot = null;

            handHoldFull.SetActive(false);
            handHoldEmpty.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.E) && seedPot == null)
        {
            //Physics.Raycast(_rayCastStartPos.transform.position, Vector3.down, out RaycastHit hitInfo);

            //GameObject grabHitBox = Instantiate(grabPrefab, new Vector3(_seedSpawnPos.transform.position.x,
            //    hitInfo.point.y + 1f, _seedSpawnPos.transform.position.z), Quaternion.identity);
            //grabHitBox.transform.parent = this.transform;

            handHoldEmpty.SetActive(false);
            handHoldFull.SetActive(false);
            handGrab.SetActive(true);

            _droppedSeeds = GameObject.FindGameObjectsWithTag("Seed");

            foreach (var seed in _droppedSeeds)
            {
                if (Vector3.Distance(this.transform.position, seed.transform.position) < 5f)
                {
                    Debug.Log("Seed grabbed");
                    seed.TryGetComponent<SeedDrop>(out SeedDrop seedScript);
                    seedPot = seedScript._seedPot;

                    Destroy(seed.gameObject);
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            handGrab.SetActive(false);
            if (seedPot == null)
            {
                handHoldEmpty.SetActive(true);
            }

            else if (seedPot != null)
            {
                handHoldFull.SetActive(true);
            }
        }
    }
}
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject prefab1;  // First prefab
    public GameObject prefab2;  // Second prefab
    Vector3 nextSpawnPoint;

    public void SpawnTile ()
    {
        GameObject selectedPrefab = Random.Range(0, 2) == 0 ? prefab1 : prefab2;
        GameObject temp = Instantiate(selectedPrefab, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0; i < 15; i++) 
        {
        SpawnTile();
        }
    }

    
}

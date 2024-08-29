using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        //SpawnGrades();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        // Spawn the obstacle at that position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}

   /* public GameObject gradePrefab;

   /* void SpawnGrades ()
    {
        int gradesToSpawn = 10;
        for(int i = 0; i < gradesToSpawn; i++) 
        {
        GameObject temp = Instantiate(gradePrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
   /* Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1;
        return point;
    }
}
   */
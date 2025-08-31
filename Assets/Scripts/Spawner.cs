using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 2f;
    public float minHeight = -4f;
    public float maxHeight = 4f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);        
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + Random.Range(minHeight, maxHeight), 0f);
        GameObject pipes = Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{
    [Header("Chunk")]
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private int initialChunks = 4;

    [Header("Movement")]
    [SerializeField] private float scrollSpeed = 3f;

    [Header("Despawn")]
    [SerializeField] private float despawnY = -12f;

    private readonly List<GameObject> chunks = new();
    private float chunkHeight = 10f;
    public float DistanceTravelled { get; private set; }

    void Start()
    {
        for (var i = 0; i < initialChunks; i++)
        {
            SpawnChunk();
        }
    }

    void Update()
    {
        var delta = scrollSpeed * Time.deltaTime;
        DistanceTravelled += delta;

        MoveChunks(delta);
        DespawnOldestIfNeeded();
    }

    private void MoveChunks(float delta)
    {
        foreach(var chunk in chunks)
        {
            chunk.transform.position += Vector3.down * delta;
        }
    }

    private void SpawnChunk()
    {
        var nextPosition = chunks.Count == 0
            ? Vector3.zero
            : chunks.Last().transform.position + Vector3.up * chunkHeight;

        var chunk = Instantiate(chunkPrefab, nextPosition, Quaternion.identity, transform);
        chunks.Add(chunk);
    }

    private void DespawnOldestIfNeeded()
    {
        if (chunks.Count == 0)
        {
            return;
        }

        var oldest = chunks[0];

        if (oldest.transform.position.y < despawnY)
        {
            Destroy(oldest);
            chunks.RemoveAt(0);
            SpawnChunk();
        }
    }
}

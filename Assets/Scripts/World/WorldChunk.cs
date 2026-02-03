using UnityEngine;

public class WorldChunk : MonoBehaviour
{
    [SerializeField] private float chunkHeight = 10f;
    [SerializeField] private float recycleY = -12f;

    void Update()
    {
        if (transform.position.y < recycleY)
        {
            transform.position += Vector3.up * chunkHeight * 3f;
        }
    }
}

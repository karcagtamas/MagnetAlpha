using Unity.VisualScripting;
using UnityEngine;

public class WorldChunk : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float recycleY = -6f;

    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.down;

        if (transform.position.y < recycleY)
        {
            var height = transform.localScale.y;
            transform.position += 3f * height * Vector3.up;
        }
    }
}

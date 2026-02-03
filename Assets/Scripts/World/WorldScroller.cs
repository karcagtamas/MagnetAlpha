using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 3f;

    void Update()
    {
        transform.position += forwardSpeed * Time.deltaTime * Vector3.down;
    }
}

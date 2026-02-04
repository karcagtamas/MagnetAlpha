using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Bounds Bounds { get; private set; }

    void Awake()
    {
        if (TryGetComponent<SpriteRenderer>(out var sr))
        {
            Bounds = sr.bounds;
        }
    }
}

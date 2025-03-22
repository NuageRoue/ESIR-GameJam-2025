using UnityEditor.Overlays;
using UnityEngine;

public class MinimapRoom : MonoBehaviour
{
    [SerializeField] Vector2 screenPosition;
    Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = FindAnyObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
    }
}

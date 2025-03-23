using UnityEngine;

using UnityEngine.UI;

public class MinimapRoom : MonoBehaviour
{
    [SerializeField] Vector2 screenPosition;

    [SerializeField] public bool isInRoom;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isGlowing", isInRoom);
    }

    internal void SetColor(Color color)
    {
        Debug.Log(name + ": new color");
        GetComponent<Image>().color = color;
    }
}

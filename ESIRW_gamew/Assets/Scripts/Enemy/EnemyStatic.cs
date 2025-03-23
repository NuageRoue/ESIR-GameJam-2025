using UnityEngine;

public class EnemyStatic : MonoBehaviour
{

    [SerializeField] private Collider2D collider2D;
    protected TransitionManager transitionManager;

    void Awake()
    {
        transitionManager = GameObject.FindAnyObjectByType<TransitionManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transitionManager.UpdateDeath();
    }
}

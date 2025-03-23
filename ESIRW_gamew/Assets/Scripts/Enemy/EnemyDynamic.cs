using System;
using DigitalRuby.Tween;
using UnityEngine;

public class EnemyDynamic : MonoBehaviour
{

    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;

    [SerializeField] private float tweenSpeed = 1f;

    private Vector3 current;

    private void Awake()
    {
        gameObject.transform.position = p1.position;
        current = p2.position;
        UpdateTween();
    }

    private void Update()
    {
        if (gameObject.transform.position == current)
        {
            UpdateTween();
        }
    }

    private void UpdateTween()
    {
        Vector3 last = current;
        current = current.Equals(p1.position) ? p2.position : p1.position;
        System.Action<ITween<Vector3>> updatePos = (t) =>
        {
            gameObject.transform.position = t.CurrentValue;
        };

        Guid guid = Guid.NewGuid();
        String tweenName = guid.ToString();
        gameObject.Tween(tweenName, last, current, tweenSpeed, TweenScaleFunctions.QuadraticEaseInOut, updatePos);
    }

}

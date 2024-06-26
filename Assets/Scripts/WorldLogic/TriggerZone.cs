using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] UnityEvent onEnter;
    [SerializeField] UnityEvent onExit;

    void OnTriggerEnter2D(Collider2D other)
    {
        onEnter.Invoke();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onExit.Invoke();
    }
}

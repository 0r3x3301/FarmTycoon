using System;
using UnityEngine;

public class HandlerOfTaking : MonoBehaviour
{
    public event Action OnTaked;
    public bool CanBeTaked = false;

    private void OnMouseEnter()
    {
        if (CanBeTaked && Input.GetMouseButton(0)) OnTaked?.Invoke();
    }
}

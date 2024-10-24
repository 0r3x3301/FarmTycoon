using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerForItems : MonoBehaviour
{
    public event Action<float> OnUpdateItems;
    private float TimeWithoutItemsUpdate = 0, ItemsUpdateTimeSeconds = 3;
    private void Update()
    {
        if (TimeWithoutItemsUpdate >= ItemsUpdateTimeSeconds)
        {
            TimeWithoutItemsUpdate = 0;
            OnUpdateItems?.Invoke(ItemsUpdateTimeSeconds);
        }
        else
        {
            TimeWithoutItemsUpdate += Time.deltaTime;
        }
    }
}

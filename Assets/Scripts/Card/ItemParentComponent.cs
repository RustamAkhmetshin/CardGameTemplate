using System.Collections;
using System.Collections.Generic;
using EventBusSystem;
using UnityEngine;

public class ItemParentComponent : MonoBehaviour
{
    
    void OnDisable()
    {
        EventBus.RaiseEvent<IItemDestroyHandler>(h => h.OnParentItemDestroy(transform));
    }

}

using System.Collections;
using System.Collections.Generic;
using EventBusSystem;
using UnityEngine;

public interface IItemDestroyHandler : IGlobalSubscriber
{
    void OnParentItemDestroy(Transform item);
}

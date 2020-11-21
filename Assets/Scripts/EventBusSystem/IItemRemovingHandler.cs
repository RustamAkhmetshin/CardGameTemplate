using System.Collections;
using System.Collections.Generic;
using EventBusSystem;
using UnityEngine;

public interface IItemRemovingHandler : IGlobalSubscriber
{
    void HandleItemRemoving(int cardId);
}
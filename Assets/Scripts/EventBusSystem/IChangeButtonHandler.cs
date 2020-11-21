using System.Collections;
using System.Collections.Generic;
using EventBusSystem;
using UnityEngine;

public interface IChangeButtonHandler : IGlobalSubscriber
{
    void OnButtonClick();
}
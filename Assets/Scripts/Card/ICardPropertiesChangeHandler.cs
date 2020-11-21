using System.Collections;
using System.Collections.Generic;
using EventBusSystem;

public interface ICardPropertiesChangeHandler : IGlobalSubscriber
{
    void PropertiesChanged(List<Card> cards);
}
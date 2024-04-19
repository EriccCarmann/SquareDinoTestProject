using UnityEngine;
using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent<GameObject> onEnemyDeath = new UnityEvent<GameObject>();
    public static UnityEvent onAllEnemiesDied = new UnityEvent();

    public static void EnemyDied(GameObject enemy)
    {
        if(onEnemyDeath != null) onEnemyDeath.Invoke(enemy);
    }

    public static void ChangeDestination() 
    {
        if (onAllEnemiesDied != null) onAllEnemiesDied.Invoke();
    }
}

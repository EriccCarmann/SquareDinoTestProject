using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointEnemyStorage : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;

    private void Awake()
    {
        EventManager.onEnemyDeath.AddListener(RemoveEnemy);
    }

    private void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out Enemies enemy))
            {
                for (int i = 0; i < enemy.transform.childCount; i++)
                {
                    enemies.Add(enemy.transform.GetChild(i).gameObject);
                }
            }
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
        }

        if (enemies.Count == 0)
        {
            EventManager.ChangeDestination();
            Destroy(GetComponent<WaypointEnemyStorage>());
        }
    }
}

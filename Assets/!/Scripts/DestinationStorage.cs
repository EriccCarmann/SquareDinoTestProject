using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestinationStorage : MonoBehaviour
{
    private Navigation navigation;
    [SerializeField]private List<Transform> destinations;
    private int index = 0;

    private void Awake()
    {
        EventManager.onAllEnemiesDied.AddListener(ChangeDestination);
    }

    void Start()
    {
        navigation = FindObjectOfType<Navigation>();

        foreach (Transform child in transform)
        {
            foreach (Transform ch in child)
            {
                if (ch.TryGetComponent(out Destination dest))
                {
                    destinations.Add(dest.transform);
                }
            }     
        }
    }

    public void ChangeDestination()
    {
        if (destinations[index] != null)
        {
            navigation.AddNewDestination(destinations[index], destinations[index + 1]);

            index++;
        }
    }
}

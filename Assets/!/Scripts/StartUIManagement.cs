using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUIManagement : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        gameObject.GetComponent<Shooting>().enabled = true;
        startScreen.SetActive(false);
        enabled = false;
    }
}

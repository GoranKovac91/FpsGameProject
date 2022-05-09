using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameObject _counter;
        private void Update()
    {
        if (_counter.transform.childCount==0)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.EndGame();
        }
    }
}

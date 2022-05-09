using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject checkpoint;
    private void Awake()
    {
        checkpoint.SetActive(true) ;
        MustDestroyObject mustDestroy = GetComponentInChildren<MustDestroyObject>();
        mustDestroy.OnDestroy.AddListener(SetActive);
    }
    public void SetActive()
    {
        Destroy(gameObject);
    }
  
}

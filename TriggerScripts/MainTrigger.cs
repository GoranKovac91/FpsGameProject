using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MainTrigger : MonoBehaviour
{
    public  UnityEvent OnPlayerEnter = new UnityEvent();
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag!="Player")
        {
            return;
        }
        
        OnPlayerEnter.Invoke();
    }
  


}

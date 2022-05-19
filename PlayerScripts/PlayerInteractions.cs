using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public float Health = 100;
    public Vector3 _respawnPosition;
    public GameManager gameManager;
   
    private void Update()
    {
        
        if (Health <= 0)
        {
            gameObject.SetActive(false);
            gameManager.LevelFailed();
        }
    }

    private void OnCollisionEnter(Collision col)
    {
    
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Zombie")
        {
            gameManager.TakingDamageCanvas(true);
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Zombie")
        {
           
            gameManager.TakingDamageCanvas(false);
        }
    }
    public void TakeDamage(float value)
    {
        Health -= value;
    }
    public void BoostHealth(int value)
    {
        if (Health >= 100)
        {
            return;
        }
        Health += value;
    }
}

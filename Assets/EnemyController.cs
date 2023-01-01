using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeHit(BulletController bullet){

        if(health <= 0) return;

        health -= bullet.damage;

        if(health <= 0){
            Die();
        }
    }

    public void Die(){
        Destroy(gameObject);

    }

}

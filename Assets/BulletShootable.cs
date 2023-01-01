using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//require a collider attached to same gameObject as this component
[RequireComponent(typeof(Collider2D))]
public class BulletShootable : MonoBehaviour
{
    [Header("attach any OnHit callbacks here")]
    [SerializeField]
    private UnityEvent<BulletController> onHitByBullet;

    //invoke any onHit callbacks; this gets called from BulletController
    public void TakeHit(BulletController b){
        onHitByBullet.Invoke(b);                
    }

}

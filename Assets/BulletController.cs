using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : MonoBehaviour
{
    public bool live;

    public float speed = 8f;

    public float damage = 1f;

    //how long to stay alive for before disappearing if no hit
    public float lifetime = 3f;

    //time since launch
    private float time;
    
    [SerializeField]
    private GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(!live) return;
        
        if(time > lifetime){
            Expire();
            return;
        }

        time += Time.deltaTime;
        Move();
    }

    void Move(){
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
    }

    public void Fire(){
        live = true;
        time = 0f;
    }

    public void Fire(Vector2 target){
        AimAt(target);
        Fire();
    }

    public void Fire(Transform target){
        AimAt(target);
        Fire();
    }

    void Expire(){
        live = false;

        //could implement bullet pool later, but for now just destroy the object
        Destroy(gameObject);
    }

    public void AimAt(Vector2 worldPos){
        
        transform.rotation = Quaternion.FromToRotation(            
            Vector2.up,
            (Vector2) transform.position - worldPos
        );
    }
    public void AimAt(Transform target){
        AimAt(target.transform.position);
                
    }

    void OnCollisionEnter2D(Collision2D c){

        BulletShootable hitSomething = c.collider.GetComponent<BulletShootable>();

        if(!hitSomething) return;

        hitSomething.TakeHit(this);

        Debug.Log("bullet hit");

        //spawn an explosion  at the collision point
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);


        Expire();
    }
    
    
}

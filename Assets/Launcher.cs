using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bulletPrefab;

    [Tooltip("the unity layer that fired bullets will spawn on")]
    public int bulletLayer;

    public float shotsPerSec = 6f;
    public float reloadTime{get{
        return 1 / shotsPerSec;
    }}

    private Coroutine firingRoutine;
    
    public bool reloading {get;private set;}
    
    public bool autoFire {get; private set;}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(){
        if(reloading) return;

        GameObject b = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
        
        b.layer = bulletLayer;

        BulletController controller = b.GetComponent<BulletController>();
        
        controller.Fire();

        StartCoroutine(Reload());
    }

    public void FireAuto(bool fire){
        autoFire = fire;

        if(!autoFire && firingRoutine != null){
            StopCoroutine(firingRoutine);
            firingRoutine = null;
        }

        else if(autoFire && firingRoutine == null){
            firingRoutine = StartCoroutine(RecursiveFire());
        }
    }

    private IEnumerator RecursiveFire(){
        if(reloading){
            yield return new WaitUntil(() => !reloading);
        }

        if(!autoFire){
            yield break;
        }

        Fire();

        firingRoutine = StartCoroutine(RecursiveFire());
    }

    private IEnumerator Reload(){
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
    }
}

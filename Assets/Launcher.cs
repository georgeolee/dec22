using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(){
        GameObject b = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
        BulletController controller = b.GetComponent<BulletController>();
        controller.Fire();
    }
}

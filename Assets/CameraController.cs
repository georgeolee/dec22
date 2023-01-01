using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTarget;

    public float lerpFactor = 10f;
    public bool following = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(followTarget && following){
            transform.position = Vector3.Lerp(
                transform.position,
                new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z),
                lerpFactor * Time.deltaTime);
        }
    }
}

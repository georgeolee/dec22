using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;
    
    private Vector2 pointerScreenPos;
    private Vector2 pointerWorldPos;
    

    public float speed = 6;
    
    // Start is called before the first frame update
    void Start()
    {                
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += (Vector3)(moveInput * speed * Time.deltaTime);
        
        pointerWorldPos = Camera.main.ScreenToWorldPoint(pointerScreenPos);

        //rotate towards mouse position
        transform.rotation = Quaternion.FromToRotation(Vector3.up, new Vector3(
            pointerWorldPos.x - transform.position.x,
            pointerWorldPos.y - transform.position.y,
            0
        ));
        
    }

    public void OnMoveInput(InputAction.CallbackContext context){                
        moveInput = context.ReadValue<Vector2>();
    }


    public void OnPointInput(InputAction.CallbackContext context){
        //pos in screen pixels
        pointerScreenPos = context.ReadValue<Vector2>();        
    }

    public void OnFireInput(InputAction.CallbackContext context){
        
        //input callback fires whenever input state changes ; only continue if in start phase (button down)
        if(context.phase != InputActionPhase.Started) return;
        
        Launcher launcher = GetComponent<Launcher>();

        if(!launcher) return;

        launcher.Fire();
    }
}

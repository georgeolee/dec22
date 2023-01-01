using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Parallax : MonoBehaviour
{
    private Material mat;

    public Transform player;
    public float factor = 0.1f;

    private Vector3 lastPlayerPos;
    private Vector2 offset;

    public bool invertX = false;
    public bool invertY = false;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        lastPlayerPos = player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(lastPlayerPos.Equals(player.position) == false){
            Vector3 delta = player.position - lastPlayerPos;
            
            offset += (Vector2) delta * factor * new Vector2(invertX ? -1 : 1, invertY ? -1 : 1);
            mat.SetVector("_offset", offset);
            lastPlayerPos = player.position;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext ctx){

    }
}

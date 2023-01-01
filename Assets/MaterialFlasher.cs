using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class MaterialFlasher : MonoBehaviour
{
    private Material mat;

    [Header("material param")]
    public string materialParameter;

    public float restingValue = 0f;
    public float flashingValue = 1f;

    private Coroutine rampRoutine;
    private Coroutine flashRoutine;

    [Header("envelope")]

    public float attack = 0;
    public float sustain = 0.1f;
    public float release = 0.1f;


    // private bool ramping

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flash(){
        StopCoroutines();
        
        flashRoutine = StartCoroutine(DoFlash(attack, sustain, release));

    }
    
    private IEnumerator Ramp(float from, float to, float secs){        

        float startTime = Time.time;

        while(Time.time - startTime < secs){
            float t = (startTime - Time.time) / secs;
            
            float val = Mathf.Lerp(from, to, t);

            mat.SetFloat(materialParameter, val);
            
            yield return null;
        }

        mat.SetFloat(materialParameter,to);
    }

    private void StopCoroutines(){
        if(rampRoutine != null){
            StopCoroutine(rampRoutine);
            rampRoutine = null;
        }
        if(flashRoutine != null){
            StopCoroutine(flashRoutine);
            flashRoutine = null;
        }
    }

    private IEnumerator DoFlash(float attack, float sustain, float release){
        
        if(attack > 0){
            rampRoutine = StartCoroutine(Ramp(mat.GetFloat(materialParameter), flashingValue, attack));
        
            yield return new WaitForSeconds(attack);
        }
        
        if(sustain > 0){
            yield return new WaitForSeconds(sustain);
        }

        if(release > 0){
            rampRoutine = StartCoroutine(Ramp(flashingValue, restingValue, release));
        }        
    }

    void OnDestroy(){
        Destroy(mat);
    }
}

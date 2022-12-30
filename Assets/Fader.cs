using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private SpriteRenderer sprite;
    
    [SerializeField]
    private bool destroyOnFinish = true;

    [SerializeField]
    private bool fadeOnStart = true;

    [SerializeField]
    private float fadeDuration = 0.5f;

    [SerializeField]
    private float startDelay = 0f;

    public bool isFading {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if(fadeOnStart){
            StartFade();
            Debug.Log("fade on start");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFade(){
        if(isFading) return;
        Debug.Log("starting fade");
        isFading = true;
        StartCoroutine(FadeOut(fadeDuration));
    }

    private IEnumerator FadeOut(float secs){
        
        yield return new WaitForSeconds(startDelay);

        float startAlpha = sprite.color.a;
        float startTime = Time.time;
        while(Time.time - startTime < secs){
            float elapsed = Time.time - startTime;

            float a = Mathf.Lerp(startAlpha, 0, elapsed / secs);
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, a);
            yield return null;
        }
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);

        if(destroyOnFinish){
            Destroy(gameObject);
        }else{
            isFading = false;
        }
    }
}

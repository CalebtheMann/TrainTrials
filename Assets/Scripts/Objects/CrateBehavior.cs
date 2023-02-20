using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehavior : MonoBehaviour
{
    public RopeBehavior Rope;
    bool fall = false;
    bool crateFallen = false;
    [SerializeField] float timeFalling;
    Vector2 startingPosition;
    private Coroutine StillFalling;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Rope.Cut)
        {
            CrateTime();
            return;
        }
    }

    public void CrateTime()
    {
        if (StillFalling == null && !crateFallen)
        {
            StillFalling = StartCoroutine(FallTime());
            crateFallen = true;
        }
    }
    public IEnumerator FallTime()
    {
        float Timer = timeFalling;
        while (Timer > 0)
        {
            Vector2 newPosition = transform.position;
            newPosition.y -= 1 * Time.deltaTime;
            transform.position = new Vector2(newPosition.x, newPosition.y);
            Timer -= Time.deltaTime;
            yield return null;
        }
    }
}

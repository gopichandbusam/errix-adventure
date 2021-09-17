using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool flying = false;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        flying = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!flying)
        {
            StartCoroutine(PlayAnim());
            flying = true;
        }
    }

    IEnumerator PlayAnim()
    {
        anim.Play("Touched");
        yield return new WaitForSeconds(1f);
        anim.StopPlayback();
        yield return new WaitForSeconds(0.1f);
        anim.Play("Flying");
    }
}
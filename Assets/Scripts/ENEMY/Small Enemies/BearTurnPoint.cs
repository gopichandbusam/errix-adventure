using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTurnPoint : MonoBehaviour
{
    [SerializeField]
    EnemyParticleSys enemyParticleSys;
    public float moveSpeed = 1;
    public bool movingRight;
    public Animator anim;
    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (movingRight)
        {
            transform.Translate(2 * Time.deltaTime * -moveSpeed, 0, 0);
            
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * -moveSpeed, 0, 0);
            
        }
        if (enemyParticleSys.Dead)
        {
            moveSpeed = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Turn"))
        {
            if (movingRight)
            {
                transform.Rotate(0f, 0f, 0f);
                movingRight = false;
            }
            else
            {
                transform.Rotate(0f, 180f, 0f);
                movingRight = true;
            }
        }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BearTurnPoint : MonoBehaviour
// {
//     [SerializeField]
//     EnemyParticleSys enemyParticleSys;
    

//     public float moveSpeed = 1;
//     public bool freezeTime;
//     public bool movingRight;
//     public Animator anim;
//     Rigidbody2D rb;


//     private void Start()
//     {
//         freezeTime = false;
//         rb = GetComponent<Rigidbody2D>();
//     }

//     private void FixedUpdate()
//     {
        
        
//         if (movingRight)
//         {
            
            
//             if(!freezeTime)
//             {
//                 transform.Translate(2 * Time.deltaTime * -moveSpeed, 0, 0);
                
//             }
//             else
//             {
//                 transform.Translate(0,0,0);
//             }
            
//         }
//         if(!movingRight)
//         {
           
            
//              if(!freezeTime)
//             {
//                 transform.Translate(-2 * Time.deltaTime * -moveSpeed, 0, 0);
                
//             }
//             else
//             {
//                 transform.Translate(0, 0, 0);
//             }
//         }
//         if (enemyParticleSys.Dead)
//         {
//             moveSpeed = 0;
           


//         }
//     }
//     void OnTriggerEnter2D(Collider2D trig)
//     {
//         Vector3 flipped = transform.localScale;
//             flipped.z *= -1f;
//         if (trig.gameObject.CompareTag("Turn"))
//         {
//             if (movingRight)
//             {
//                 movingRight = false;
//                 transform.localScale = flipped;
            
//             transform.Rotate(0f, 180f, 0f);
//             }
//             if(!movingRight)
//             {
//                  movingRight = true;
//                 transform.localScale = flipped;
            
//             transform.Rotate(0f, 0f, 0f);
//                 //  transform.localScale = flipped;
//                 //  transform.Rotate(0f, -180f, 0f);
                
//                 // movingRight = true;
//             }
//         }
//     }
// }

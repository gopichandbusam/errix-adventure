using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy_Behaviour : MonoBehaviour {

    #region Public Variables
    public string attackName;
    public float attackDistance; //Minimum distance for attack
    public float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    [HideInInspector]public  Transform target;
    [HideInInspector]public bool inRange; //Check if Player is in range
    public Transform leftLimit;
    public int Helath = 100;
    public BossHealth bossHealth;
    public int maxHealth = 100;
    public Transform rightLimit;
    public GameObject hotZone;
    public GameObject triggerArea;
    public int Damage_player;
    public Transform rayCastTransForm;
    public GameObject damageTextPrefab;
    int textToDisplay;
    #endregion

    #region Private Variables
    private Animator anim;
    private float distance; //Store the distance b/w enemy and player
    private bool attackMode;
    private bool cooling; //Check if Enemy is cooling after attack
    private float intTimer;
    #endregion

    void Awake()
    {
        bossHealth.SetMaxhealth(maxHealth);
        SelectTarget();
        intTimer = timer; //Store the inital value of timer
        anim = GetComponent<Animator>();
    }

    void Update () {
        if(!attackMode)
        {
            Move();
        }
        if(!InsideLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName(attackName))
        {
            SelectTarget();

        }
        

        //When Player is detected
        
        if(inRange)
        {
            
           EnemyLogic(); 
        }
	}
     public void TakeDamage(int damage) // The health is reduced in the bullet Script
    {
        if(Helath > 0)
        {
             Helath -= damage;
             textToDisplay = damage;
         bossHealth.SetHealth(Helath);
        }
        else if(Helath <= 0)
        {
            Debug.Log("Boss Dead");
            Destroy(this.gameObject);
            // anim.SetBool("Dead",true);
        }
        //  StartCoroutine(Damage());


    }
    internal void Floating()
    {
        Vector3 PlayerPos =  new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
       GameObject DamageTextInstance = Instantiate(damageTextPrefab, PlayerPos, Quaternion.identity);
           DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText("-"+textToDisplay.ToString());
           Destroy(DamageTextInstance, 2f);
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if(distance > attackDistance)
        {
            
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            Attack();
            
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName(attackName))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer; //Reset Timer when Player enter Attack Range
        attackMode = true; //To check if Enemy can still attack or not
        

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

   

    public void TriggerCooling()
    {
        cooling = true;
    }
    
    private bool InsideLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x  < rightLimit.position.x;

    }
    public void SelectTarget()
    {
        float distanceToLeft  =  Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        target =  distanceToLeft > distanceToRight ? leftLimit : rightLimit;
        // if(distanceToLeft > distanceToRight)
        // {
        // target = leftLimit; 
        // }
        // else
        // {
        //     target = rightLimit;
        // }
        Flip();
    }
    public void Flip()
    {
        Vector3 rotation =  transform.eulerAngles;
    if(transform.position.x > target.position.x )
    {
        rotation.y = 180f;
    }
    else
    {
        rotation.y = 0f;
    }
      transform.eulerAngles =  rotation;
    }
   

}

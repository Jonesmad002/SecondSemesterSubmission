using UnityEngine;
using System.Collections;

public class SharedPlayerActions : MonoBehaviour
{
    // Connects to the Animator component
    private Animator anim;
    private EnemyWeaponScript attacker;

    public bool test = true;

    //public SharedEnemyActions attack;
    public Mover mov;

    // Called as the script is loading
    private void Awake()
    {
        // Assigns varibles their items
        if(GetComponent<Animator>() != null)
        {
            anim = GetComponent<Animator>();
        }
        mov = gameObject.GetComponentInParent<Mover>();
        //attack = GameObject.FindGameObjectWithTag("ShareEnemy").GetComponent<SharedEnemyActions>();
        attacker = GameObject.FindGameObjectWithTag("EnemyHurt").GetComponent<EnemyWeaponScript>();

    }

    // Hurts the player
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if item hit is an enemy
        if (collision.GetComponent<EnemyWeaponScript>() != null)
        {
            attacker = collision.GetComponent<EnemyWeaponScript>();
            mov.active[0] = attacker.Hurt(mov.active[0]);
            anim.SetTrigger("Hurt");
        }
        if(mov.active[0] <= 0 && anim.GetBool("IsDefeat") == false)
        {
            anim.SetBool("IsDefeat", true);
            anim.SetTrigger("Defeat");
        }
    }

    /* When the player attacks and hits an enemy the enemy loses health equal to pow
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if item hit is an enemy
        if (collision.GetComponent<SharedEnemyActions>() != null)
        {
            attack = collision.GetComponent<SharedEnemyActions>();
            attack.Hit(mov.active[2]);
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        // If the player is moving they will change to their walking animation
        anim.SetFloat("isMoving", mov.move);

        // Triggers attack animation when E is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("Attack");
        }



        //----------------TESTS---------------------------------------
        if (Input.GetKeyDown(KeyCode.J))
        {
            mov.active[0]--;
            anim.SetTrigger("Hurt");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            mov.active[0]++;
            anim.SetTrigger("Attack");
        }

        if (mov.active[0] <= 0)
        {
            anim.SetBool("IsDefeat", true);
        }
        else
        {
            anim.SetBool("IsDefeat", false);
        }
    }
}


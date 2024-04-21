using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponScript : MonoBehaviour
{
    public int damaged = 2000;
    private SharedEnemyActions boss;

    // Start is called before the first frame update
    void Start()
    {
        boss = gameObject.GetComponentInParent<SharedEnemyActions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SharedPlayerActions>() != null)
        {
            int endDamage = Hurt(target.active[0], target.active[1], 3);
            target.active[0] = endDamage;
        }
    }*/

    public int Hurt(int opHealth)
    {
        boss.anim.SetTrigger("Attack");
        return opHealth -= damaged;
    }

    public void Defeast()
    {
        gameObject.SetActive(false);
    }

}
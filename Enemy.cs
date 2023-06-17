using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyType{Normal, Shooter}
    public EnemyType currentType;

    public float speed;
    public int damage;

    [Header("Shooter Stuff")]
    public float Shooter_StopPointX;
    public float Shooter_TimeDelay;
    public float Shooter_BulletForce;
    public GameObject pf_enemyBullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            gameObject.GetComponent<Heathbody>().ReduceHealth(GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().damage);
        }else if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Heathbody>().ReduceHealth(damage);
        }
        else if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }

    }
    bool ShooterAttack = false;
    public void Update()
    {
        if(currentType == EnemyType.Normal)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }else if (currentType == EnemyType.Shooter && !ShooterAttack)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
            if(transform.position.x < Shooter_StopPointX)
            {
                ShooterAttack = true;
                StartCoroutine(shooterBulletSpawn());
            }
        }
    }
    IEnumerator shooterBulletSpawn()
    {
        GameObject bullet = Instantiate(pf_enemyBullet, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(-transform.right * Shooter_BulletForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(Shooter_TimeDelay);
        ShooterAttack = false;
        StopAllCoroutines();
    }
}

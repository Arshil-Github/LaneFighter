using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public int speed;
    public int damage;
    public float bulletSpeed;

    public Transform[] positions;
    public GameObject pf_bullet;
    public Transform gunTip;

    bool isAllowedtoAttack = true;


    int currentPlatform; //Can be 0 1 or 2
    bool startMove;
    private void Start()
    {
        transform.position = positions[1].position;
        currentPlatform = 1;
        startMove = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            MoveDown();
        else if (Input.GetKeyDown(KeyCode.W))
            MoveUp();

        if (Input.GetButtonDown("Fire1"))
            MeleeAttack();
        else if (Input.GetButtonDown("Fire2"))
            Shoot();

        if (Input.GetKeyDown(KeyCode.O))
        {
            print(Input.GetAxis("Vertical"));
        }
    }
    #region MovementStuff
    public void MoveUp()
    {
        if(currentPlatform != 0)
        {
            currentPlatform -= 1;
            startMove = true;
        }
        else
        {
            currentPlatform = 2;
        }
    }
    public void MoveDown()
    {
        if (currentPlatform != 2)
        {
            currentPlatform += 1;
            startMove = true;
        }
        else
        {
            currentPlatform = 0;
        }
    }
    #endregion

    public void Shoot()
    {
        GameObject bulletSpawned = Instantiate(pf_bullet, gunTip.position, Quaternion.identity);

        bulletSpawned.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }
    public void MeleeAttack()
    {
        
    }
   
    public void FixedUpdate()
    {
        if (startMove)
        {
            transform.position += (positions[currentPlatform].position - transform.position) * speed * Time.deltaTime;
        }
        if(transform.position == positions[currentPlatform].position)
        {
            startMove = false;
        }
    }

}

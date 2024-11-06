using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D projectileRigidBody;
    public float speed;

    public float projectileLife;
    public float projectileCount;

    public PlayerMovement playerMovement;
    public bool facingRight;

    AudioManager audioManager;

    //Find audio clip
    private void Awake()
    {
        //Find audio tag
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        facingRight = playerMovement.facingRight;
        if(!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if(projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(facingRight)
        {
            projectileRigidBody.velocity = new Vector2(speed, projectileRigidBody.velocity.y);
        }
        else
        {
            projectileRigidBody.velocity = new Vector2(-speed, projectileRigidBody.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Weak Point")
        {
            Destroy(collision.gameObject);
            audioManager.PlaySFX(audioManager.captureMonster); //Audio when capturing monster
        }
        Destroy(gameObject);
    }
}

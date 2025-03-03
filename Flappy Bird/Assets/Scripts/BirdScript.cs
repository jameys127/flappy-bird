using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    private float deadZoneTop = 40;
    private float deadZoneBottom = -27;
    public LogicScript logicScript;
    private bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive){
            myRigidBody.velocity = Vector2.up * flapStrength;
        }
        if(transform.position.y > deadZoneTop || transform.position.y < deadZoneBottom){
            Destroy(gameObject);
            logicScript.GameOver();
            birdIsAlive = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOver();
        birdIsAlive = false;
    }
}

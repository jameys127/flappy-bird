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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true){
            myRigidBody.velocity = Vector2.up * flapStrength;
        }
        if(transform.position.y > deadZoneTop || transform.position.y < deadZoneBottom){
            Destroy(gameObject);
        }
    }
}

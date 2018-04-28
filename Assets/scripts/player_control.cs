using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour {

    public float runningSpeed;
    public float rotation_speed;
    public float walking_spped;
    private Rigidbody rd;
    //private Animator An;
    private bool flageRight;


    //for jump
    //public LayerMask groundlayer;
    //public Transform groundcheck;
    //public float jumphight;
    //bool grounded = false;
    //float groundradious = 0.2f;
    //public Collider[] groundcollisions;


    // Use this for initialization
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        //An = GetComponent<Animator>();
        flageRight = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    void FixedUpdate()
    {
        //if (grounded && Input.GetAxis("Jump") > 0)
        //{
          //  grounded = false;
           // An.SetBool("grounded", grounded);
           // rd.AddForce(new Vector3(0, jumphight, 0));
        //}

        //groundcollisions = Physics.OverlapSphere(groundcheck.position, groundradious, groundlayer);
        //if (groundcollisions.Length > 0) grounded = true;
        //else grounded = false;
        //An.SetBool("grounded", grounded);

        //An.SetFloat("speed", Mathf.Abs(move));


        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        transform.Rotate(0, x * rotation_speed * Time.deltaTime, 0);

        float seaking = Input.GetAxis("Fire3");
        //An.SetFloat("sneaking", seaking);
        if (seaking > 0)
        {
            transform.Translate(0, 0, z * walking_spped * Time.deltaTime);
        }
        else
        {
            transform.Translate(0, 0, z * runningSpeed * Time.deltaTime);
        }
       
        //if (move > 0 && !flageRight) Flip();
        //else if (move < 0 && flageRight) Flip();
    }

    private void Flip()
    {
        flageRight = !flageRight;
        Vector3 localscale = transform.localScale;
        localscale.z *= -1;
        transform.localScale = localscale;
    }
}

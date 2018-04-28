using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_control : MonoBehaviour {

	public float runningSpeed;
    public float rotation_speed;
    public float rotation_H_speed;
    public float walking_spped;
    private Rigidbody rd;
    private Animator An;
    private bool flageRight;

    public int test = 0;

    //for jump
    public float jumphight;
    private bool grounded = true;
    public GameObject leg;

    public LayerMask groundlayer;
    public CapsuleCollider col;

    private bool rotate_right_state = false;

    private float state_of_camira_H = 0;
    public GameObject mainCamera;


    // Use this for initialization
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        An = GetComponent<Animator>();
        flageRight = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    void FixedUpdate()
    {

        An.SetBool("jumbing", false);
        //////////////////////////////////////////////////////////////// jumbing
        if (IsGrounded() && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            An.SetBool("jumbing", true);
            rd.AddForce(new Vector3(0, jumphight, 0), ForceMode.Impulse);
        }
        ////////////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////////// moving
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        transform.Rotate(0, Input.GetAxis("Mouse X") * rotation_speed * Time.deltaTime, 0);

        state_of_camira_H -= Input.GetAxis("Mouse Y") * rotation_H_speed;
        state_of_camira_H = Mathf.Clamp(state_of_camira_H, -15, 35);
        float rotationY = mainCamera.transform.localEulerAngles.y;
        mainCamera.transform.localEulerAngles = new Vector3(state_of_camira_H , rotationY, 0);

        //shotingPoint.transform.Rotate(-1 *  * Time.deltaTime, 0, 0);


        float seaking = Input.GetAxis("Fire3");
        if (seaking <= 0 || !IsGrounded())
        {
            An.SetBool("walk_right", false);
            if (x != 0)
            {
                An.SetBool("walk_right", true);
                transform.Translate(x * walking_spped * Time.deltaTime, 0, 0);
            }
            transform.Translate(0, 0, z * walking_spped * Time.deltaTime);
            if ( z > 0)
            {
                An.SetBool("walking_forward", true);
                An.SetBool("running_forward", false);
            }
            else if (z < 0)
            {
                An.SetBool("walking_backword", true);
                An.SetBool("running_backword", false);
            }
            else
            {
                stop_();
            }
        }
        else
        {
            An.SetBool("walk_right", false);
            if (x != 0)
            {
                An.SetBool("walk_right",true);
                transform.Translate(x * runningSpeed * Time.deltaTime, 0, 0);
            }
            transform.Translate(0, 0, z * runningSpeed * Time.deltaTime);
            if (z > 0)
            {
                An.SetBool("walking_forward", false);
                An.SetBool("running_forward", true);
            }
            else if (z < 0)
            {
                An.SetBool("running_backword", true);
            }
            else
            {
                stop_();
            }
        }
        ////////////////////////////////////////////////////////////////////
       
        //if (move > 0 && !flageRight) Flip();
        //else if (move < 0 && flageRight) Flip();
    }


    private void rotate_at_side(float x)
    {
        if(!rotate_right_state)
        {
            if (x > 0)
            {
                transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + 6);
            }
            else
            {
                transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z - 6);
            }
            rotate_right_state = true;
        }        
    }

    private void stop_()
    {
        An.SetBool("walking_backword", false);
        An.SetBool("walking_forward", false);
        An.SetBool("running_forward", false);
        An.SetBool("running_backword", false);
    }

  

    private bool IsGrounded()
    {
        //return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius*.9f, groundlayer);
        if (col.bounds.center.y <= 1)
            return true;
        else
            return false;
    }


}

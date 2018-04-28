using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webon_contro : MonoBehaviour {

    //public GameObject hand;
    private Transform webon_transform;

    public float damage = 10f;
    public float range = 100f;
    public GameObject shootingPoint;
    public LayerMask layerOfenaimes;
    public Vector3 pluspositions;
    public Quaternion plusrotation;
    public ParticleSystem muzzleFlash;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public float nextTimeToFire = 0f;

    // Use this for initialization
    void Start()
    {
        webon_transform = GetComponent<Transform>();

        //webon_transform.transform.position = new Vector3(7.511475f,9.046994f,-6.523208f);
        //webon_transform.transform.rotation = new Quaternion(-57.717f,91.50101f,104.021f,0);
        //webon_transform.transform.localScale = new Vector3(400,400,400);  
    }
	
	// Update is called once per frame
	void FixedUpdate() {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            shote();
        }
    }

    private void shote()
    {
        Ray ray = Camera.main.ScreenPointToRay(shootingPoint.transform.position);
        RaycastHit hit;
        muzzleFlash.Play();

        if(Physics.Raycast(ray,out hit,range,layerOfenaimes))
        {
            Debug.Log(hit.transform.name);
            enamiesProperties target = hit.transform.GetComponent<enamiesProperties>();
            if (target != null)
            {
                target.Shoot(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}

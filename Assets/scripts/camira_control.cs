using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camira_control : MonoBehaviour {

    public float minRotValue = -45f;
    public float maxRotValue = 45f;

    public float _rotationInput = 0;
    public float rotatSpeed = 10f;

    void LateUpdate()
    {
        
        _rotationInput = Input.GetAxis("Mouse x") * rotatSpeed * Time.deltaTime;
        transform.Rotate(_rotationInput, 0, 0);
        //_rotationInput = Mathf.Clamp(_rotationInput, minRotValue, maxRotValue);
        //float rotationY = transform.localEulerAngles.y;
        //transform.localEulerAngles = new Vector3(_rotationInput, rotationY, 0);
    }
}

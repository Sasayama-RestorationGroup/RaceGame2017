using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{

    public GameObject objTarget;
    private Vector3 direction;
    private Vector3 distance;
    private float disty;


    void Start()
    {
        this.transform.position = objTarget.transform.position;
        disty = 2.0f;
    }

    void LateUpdate()
    {
            direction = objTarget.transform.forward;
            distance = objTarget.transform.position - direction * 4;
            this.transform.position = new Vector3(distance.x, objTarget.transform.position.y + disty, distance.z);
            this.transform.LookAt(objTarget.transform);
            this.transform.eulerAngles = new Vector3(20.0f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
    }
}
using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{

    public GameObject objTarget;
    private Vector3 direction;
    private Vector3 distance;
    private float dist_y;


    void Start()
    {
        this.transform.position = objTarget.transform.position;
        dist_y = 3.0f;
    }

    void LateUpdate()
    {
            direction = objTarget.transform.forward;
            distance = objTarget.transform.position - direction * 6;
            this.transform.position = new Vector3(distance.x, objTarget.transform.position.y + dist_y, distance.z);
            this.transform.LookAt(objTarget.transform);
            this.transform.eulerAngles = new Vector3(20.0f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
    }
}
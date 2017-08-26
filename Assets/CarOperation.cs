using UnityEngine;
using System.Collections;

public class CarOperation : MonoBehaviour {
    public float topspeed;
    public float acceleration;
    public float turning;
    public float tall;
    private Vector3 speed;
   //public float Weight;
    private RaycastHit hit;
    private bool ishit = false;

    void Start () {
	}

    void Update ()
    {
        //ishit = Physics.SphereCast(transform.position, 1.0f, Vector3.down, out hit, 0.5f);
        ishit = Physics.SphereCast(transform.position, 0.1f, Vector3.down, out hit, tall);

        if (ishit == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Vector3 temp = ((transform.forward * topspeed) - speed).normalized;
                speed += temp * acceleration * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Vector3 temp = ((-transform.forward * topspeed) + speed).normalized;
                speed += temp * acceleration * Time.deltaTime;
            }
            else
            {
                speed -= speed.normalized * acceleration / 2 * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0.0f, turning * speed.magnitude / topspeed * Time.deltaTime, 0.0f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0.0f, -turning * speed.magnitude / topspeed * Time.deltaTime, 0.0f);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0.0f, turning * speed.magnitude / (topspeed*2) * Time.deltaTime, 0.0f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0.0f, -turning * speed.magnitude / (topspeed * 2) * Time.deltaTime, 0.0f);
            }

            speed.y -= speed.normalized.y * acceleration / 3 * Time.deltaTime;
        }

        //Debug.Log(speed);
        transform.Translate(speed * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall")) {
            Debug.Log("Hit");
            speed = Vector3.zero;
        }
    }

    void OnGUI()
    {
        //GUI.Box(new Rect(0, 0, 100, 40), "" + this.GetComponent<Rigidbody>().velocity.magnitude);
    }
}

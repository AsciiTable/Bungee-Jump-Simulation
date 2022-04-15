using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    [Tooltip("Unit vector for wind direction.")]
    public Vector3 windDirection;
    public float windStrength;
    public float timeBetweenBlows;

    private float lastBlowTime;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        lastBlowTime = Time.time;
        rb = this.gameObject.GetComponent<Rigidbody>();

        if (rb == null) {
            this.gameObject.GetComponent<WindForce>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastBlowTime >= timeBetweenBlows) {
            rb.AddForce(windDirection * windStrength);
            lastBlowTime = Time.time;
        }
    }
}

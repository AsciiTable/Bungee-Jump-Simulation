using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHitController : MonoBehaviour
{
    public Material NotHit;
    public Material Hit;
    public float minHitVisualDuration;
    private float hitTimer = 0.0f;
    private bool isHit = false;

    // Update is called once per frame
    void Update()
    {
        if (isHit) {
            if (Time.time - hitTimer >= minHitVisualDuration)
            {
                isHit = false;
                gameObject.GetComponent<MeshRenderer>().material = NotHit;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isHit = true;
        hitTimer = Time.time;
        gameObject.GetComponent<MeshRenderer>().material = Hit;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (Time.time - hitTimer >= minHitVisualDuration) {
            isHit = false;
            gameObject.GetComponent<MeshRenderer>().material = NotHit;
        }
    }
}

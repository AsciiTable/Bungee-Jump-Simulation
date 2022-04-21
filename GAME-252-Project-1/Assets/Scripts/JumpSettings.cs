using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSettings : MonoBehaviour
{
    /** Variables in Simulation: 
     * 
     * Height of Jump
     * Weight of the Friend
     * Spring Constant
     * Obstacles in Area
     * Wind Speed
     * Unstretched Bungee Cord
     */

    //Simulation Game Object References
    public GameObject topPlatform; //Platform Friend is Jumping off of
    public GameObject friend; //Friend object
    public Rigidbody friendRb; //Friend rigidbody
    public SpringJoint bungeeCord; //bungee
    public WindForce windForce; //wind controls
    

    //Simulation Settings
    public float platformHeight = 45f;
    public float friendMass = 90f;
    public float springConstant = 90f;
    public float cordLength = 30f;
    
    public Vector3 windDirection = new Vector3(1,0,0);
    public float windStrength = 300f;
    public float timeBetweenBlows = 3f;

    // Start is called before the first frame update
    void Start()
    {
        topPlatform = GameObject.FindWithTag("TopPlatform");
        friend = GameObject.FindWithTag("Friend");
        friendRb = friend.GetComponent<Rigidbody>();
        bungeeCord = topPlatform.GetComponent<SpringJoint>();
        windForce = friend.GetComponent<WindForce>();

        //Set Platform Height and Friend height simultaneously
        topPlatform.transform.position = new Vector3(topPlatform.transform.position.x, platformHeight, topPlatform.transform.position.z);
        friend.transform.position = new Vector3(friend.transform.position.x, platformHeight, friend.transform.position.z);
        //Set friend Mass
        friendRb.mass = friendMass;
        //Set spring strength
        bungeeCord.spring = springConstant;
        //Set unstretched cord length
        bungeeCord.maxDistance = cordLength;
        //Set Wind settings
        windForce.windDirection = windDirection;
        windForce.windStrength = windStrength;
        windForce.timeBetweenBlows = timeBetweenBlows;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

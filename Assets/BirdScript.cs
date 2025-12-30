using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public float flapStrength = 10f;
    public LogicScript logicScript;
    private bool birdIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {

        // Find the GameObject with the "Logic" tag
        GameObject logicObject = GameObject.FindWithTag("Logic");
        if (logicObject == null)
        {
            Debug.LogError("BirdScript: No GameObject found with tag 'Logic'. Ensure a Logic manager exists and is tagged properly.");
            return;
        }

        // Get the LogicScript component from that GameObject
        logicScript = logicObject.GetComponent<LogicScript>();
        if (logicScript == null)
        {
            Debug.LogError("BirdScript: LogicScript component not found on GameObject tagged 'Logic'. Attach LogicScript to the Logic manager.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myrigidbody.velocity = Vector2.up * flapStrength;
        }
        if (transform.position.y > 17  || transform.position.y < -17)
        {
            logicScript.GameOver();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOver();
        birdIsAlive = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
   public LogicScript logicScript;
    // Start is called before the first frame update
    void Start()
    {
        // Find the GameObject with the "Logic" tag
        GameObject logicObject = GameObject.FindWithTag("Logic");
        if (logicObject == null)
        {
            Debug.LogError("PipeMiddleScript: No GameObject found with tag 'Logic'. Ensure a Logic manager exists and is tagged properly.");
            return;
        }

        // Get the LogicScript component from that GameObject
        logicScript = logicObject.GetComponent<LogicScript>();
        if (logicScript == null)
        {
            Debug.LogError("PipeMiddleScript: LogicScript component not found on GameObject tagged 'Logic'. Attach LogicScript to the Logic manager.");
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (logicScript != null)
            {
                logicScript.AddScore(1);
            }
            else
            {
                Debug.LogWarning("PipeMiddleScript: Attempted to add score but logicScript is null.");
            }
        }
    }
}

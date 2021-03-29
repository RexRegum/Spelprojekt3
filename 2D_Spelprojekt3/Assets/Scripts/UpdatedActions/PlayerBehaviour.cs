using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float Health;
    public float MaxHP;
    [Space]
    public Action left;
    public Action right;
    public Action center;
    [Space]
    public GameObject leftObject;
    public GameObject rightObject;
    public GameObject centerObject;

    

    List<Actions> actions = new List<Actions>();
    public MovementSpaces currentSpace;
    private bool yeet;

    void Awake()
    {

        actions.Add(new Actions(leftObject, KeyCode.A, MovementSpaces.Left));
        actions.Add(new Actions(rightObject, KeyCode.D, MovementSpaces.Right));
        actions.Add(new Actions(centerObject, KeyCode.W, MovementSpaces.Center));
    }

    void Update()
    {
        

        if (Input.GetKey(actions[0].keyCode))
        {
            gameObject.transform.position = actions[0].spaceObject.transform.position;
            currentSpace = actions[0].movementSpace;
        }
        else if (Input.GetKey(actions[1].keyCode))
        {
            gameObject.transform.position = actions[1].spaceObject.transform.position;
            currentSpace = actions[1].movementSpace;
        }
        else if (Input.GetKey(actions[2].keyCode))
        {
            gameObject.transform.position = actions[2].spaceObject.transform.position;
            currentSpace = actions[2].movementSpace;
        }
        else
        {
            gameObject.transform.position = actions[2].spaceObject.transform.position;
            currentSpace = actions[2].movementSpace;
        }
    }


}
public enum MovementSpaces
{
    Right, Left, Back, Center
}



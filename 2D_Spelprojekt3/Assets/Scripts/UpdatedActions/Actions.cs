using UnityEngine;

[System.Serializable]
public class Actions
{
    [SerializeField] public GameObject spaceObject;
    [SerializeField] public KeyCode keyCode;
    [SerializeField] public MovementSpaces movementSpace;

    public Actions(GameObject newSpace, KeyCode newKeyCode, MovementSpaces newMovementSpace)
    {
        spaceObject = newSpace;
        keyCode = newKeyCode;
        movementSpace = newMovementSpace;
    }
}
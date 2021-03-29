using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttackObject", menuName = "2D_Spelprojekt3/Action", order = 0)]

public class Action : ScriptableObject 
{
    public KeyCode keycode;
    public MovementSpaces movementSpaces;
    public AnimationClip actionAnimation;
    public AnimationClip spaceTransition;
}

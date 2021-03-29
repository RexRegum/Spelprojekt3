using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "EnemyAttackObject", menuName = "2D_Spelprojekt3/EnemyAttackObject", order = 0)]
public class EnemyAttackObject : ScriptableObject
{
    //public string nameOfAttack;
    public int attackDamage;
    public AnimationClip attackAnimation;
    //public int activeFramesStart;
    //public int activeFramesEnd;
    public List<string> canTransitionTo;
    public List<MovementSpaces> attackedSpaces;
    //public bool hasVulnerability;
    //public int vulnerabilityStart;
    //public int vulnerabilityEnd;
    public List<MovementSpaces> vulnerabilityAngles;

}
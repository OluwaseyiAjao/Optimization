using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
   //Enemy Hp
   public int startingHealth = 100;
   
   //Score value 
   public float sinkSpeed = 2.5f;
   public int scoreValue = 10;
   
   //Attacking 
   public float timeBetweenAttacks = 0.5f;
   public int attackDamage = 10;
}

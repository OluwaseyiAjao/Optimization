using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHealthSO", menuName = "Scriptable Objects/PlayerHealthSO")]
public class PlayerHealthSO : ScriptableObject
{
    public int startingHealth = 100;
    public int currentHealth;
}

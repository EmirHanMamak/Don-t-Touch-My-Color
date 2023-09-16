using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
[CreateAssetMenu(fileName = "Obstacles", menuName = "ScriptableObject/Obstacles")]
public class Obstacles : ScriptableObject
{
    public Color MyColor;
    public Color EnemyColor;
    
}

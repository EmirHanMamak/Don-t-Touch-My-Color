using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelDesign", menuName = "ScriptableObject/LevelDesign")]
public class LevelDesign : ScriptableObject
{
    public Color MyPlayerColor;

    public Color FriendlyColor;
        
    public Color EnemyColor;
        
    public Color GroundColor;
/*
 * Renk Olacaklar
1- Ground
2- Enemy
3- Friendly
4- Player
 */
    
}

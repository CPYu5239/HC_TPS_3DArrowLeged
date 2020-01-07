using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData" ,menuName = "GameData/敵人資料")]
public class EnemyData : ScriptableObject
{
    [Header("血量"),Range(10,3000)]
    public float hp = 100;
    [Header("攻擊力"),Range(10,100)]
    public float attack = 10;
    [Header("移動速度")]
    public float speed = 1.5f;
    [Header("攻擊冷卻時間")]
    public float cd = 3.5f;
    
}

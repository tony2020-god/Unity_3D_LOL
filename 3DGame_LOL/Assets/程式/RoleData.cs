using UnityEngine;

[CreateAssetMenu(fileName ="英雄資料",menuName ="KID/英雄資料")]
public class RoleData : ScriptableObject
{
    //血量
    [Header("血量"),Range(100,800)]
    public float hp;
    //魔力
    [Header("魔力"),Range(50,400)]
    public float mp;
    //移動速度
    [Header("移動速度"),Range(0.5f,50f)]
    public float speed;
    //普通攻擊
    [Header("普攻"),Range(0f,500f)]
    public float attack;
    [Header("普攻冷卻"), Range(0, 10f)]
    public float attackcd;
    [Header("技能組")]
    public Skill[] skills;
}
//序列化: 將類別資料顯示在屬性面板上
[System.Serializable]
public class Skill
{
    public string name;

    [Header("攻擊"),Range(0,100f)]
    public float attack;
    [Header("消耗"), Range(0, 100f)]
    public float cost;
    [Header("圖片")]
    public Sprite image;
    [Header("冷卻"), Range(0, 100f)]
    public float cd;
}
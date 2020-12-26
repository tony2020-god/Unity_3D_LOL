using UnityEngine;

public class HeroBase : MonoBehaviour
{
    /// <summary>
    /// 技能計時器，累加時間用
    /// </summary>
    private float[] skillTimer = new float[4];
    public RoleData data;
    private Animator ani;
    /// <summary>
    /// 技能是否開始
    /// </summary>
    private bool[] skillStart = new bool[4];
    //protected 保護 - 允許子類別存取
    //virtual 虛擬 - 允許子類別複寫
    protected virtual void Awake()
    {
        ani = GetComponent<Animator>();

    }
    private void Update()
    {
        TimeControl();
    }
    private void TimeControl()
    {
        for(int i = 0;  i< 4; i++)
        {
            if (skillStart[i])
            {
                skillTimer[i] += Time.deltaTime;

                //如果 計時器 >= 冷卻時間 就 歸零並且設定為 尚未開始
                if (skillTimer[i] >= data.skills[i].cd)
                {
                    skillTimer[i] = 0;
                    skillStart[i] = false;
                }
            }
        }
        
    }
    public void Move()
    {

    }
    public void Skill1()
    {
        ani.SetTrigger("技能1");
        skillStart[0] = true;
    }
    public void Skill2()
    {
        ani.SetTrigger("技能2");
        skillStart[1] = true;
    }
    public void Skill3()
    {
        ani.SetTrigger("技能3");
        skillStart[2] = true;
    }
    public void Skill4()
    {
        ani.SetTrigger("大招");
        skillStart[3] = true;
    }
}

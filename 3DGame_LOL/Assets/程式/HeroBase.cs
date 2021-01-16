using UnityEngine;
using UnityEngine.UI;

public class HeroBase : MonoBehaviour
{
    /// <summary>
    /// 技能計時器，累加時間用
    /// </summary>
    protected float[] skillTimer = new float[4];
    public RoleData data;
    private Animator ani;
    private Rigidbody rig;
    [Header("重生點")]
    public Transform restart;
    [Header("圖層")]
    public int layer;
    public float restartTime = 3;

    /// <summary>
    /// 血量
    /// </summary>
    private float hp;
    /// <summary>
    /// 畫布血條
    /// </summary>
    private Transform canvasHp;
    /// <summary>
    /// 血量
    /// </summary>
    private Image imgHp;
    /// <summary>
    /// 血量文字
    /// </summary>
    private Text textHp;
    private float hpMax;

    /// <summary>
    /// 技能是否開始
    /// </summary>
    protected bool[] skillStart = new bool[4];
    //protected 保護 - 允許子類別存取
    //virtual 虛擬 - 允許子類別複寫
    protected virtual void Awake()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();

        //取得畫布並更新血條文字
        canvasHp = transform.Find("血條畫布");
        canvasHp.Find("血量").GetComponent<Text>().text = data.hp.ToString();
        textHp = canvasHp.Find("血量").GetComponent<Text>();
        textHp.text = data.hp.ToString();
        imgHp = canvasHp.Find("血條").GetComponent<Image>();
    }
    private void Dead()
    {
        textHp.text = "0";
        enabled = false;
        ani.SetBool("死亡開關",true);
        gameObject.layer = 0; //避免鞭屍

        Invoke("Reset", restartTime);

    }
    private void Reset()
    {
        hp = hpMax;
        textHp.text = hp.ToString();
        imgHp.fillAmount = 1;
        gameObject.layer = layer;
        transform.position = restart.position;
        ani.SetBool("死亡開關", false);
    }
    private void Start()
    {
        hp = data.hp;
        hpMax = hp;
    }
    protected virtual void Update()
    {
        TimeControl();
    }
    public void Damage(float damage)
    {
        hp -= damage;
        textHp.text = hp.ToString();
        imgHp.fillAmount = hp / hpMax;

        if (hp <=0)
        {
            Dead();
        }
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
    /// <summary>
    /// 移動
    /// </summary>
    protected virtual void Move(Transform target)
    {
        Vector3 pos = rig.position;
        //剛體.移動座標(座標)
        rig.MovePosition(target.position);
        //看向(目標物件)
        transform.LookAt(target);
        //動畫.設定布林值(跑步參數,現在座標 不等於 前面座標)
        ani.SetBool("跑步開關", rig.position != pos);
        canvasHp.eulerAngles = new Vector3(23.6f,-14.5f,2.18f);
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

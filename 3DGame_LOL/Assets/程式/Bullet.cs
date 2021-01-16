using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("要追蹤的物件")]
    public Transform target;
    [Header("追蹤速度")]
    public float speed = 3;

    public float atk;
    /// <summary>
    /// 攻擊力
    /// </summary>
    public float afk;
    private void Track()
    {
        Vector3 posA = target.position;
        Vector3 posB = transform.position;

        posB = Vector3.Lerp(posB, posA, 0.5f * speed * Time.deltaTime);
        transform.position = posB;

        if (Vector3.Distance(posB,posA) < 1)
        {
            target.GetComponent<HeroBase>().Damage(afk);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Track();
    }
}

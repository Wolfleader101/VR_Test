using UnityEngine;


[CreateAssetMenu(menuName = "Scriptables/Bullet")]
public class BaseBullet : ScriptableObject
{
    [SerializeField] private float speed = 100f;
    public float Speed => speed;
        
    [SerializeField]
    private int damage =  15;
    public int Damage => damage;

    [SerializeField] private float destroyTime = 8f;
    public float DestroyTime => destroyTime;
    
    [SerializeField] private float casingDestroyTime = 4f;
    public float CasingDestroyTime => casingDestroyTime;
}
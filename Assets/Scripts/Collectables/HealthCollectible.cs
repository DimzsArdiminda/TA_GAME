using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class HealthCollectible : PoolingObject<HealthCollectible>, IHealthRestorer, IResettable, IObstacle
{
    public BoxCollider Collider { get; private set; }
 
    private void Awake()
    {
        Collider = GetComponent<BoxCollider>();
    }
    public void ResetToDefault()
    {   
        transform.localPosition = Vector3.zero;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
    public void Impact()
    {
        ResetToDefault();
    }
    public void RestoreHealth(IHealable target, int amount)
    {   
        target.Heal(amount);
    }
}

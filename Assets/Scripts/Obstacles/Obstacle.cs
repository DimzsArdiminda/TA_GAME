using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Obstacle : PoolingObject<Obstacle>, IObstacle,IDamageDealer,IResettable
{
    
    [field: SerializeField] public bool IsOnAllLanes { get; private set; }
    [field: SerializeField] public bool IsInevitable { get; private set; }
    public BoxCollider Collider { get; private set; }
    
    AudioManager audioManager;

    private void Awake()
    {
        Collider = GetComponent<BoxCollider>();
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager tidak ditemukan!");
        }
    }

    public void ResetToDefault()
    {   
        transform.localPosition = Vector3.zero;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        gameObject.transform.SetParent(OwningPool.transform);
        ReturnToPool();
    }
    public void Impact()
    {
        // audioManager.PlaySFXByName("HitObstacle");
        ResetToDefault();
        if (audioManager != null)
        {
            audioManager.PlaySFXByName("HitObstacle");
        }
        else
        {
        Debug.LogWarning("AudioManager tidak ditemukan!");
        }
    }

    public void DealDamage(IDamageable target, int amount)
    {
        target.TakeDamage(amount);
    }
}

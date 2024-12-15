using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class HealthCollectible : PoolingObject<HealthCollectible>, IHealthRestorer, IResettable, IObstacle
{
    public BoxCollider Collider { get; private set; }

    // AudioManager audioManager;

    private void Awake()
    {
        Collider = GetComponent<BoxCollider>();
        // audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
        // if (audioManager == null)
        // {
        //     Debug.LogError("AudioManager tidak ditemukan!");
        // }
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
        // if (audioManager != null)
        // {
        //     audioManager.PlaySFXByName("HealthRechargePoint");
        // }
    }
    public void RestoreHealth(IHealable target, int amount)
    {   
        target.Heal(amount);
    }
}

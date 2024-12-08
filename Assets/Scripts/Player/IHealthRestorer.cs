using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthRestorer 
{
    public void RestoreHealth(IHealable target,int amount);
}

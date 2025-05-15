using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHealth : MonoBehaviour
{
    [SerializeField] private TankHealth player;
    public void RaiseMaxHealth()
    {
        player.IncreaseMaxHealth();
    }
}

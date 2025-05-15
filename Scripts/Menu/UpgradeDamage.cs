using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDamage : MonoBehaviour
{
    [SerializeField] private TankShooting player;
    public void changeDamage()
    {
        player.chargeUpgrade();
    }
}

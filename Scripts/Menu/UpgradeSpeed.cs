using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpeed : MonoBehaviour
{
    [SerializeField] private TankMovement player;
    public void changeSpeed()
    {
        player.updateSpeed();
    }
}

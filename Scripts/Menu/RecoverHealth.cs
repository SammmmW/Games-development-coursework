using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverHealth : MonoBehaviour
{
    [SerializeField] private TankHealth player;
    public void healHealth()
    {
        player.Recover();
    }
}

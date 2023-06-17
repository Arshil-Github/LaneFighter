using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RewardBarReward
{
    public enum Rewards {coin, diamond, grenade};
    public Rewards reward;

    public int quantity;
}

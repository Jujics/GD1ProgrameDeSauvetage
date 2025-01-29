using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int addScore;
    public ScoreManager ScoreManager;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        ScoreManager.AddScore(addScore);
    }
}

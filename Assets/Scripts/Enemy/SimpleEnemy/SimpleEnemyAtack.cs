using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyAtack : IAtack
{
    public void Atack()
    {
        Debug.LogError("Atack");
    }
}

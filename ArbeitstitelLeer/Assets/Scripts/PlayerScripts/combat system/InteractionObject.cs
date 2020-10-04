using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public string targetName;
    public string enemyType;
    private void Awake()
    {
        this.name = targetName + "_" + enemyType;

    }
}

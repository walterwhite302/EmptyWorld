using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome : MonoBehaviour
{
    [Header("System Settings")]
    public float tickDuration = 1.0f;
    public List<UnitProfile> natives = new List<UnitProfile>();
    [HideInInspector]
    public List<Transform> nativeHolders = new List<Transform>();
    [Header("Session Settings")]
    public List<int> startingAmount = new List<int>();
    [Header("Session Data")]
    public int numberOfTicksInSession = 0;
    public List<int> counts = new List<int>();
    public List<int> countsCreated = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        SetupSystem();
    }
    void SetupSystem()
    {
        for(int i = 0; i < natives.Count; i++)
        {
            counts.Add(0);
            countsCreated.Add(0);
            nativeHolders.Add(new GameObject(natives[i].name).transform);
            nativeHolders[i].SetParent(transform);
            for(int j=0; j < startingAmount[i]; j++)
            {
                CreateUnit(natives[i],i);
            }
        }
    }
    void CreateUnit(UnitProfile profile, int i)
    {
        Unit newUnit = new GameObject().AddComponent<Unit>();
        newUnit.Initialize(profile, this,i);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

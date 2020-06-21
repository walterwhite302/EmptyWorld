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
    [Header("Physical Properties")]
    public float radius;
    int randomPointLim = 0;

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
            List<Vector3> individuals = new List<Vector3>();
            //int numGroups = startingAmount[i] / natives[i].tolerances[i];
            
            for(int j=0; j < startingAmount[i]; j++)
            {
                individuals.Add(GetRandomPointOnSurface());
                CreateUnit(natives[i],i, individuals[j]);
            }
            individuals.Clear();
        }
    }
    Vector3 GetRandomPointOnSurface()
    {
        RaycastHit hit;
        Vector3 spawn = new Vector3(Random.Range(-radius, radius), 50.0f, Random.Range(-radius, radius));
        
        if(Physics.Raycast(spawn, Vector3.down, out hit, 75.0f))
        {
            if(hit.collider.gameObject.tag == "surface")
            {
                
                spawn = hit.point;
            }

        }
        else
        {
            if(randomPointLim< 50)
            {
                Debug.Log("HERE");
                GetRandomPointOnSurface();
                randomPointLim++;
            }
            
        }
        return spawn;

    }

    void CreateUnit(UnitProfile profile, int i, Vector3 spawnPoint)
    {
        Unit newUnit = new GameObject().AddComponent<Unit>();
        newUnit.Initialize(profile, this,i, spawnPoint);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

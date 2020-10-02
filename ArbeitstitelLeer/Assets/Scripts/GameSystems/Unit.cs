using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitProfile profile;
    public Biome biome;
    public int currentEnergon;
    public string baseName;
    int[] statesOfUnit;
    public GameObject model;
   
    
    
    int CalculateStateValues(int i) {
        if((int)profile.stateDistributionProfile == 0)
        {
            return profile.maxvitality / profile.statesOfLife * (i+1);
        }
        else
        {
            return 0;
        }
    }
    public void Initialize(UnitProfile profile, Biome biome, int k, Vector3 spawnPoint)
    {
        this.profile = profile;
        this.biome = biome;
        //Debug.Log(biome.countsCreated[k]);
        name = profile.name + biome.countsCreated[k];
        transform.SetParent(biome.nativeHolders[k]);
        biome.countsCreated[k]++;
        biome.counts[k]++;
        statesOfUnit = new int[profile.statesOfLife-1];
        for(int i = 0; i < profile.statesOfLife-1; i++)
        {
            statesOfUnit[i] = CalculateStateValues(i);
        }
        //biome.nativeHolders[k] = GetAPlace(k);
        Instantiate(profile.modelObject, spawnPoint, Quaternion.identity) ;
    }/*
    public Transform GetAPlace(int race)
    {
        //Divide all members of race into groups

        //Find start spots for the groups
        
    }*/
}

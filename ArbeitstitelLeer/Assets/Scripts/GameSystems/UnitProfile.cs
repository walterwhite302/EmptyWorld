using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Systemic/UnitProfile")]
public class UnitProfile : ScriptableObject
{
    public UnitType unitType;
    [Header("multiplying")]
    public bool multiplier;
    public int multiplyFrequenzy;
    public int parentsReq;
    public int multiressources;
    public int childsProduced;

    [Header("functioning")]
    public int maxvitality;
    public int statesOfLife;
    public stateDistrubution stateDistributionProfile;
    public float dominantSpaceRadius;
    public List<int> tolerances = new List<int>(); //tolerance of strength tolerance[i] against other being of UnitType i
    public int dominance;
    public UnitMaterial preferedEnergonSource;
    public int minTemper;
    public int maxTemper;
    

    [Header("mobility")]
    public bool mobile;
    public UnitTerritory prefTerritory;
    public float maxvelocity;
    public int speedcost1;
    public int friction;
    public int stickiness;

    [Header("servant")]
    public int deliverEnergon;
    public List<UnitMaterial> unitComponents = new List<UnitMaterial>();
    public int MaxThreatLevel;

    [Header("GFX")]
    public GameObject modelObject;
}
public enum UnitTerritory
{
    aviar,
    water,
    land
}
public enum stateDistrubution
{
    constant
}
public enum UnitType
{
    Plant,
    Animal,
    Effector,
    Machine
}
public enum UnitMaterial
{
    Metal,
    Flesh,
    shell,
    wood,
    process,
    stone
}
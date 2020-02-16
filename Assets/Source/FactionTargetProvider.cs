using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionTargetProvider : MonoBehaviour, ITargetProvider
{
    public string[] TargetFactions;
    public Transform GetTarget()
    {
        Faction faction = FactionList.GetFaction (TargetFactions[Random.Range(0, TargetFactions.Length)]);
        var members = faction.GetMembers();
        if (members.Length > 0)
        {
            return members[Random.Range(0, members.Length)].transform;
        }
        else
        {
            return null;
        }
    }
}

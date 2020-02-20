using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FactionTargetProvider : MonoBehaviour, ITargetProvider
{
    public string[] TargetFactions;
    private Func<Vector3, Vector3, FactionMember, float> _scoreFunc = new Func<Vector3, Vector3, FactionMember, float>((center, direction, member) => Vector3.Dot(direction, (member.transform.position - center).normalized));

    public Transform GetTarget(Vector3 center, Vector3 direction)
    {
        Faction faction = FactionList.GetFaction (TargetFactions[UnityEngine.Random.Range(0, TargetFactions.Length)]);
        var members = faction.GetMembers();
        if (members.Length > 0)
        {
            float highestScore = float.MinValue;
            var highestMember = members.FirstOrDefault();

            foreach (var member in members)
            {
                float score = _scoreFunc(center, direction, member);
                if (score > highestScore)
                {
                    highestScore = score;
                    highestMember = member;
                }
            }

            return highestMember.transform;
        }
        else
        {
            return null;
        }
    }
}

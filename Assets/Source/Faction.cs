using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Faction
{
    public enum ColorSlot { Primary, Secondary, Highlight, Light }

    public string Name;
    public string Description;

    public Material Primary;
    public Material Secondary;
    public Material Highlight;
    public Material Light;

    private List<FactionMember> _members = new List<FactionMember>();

    public void AddMember (FactionMember member)
    {
        _members.Add(member);
    }

    public void RemoveMember (FactionMember member)
    {
        _members.Remove(member);
    }

    public FactionMember[] GetMembers() => _members.ToArray();

    public Material GetMaterial (ColorSlot slot)
    {
        switch (slot)
        {
            case ColorSlot.Primary:
                return Primary;

            case ColorSlot.Secondary:
                return Secondary;

            case ColorSlot.Highlight:
                return Highlight;

            case ColorSlot.Light:
                return Light;

            default:
                return null;
        }
    }
}

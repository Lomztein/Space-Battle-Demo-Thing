using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionMember : MonoBehaviour
{
    public string DefaultFaction;
    private Faction _faction;

    void Start ()
    {
        if (!string.IsNullOrEmpty (DefaultFaction))
        {
            Faction faction = FactionList.GetFaction(DefaultFaction);
            if (faction != null)
            {
                SetFaction(faction);
            }
        }
    }

    public void SetFaction(Faction faction)
    {
        if (_faction != null)
        {
            _faction.RemoveMember(this);
        }
        _faction = faction;
        _faction.AddMember(this);
        UpdateColors();
    }

    public Faction GetFaction() => _faction;

    private void UpdateColors ()
    {
        FactionRendererColorizer[] colorizers = GetComponentsInChildren<FactionRendererColorizer>();
        foreach (FactionRendererColorizer colorizer in colorizers)
        {
            Color(colorizer);
        }
    }

    public void Color (FactionRendererColorizer colorizer)
    {
        colorizer.Color(_faction);
    }

    private void OnDestroy ()
    {
        if (_faction != null)
        {
            _faction.RemoveMember(this);
        }
    }
}

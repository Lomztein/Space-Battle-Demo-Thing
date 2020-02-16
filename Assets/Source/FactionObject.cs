using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionObject : MonoBehaviour
{
    private Faction _faction;

    public void SetFaction (Faction faction)
    {
        _faction = faction;
        Color();
    }

    public Faction GetFaction() => _faction;

    private void Color ()
    {
        FactionRendererColorizer colorizer = GetComponent<FactionRendererColorizer>();
        if (colorizer)
        {
            colorizer.Color(_faction);
        }
    }

}

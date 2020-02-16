using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionRendererColorizer : MonoBehaviour
{
    public Renderer Renderer;
    public Faction.ColorSlot ColorSlot;

    public void Color(Faction faction)
    {
        Renderer.material = faction.GetMaterial(ColorSlot);
    }
}

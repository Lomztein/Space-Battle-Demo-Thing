using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FactionList : MonoBehaviour
{
    public Faction[] Factions;

    public static FactionList Instance;

    public static Faction GetFaction(string name) => Instance.Factions.FirstOrDefault(x => x.Name == name);

    void Awake ()
    {
        Instance = this;
    }
}

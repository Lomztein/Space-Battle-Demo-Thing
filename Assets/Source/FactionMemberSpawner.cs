using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FactionMemberSpawner : MonoBehaviour
{
    public GameObject Prefab;
    public string FactionName;

    public int StartSpawn;
    public float SpawnRadius;

    public float MaxSpawnFreqeuncy;
    public float MinSpawnFreqeuncy;
    public int MemberLimit;

    private void Start ()
    {
        Spawn(StartSpawn);
        Invoke("SpawnSingle", GetSpawnFrequency());
    }

    private void SpawnSingle()
    {
        Spawn(1);
        Invoke("SpawnSingle", GetSpawnFrequency());
    }

    private float GetSpawnFrequency ()
    {
        int memberCount = FactionList.GetFaction(FactionName).GetMembers().Length;
        float t = memberCount / (float)MemberLimit;
        return Mathf.Lerp(MaxSpawnFreqeuncy, MinSpawnFreqeuncy, t);
    }

    public void Spawn (int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(Prefab, GetSpawnPosition(transform.position, SpawnRadius), transform.rotation);
            obj.GetComponent<FactionMember>().SetFaction(FactionList.GetFaction(FactionName));
            obj.GetComponent<FactionTargetProvider>().TargetFactions = FactionList.Instance.Factions.Where(x => x.Name != FactionName).Select(x => x.Name).ToArray();
        }
    }

    private static Vector3 GetSpawnPosition (Vector3 center, float radius)
    {
        Vector3 offset = Random.insideUnitSphere * radius;
        return center + offset;
    }
}

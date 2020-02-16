using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public FactionObject ThisFaction;
    public GameObject HitParticle;

    public Vector3 Direction;
    public float Speed;
    public float Damage;
    public float Range;

    private void Start ()
    {
        Invoke("DestroySelf", Range / Speed);
    }

    private void DestroySelf ()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate ()
    {
        transform.position += Direction * Speed * Time.fixedDeltaTime;

        Ray ray = new Ray(transform.position, Direction * Speed * Time.fixedDeltaTime);
        if (Physics.Raycast (ray, out RaycastHit hit, Speed * Time.fixedDeltaTime))
        {
            if (ThisFaction.GetFaction () != hit.transform.GetComponent<FactionMember>().GetFaction ())
            {
                hit.transform.SendMessage("TakeDamage", Damage);
                if (HitParticle)
                {
                    GameObject particle = Instantiate(HitParticle, hit.point, Quaternion.LookRotation(hit.normal, transform.up));
                }
                Destroy(gameObject);
            }
        }
    }
}

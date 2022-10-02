using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollider : MonoBehaviour
{
    public List<Collider> Colliders = new List<Collider>();

    //private void OnTriggerEnter(Collider other)
    //{
    //    Colliders.Add(other);
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<BaseEnemy>() && !Colliders.Find((x) => x.gameObject == other.gameObject))
        {
            Colliders.Add(other);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    Colliders.Remove(other);
    //}

    private void FixedUpdate()
    {
        Colliders.Clear();
    }
}

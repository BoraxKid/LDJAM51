using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticlesSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitPrefab;

    private List<ParticleSystem> _particles = new List<ParticleSystem>();

    public void Hit(GameObject other)
    {
        _particles.Add(Instantiate(_hitPrefab, other.transform.position, Quaternion.identity, transform));
    }

    private void Update()
    {
        for (int i = 0; i < _particles.Count;)
        {
            if (_particles[i].isStopped)
            {
                _particles[i].gameObject.SetActive(false);
                Destroy(_particles[i].gameObject);
                _particles.RemoveAt(i);
            }
            else
            {
                ++i;
            }
        }
    }
}

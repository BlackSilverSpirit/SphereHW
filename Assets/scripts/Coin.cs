using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    [SerializeField] private ParticleSystem _collisionEffect;


    [SerializeField] private SphereGameRullers _sphereGameRullers;


    private void OnTriggerEnter(Collider other)
    {
        SphereController sphereController = other.GetComponent<SphereController>();

        if (sphereController == null)
        {
            Debug.LogWarning("SphereController отсутствует");
            return;
        }

        if (_collisionEffect == null)
        {
            Debug.LogError("Collision отсутствует");
            return;
        }

        if (sphereController != null)
        {
            ParticleCollisionEffectActive();

            _sphereGameRullers.AddCoins(Random.Range(_minValue, _maxValue + 1));

            gameObject.SetActive(false);
        }
    }

    private void ParticleCollisionEffectActive()
    {
        _collisionEffect.transform.position = transform.position;
        _collisionEffect.Play();
    }


}

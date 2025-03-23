using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _minValue;
    [SerializeField] private int _maxValue;

    [SerializeField] private ParticleSystem _collectEffect;

    private int _value;
    public int Value => _value;

    private void Awake()
    {
        GenerateValue();
    }

    public void Collect()
    {
        PlayCollectEffect();
        gameObject.SetActive(false);
    }

    private void GenerateValue()
    {
        _value = Random.Range(_minValue, _maxValue + 1);
    }

    private void PlayCollectEffect()
    {
        _collectEffect.transform.position = transform.position;
        _collectEffect.Play();
    }
}

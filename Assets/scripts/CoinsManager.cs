using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private GameObject _coinContainer;

    private List<Vector3> _coinsPositionList = new List<Vector3>();

    private void Start()
    {
        SaveCoinsPosition();
    }

    private void SaveCoinsPosition()
    {
        _coinsPositionList.Clear();

        foreach (Transform child in _coinContainer.transform)
        {
            _coinsPositionList.Add(child.position);
        }
    }

    public void RestoreCoinsPosition()
    {
        for (int i = 0; i < _coinsPositionList.Count; i++)
        {
            Transform child = _coinContainer.transform.GetChild(i);
            child.position = _coinsPositionList[i];

            child.gameObject.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFarm : MonoBehaviour
{
    [SerializeField] private int amount;
    private StarCounter _counter;
    void Start()
    {
        _counter = FindObjectOfType<StarCounter>();
    }

    public void AddStarsFromUnit()
    {
        _counter.AddStars(amount);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnDefenders : MonoBehaviour
{
    //reference
    private Defender defender;
    private StarCounter _starCounter;

    private void Start()
    {
        _starCounter = FindObjectOfType<StarCounter>();
    }

    private void OnMouseDown()
    {
        if(!defender) return;
        Vector2 posToSpawn = GetSquareClicked();
        SpawnDefender(posToSpawn);
    }
    
    Vector2 GetSquareClicked()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 gridPos = SnapToGrid(mousePosInWorld);
        return gridPos;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
    
    public void SetCurrentDefender(Defender defenderToSet)
    {
        defender = defenderToSet;
    }
    void SpawnDefender(Vector2 posToSpawn)
    {
        int defenderCost = defender.GetStarCost();
        if (_starCounter.HaveEnoughStars(defenderCost))
        {
            _starCounter.SpendStars(defenderCost);
            Instantiate(defender, posToSpawn, transform.rotation);
        }
        else
        {
            UnityEngine.Debug.Log("Not enough stars to place defender");
        }
        
    }


}

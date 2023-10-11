using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierarchyManager : MonoBehaviour
{
    private enum ParentName
    {
        Defenders,
        Attackers,
        Projectiles,
        Other
    }
    
    [Tooltip("Choose object to be a parent")]
    [SerializeField] ParentName _parentName = new ParentName();
    private string parent;
    
    private GameObject objParent;
    private void Start()
    {
        ChooseParent();
        CreateParent();
    }

    private void ChooseParent()
    {
        switch (_parentName)
        {
            case ParentName.Defenders:
            {
                parent = "Defenders";
                break;
            }
            case ParentName.Attackers:
            {
                parent = "Attackers";
                break;
            }
            case ParentName.Projectiles:
            {
                parent = "Projectiles";
                break;
            }
            case ParentName.Other:
            {
                parent = "Other";
                break;
            }
            default:
            {
                Debug.LogWarning("Chosen wrong parent to instantiate object");
                break;
            }
        }
    }

    private void CreateParent()
    {
        objParent = GameObject.Find(parent);
        if (!objParent)
        {
            objParent = new GameObject(parent);
        }

        this.gameObject.transform.parent = objParent.transform;
    }
}

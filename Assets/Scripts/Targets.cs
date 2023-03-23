using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> TargetsList;
    

    public void TargetHit(GameObject target)
    {
        TargetsList.Remove(target);
        if (TargetsList.Count == 0)
        {
            LevelSelector.Advance();
            Menu.ToMenu();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RayleftAxis : MonoBehaviour
{
    public Vector3 raycastTarget;

    [SerializeField] private TextMeshProUGUI _nameLeftSpriteAxit;

    public void Put()
    {
        Vector3 leftAxis = raycastTarget + transform.position;

        RaycastHit2D hit2D = Physics2D.Raycast(leftAxis, leftAxis - transform.position);

        Debug.Log(hit2D.collider.name);
        _nameLeftSpriteAxit.text = hit2D.collider.name;
    }
}

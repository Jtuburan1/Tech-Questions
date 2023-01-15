using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stats", menuName ="Stats")]
public class StatsSO : ScriptableObject
{
    public Vector3 moveDirection;
    public float moveSpeed;
    public float predTime;
}

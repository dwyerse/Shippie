using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct SpeedComponent : IComponentData
{
    public float speedX;
    public float speedY;
    public float speedZ;
}

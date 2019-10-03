using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class ECSComponent : ComponentSystem
{
    protected override void OnUpdate()
    {

        Entities.ForEach((ref Translation translation, ref SpeedComponent speedComponent, ref Rotation rotation) =>
        {
            translation.Value.x += speedComponent.speedX * Time.deltaTime;
            translation.Value.y += speedComponent.speedY * Time.deltaTime;
            translation.Value.z += speedComponent.speedZ * Time.deltaTime;


            if (translation.Value.z > 201f)
            {
                speedComponent.speedX = speedComponent.speedX * -1;
                speedComponent.speedY = speedComponent.speedY * -1;
                speedComponent.speedZ = speedComponent.speedZ * -1;

                rotation.Value = Quaternion.RotateTowards(rotation.Value, Quaternion.Euler(0, 0, 0), Mathf.Abs(translation.Value.z) / 400);

            }
            else if(translation.Value.z < -200f)
            {
                speedComponent.speedX = Mathf.Abs(speedComponent.speedX * -1);
                speedComponent.speedY = Mathf.Abs(speedComponent.speedY * -1);
                speedComponent.speedZ = Mathf.Abs(speedComponent.speedZ * -1);
                rotation.Value = Quaternion.RotateTowards(rotation.Value, Quaternion.Euler(0, 180, 0), Mathf.Abs(translation.Value.z) / 400);

            }

        });

    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class TestECS : MonoBehaviour
{
    public Mesh mesh;
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        EntityManager entityManager = World.Active.EntityManager;
        EntityArchetype entityArchetype = entityManager.CreateArchetype(typeof(Translation),typeof(RenderMesh),typeof(LocalToWorld), typeof(SpeedComponent),typeof(Rotation));

        NativeArray<Entity> entityArray = new NativeArray<Entity>(10000,Allocator.Temp);
        entityManager.CreateEntity(entityArchetype,entityArray);

        for(int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];
            entityManager.SetComponentData(entity,new SpeedComponent { speedX = UnityEngine.Random.Range(10f,20f), speedY = UnityEngine.Random.Range(10f, 20f) , speedZ = UnityEngine.Random.Range(10f, 20f) });
            entityManager.SetComponentData(entity, new Translation { Value = new float3(UnityEngine.Random.Range(-200f, 200f), UnityEngine.Random.Range(-200f, 200f), UnityEngine.Random.Range(-200f, 200f)) });
            entityManager.SetComponentData(entity, new Rotation { Value = UnityEngine.Random.rotation });

            entityManager.SetSharedComponentData(entity, new RenderMesh { mesh = mesh, material = material });
        }
        entityArray.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

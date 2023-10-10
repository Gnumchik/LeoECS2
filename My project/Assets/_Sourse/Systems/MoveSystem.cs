using Leopotam.EcsLite;
using System.Data;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using static UnityEditor.Progress;

namespace Client {
    sealed class MoveSystem : IEcsInitSystem , IEcsRunSystem
        {
        private EcsFilter _filter;
        private EcsPool<MovmentEcsComponent> _entetiPool;
        private int naprovlenia = 1;
        
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<MovmentEcsComponent>().End();
            _entetiPool = world.GetPool<MovmentEcsComponent>();
            foreach (var item in _filter)
            {
                ref MovmentEcsComponent moveEcsComponent = ref _entetiPool.Get(item);
                ref var transform = ref moveEcsComponent.transform;
                ref var startZ = ref moveEcsComponent.startZ;
                startZ = transform.position.z;
            }
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var item in _filter)
            {
                ref MovmentEcsComponent testMove = ref _entetiPool.Get(item);
                ref var transforms = ref testMove.transform;
                ref var speed = ref testMove.Speed;
                ref var amplitude = ref testMove.Amlitude;
                ref var startZ = ref testMove.startZ;

                transforms.position += new Vector3(speed * Time.deltaTime, 0, speed * naprovlenia * Time.deltaTime);
                
                if(startZ + amplitude <= transforms.position.z && naprovlenia > 0)
                {
                    naprovlenia *= -1;
                    startZ = transforms.position.z;
                }
                else if (startZ - amplitude >= transforms.position.z && naprovlenia < 0)
                {
                    naprovlenia *= -1;
                    startZ = transforms.position.z;
                }

            }
        }

    }
}
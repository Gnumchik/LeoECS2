using Leopotam.EcsLite;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;

namespace Client {
    sealed class CounterSystem : IEcsInitSystem, IEcsRunSystem {

        private EcsFilter _filter;
        private EcsPool<EcsComponent> _entetiPool;
        public void Init (IEcsSystems systems) 
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<EcsComponent>().End();
            _entetiPool = world.GetPool<EcsComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var item in _filter)
            {
                ref EcsComponent testCounter = ref _entetiPool.Get(item);
                ref var counter = ref testCounter.Conunter;
                counter++;
                Debug.Log(counter);
            }
        }
    }
}
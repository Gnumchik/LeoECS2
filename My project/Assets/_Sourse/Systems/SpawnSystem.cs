using Leopotam.EcsLite;
using Palmmedia.ReportGenerator.Core.Parser.Filtering;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Client {
    sealed class SpawnSystem : IEcsInitSystem {

        private EcsFilter _filter;
        private EcsPool<EcsSpawner> _entetiPool;
        public void Init (IEcsSystems systems) {

            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<EcsSpawner>().End();
            _entetiPool = world.GetPool<EcsSpawner>();


            foreach (var item in _filter)
            {
                ref EcsSpawner moveEcsComponent = ref _entetiPool.Get(item);
                ref var prefab = ref moveEcsComponent.Object;
                ref var amount = ref moveEcsComponent.AmountObject;

                for(int i =0; i < amount; i++)
                {
                    GameObject.Instantiate(prefab).transform.position = new Vector3(Random.Range(-100, 101), Random.Range(-100, 101), Random.Range(-100, 101));
                }

            }

        }


    }
}
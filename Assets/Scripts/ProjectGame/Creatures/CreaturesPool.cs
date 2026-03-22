using Sisus.Init;
using UnityEngine;
using UnityEngine.Pool;

namespace ProjectGame
{
    [Service(AddressableKey = "CreaturesPool", FindFromScene = true)]
    public class CreaturesPool: MonoBehaviour
    {
        // The pool holds plain GameObjects (you can swap this for any component type).
        public ObjectPool<Creature> Pool;

        [SerializeField] private Creature _creature;

        private void Awake()
        {
            // Create a pool with the four core callbacks.
            Pool = new ObjectPool<Creature>(
                createFunc: CreateItem,
                actionOnGet: OnGet,
                actionOnRelease: OnRelease,
                actionOnDestroy: OnDestroyItem,
                collectionCheck: true,   // helps catch double-release mistakes
                defaultCapacity: 4,
                maxSize: 8
            );
        }

        // Creates a new pooled GameObject the first time (and whenever the pool needs more).
        private Creature CreateItem()
        {
            var creature = Instantiate(_creature);
            creature.name = "Creature";
            creature.gameObject.SetActive(false);
            return creature;
        }

        // Called when an item is taken from the pool.
        private void OnGet(Creature creature)
        {
            creature.gameObject.SetActive(true);
        }

        // Called when an item is returned to the pool.
        private void OnRelease(Creature creature)
        {
            creature.gameObject.SetActive(false);
        }

        // Called when the pool decides to destroy an item (e.g., above max size).
        private void OnDestroyItem(Creature creature)
        {
            Destroy(creature.gameObject);
        }
    }
}
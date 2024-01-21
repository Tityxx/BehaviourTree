using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tityx.BehaviourTree
{
    public class ExampleEntityGuard : BehaviourTree
    {
        [SerializeField] private float _findRadius = 5f;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private List<Transform> _waypoints;

        protected override Node SetupTree()
        {
            Node root = new Selector(new List<Node>
            {
                new SequenceWithRunning(new List<Node>
                {
                    new ExampleFindEnemyAtFOVRange(transform, _findRadius),
                    new ExampleTaskGoToTarget(transform, _speed),
                    new ExampleTaskDealDamage()
                }),
                new ExampleTaskPatrol(transform, _waypoints, _speed)
            });
            return root;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _findRadius);


            Gizmos.color = Color.red;
            
            foreach (var p in _waypoints)
            {
                Gizmos.DrawSphere(p.position, 0.2f);
            }
        }
    }
}
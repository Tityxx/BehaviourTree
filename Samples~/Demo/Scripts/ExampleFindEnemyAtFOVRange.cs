using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tityx.BehaviourTree
{
    public class ExampleFindEnemyAtFOVRange : Node
    {
        private Transform _self;
        private float _radius;

        private const string TARGET = "Target";

        public ExampleFindEnemyAtFOVRange(Transform self, float radius)
        {
            _self = self;
            _radius = radius;
        }

        public override NodeState Evaluate()
        {
            object target = GetData(TARGET);

            if (target == null)
            {
                var colliders = Physics.OverlapSphere(_self.position, _radius);
                if (colliders.Length > 0)
                {
                    Parent.Parent.SetData(TARGET, colliders[0].transform);
                }
                else
                {
                    _state = NodeState.Failure;
                    return _state;
                }
            }

            _state = NodeState.Success;
            return _state;
        }
    }
}
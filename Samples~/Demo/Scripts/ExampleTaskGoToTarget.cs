using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tityx.BehaviourTree
{
    public class ExampleTaskGoToTarget : Node
    {
        private Transform _self;
        private float _speed;

        private const string TARGET = "Target";
        private const float STOP_DISTANCE = 1.25f;

        public ExampleTaskGoToTarget(Transform self, float speed)
        {
            _self = self;
            _speed = speed;
        }

        public override NodeState Evaluate()
        {
            Transform target = (Transform)GetData(TARGET);

            if ((_self.position - target.position).magnitude > STOP_DISTANCE * STOP_DISTANCE)
            {
                _self.position += _self.forward * _speed * Time.deltaTime;
                _self.LookAt(target);
            }

            _state = NodeState.Running;
            return _state;
        }
    }
}
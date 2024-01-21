using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tityx.BehaviourTree
{
    public class ExampleTaskDealDamage : Node
    {
        private float _time;

        private const string TARGET = "Target";
        private const float ANIMATION_DURATION = 2f;

        public override NodeState Evaluate()
        {
            _state = NodeState.Failure;

            Transform target = (Transform)GetData(TARGET);

            if (target != null)
            {
                if (_time >= ANIMATION_DURATION)
                {
                    _time = 0;
                    target.gameObject.SetActive(false);
                    ClearData(TARGET);
                    _state = NodeState.Success;
                }
                else
                {
                    _time += Time.deltaTime;
                    _state = NodeState.Running;
                }

                _state = NodeState.Running;
                return _state;
            }

            return _state;
        }
    }
}
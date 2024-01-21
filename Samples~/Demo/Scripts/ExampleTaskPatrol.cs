using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tityx.BehaviourTree
{
    public class ExampleTaskPatrol : Node
    {
        private Transform _transform;
        private List<Transform> _waypoints;

        private float _speed;
        private float _waitTime;
        private int _index;
        private bool _isWaiting;

        private const float WAIT_DURATION = 1f;
        private const float CHECK_RADIUS = 0.1f;

        public ExampleTaskPatrol(Transform transform, List<Transform> waypoints, float speed)
        {
            _transform = transform;
            _waypoints = waypoints;
            _speed = speed;
        }

        public override NodeState Evaluate()
        {
            if (_isWaiting)
            {
                _waitTime += Time.deltaTime;

                if (_waitTime >= WAIT_DURATION)
                {
                    _isWaiting = false;
                }
            }
            else
            {
                if ((_transform.position - _waypoints[_index].position).magnitude <= CHECK_RADIUS * CHECK_RADIUS)
                {
                    _waitTime = 0;
                    _isWaiting = true;
                    _index = (_index + 1) % _waypoints.Count;
                }
                else
                {
                    _transform.position += _transform.forward * _speed * Time.deltaTime;
                    _transform.LookAt(_waypoints[_index]);
                }
            }

            _state = NodeState.Running;
            return _state;
        }
    }
}
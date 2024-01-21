using UnityEngine;

namespace Tityx.BehaviourTree
{
    public abstract class BehaviourTree : MonoBehaviour
    {
        protected Node _root = null;

        protected virtual void Start()
        {
            _root = SetupTree();
        }

        protected virtual void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }

        protected abstract Node SetupTree();
    }
}
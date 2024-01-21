using System.Collections.Generic;

namespace Tityx.BehaviourTree
{
    public class And : Node
    {
        public And(List<Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            foreach (Node node in _children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.Failure:
                        _state = NodeState.Failure;
                        return _state;
                    case NodeState.Success:
                        _state = NodeState.Success;
                        continue;
                    case NodeState.Running:
                        _state = NodeState.Failure;
                        return _state;
                    default:
                        continue;
                }
            }

            _state = NodeState.Success;
            return _state;
        }
    }
}
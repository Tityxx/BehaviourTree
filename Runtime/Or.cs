using System.Collections.Generic;

namespace Tityx.BehaviourTree
{
    public class Or : Node
    {
        public Or(List<Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            foreach (Node node in _children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.Failure:
                        _state = NodeState.Failure;
                        continue;
                    case NodeState.Success:
                        _state = NodeState.Success;
                        return _state;
                    case NodeState.Running:
                        _state = NodeState.Running;
                        continue;
                    default:
                        continue;
                }
            }

            _state = NodeState.Failure;
            return _state;
        }
    }
}
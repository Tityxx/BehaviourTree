using System.Collections.Generic;

namespace Tityx.BehaviourTree
{
    public class Sequence : Node
    {
        public Sequence() : base() { }
        public Sequence(List<Node> children) : base(children) { }

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
                        continue;
                    case NodeState.Running:
                        _state = NodeState.Running;
                        return _state;
                    default:
                        _state = NodeState.Success;
                        return _state;
                }
            }

            return _state;
        }
    }
}
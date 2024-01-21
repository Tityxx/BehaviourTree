using System.Collections;
using System.Collections.Generic;

namespace Tityx.BehaviourTree
{
    public enum NodeState
    {
        Running,
        Success,
        Failure
    }

    public abstract class Node
    {
        public Node Parent;

        protected NodeState _state;
        protected List<Node> _children = new List<Node>();

        private Dictionary<string, object> _data = new Dictionary<string, object>();

        public Node()
        {
            Parent = null;
        }

        public Node(List<Node> children)
        {
            foreach (Node child in children)
            {
                child.Parent = this;
                _children.Add(child);
            }
        }

        public abstract NodeState Evaluate();

        public void SetData(string key, object value)
        {
            if (Parent != null) Parent.SetData(key, value);
            else _data[key] = value;
        }

        public object GetData(string key)
        {
            object val = null;

            if (_data.TryGetValue(key, out val))
                return val;

            if (Parent != null)
                val = Parent.GetData(key);

            return val;
        }

        public bool ClearData(string key)
        {
            bool cleared = false;

            if (_data.ContainsKey(key))
            {
                _data.Remove(key);
                return true;
            }

            if (Parent != null)
                cleared = Parent.ClearData(key);

            return cleared;
        }
    }
}
using System.Collections.Generic;

namespace MinimaxCS
{
#nullable enable
    public class MinimaxNode<TData>
    {
        public MinimaxNode(TData data, MinimaxNode<TData>? parent)
        {
            Data = data;
            Parent = parent;
            Nodes = new List<MinimaxNode<TData>>();
        }

        public TData Data { get; }
        public MinimaxNode<TData>? Parent { get; }
        public List<MinimaxNode<TData>> Nodes { get; }
    }
#nullable disable
}
using System;
using System.Linq;

namespace MinimaxCS
{
    public class MinimaxTree<TGame, TData> where TGame : IGame<TData>
    {
        public MinimaxTree(TGame game, TData data, int maxDepth, bool bMaximizing)
        {
            Game = game;
            MaxDepth = maxDepth;
            _bMaximizing = bMaximizing;
            Root = new MinimaxNode<TData>(data, null);
        }

        public TGame Game { get; }
        public MinimaxNode<TData> Root { get; }
        public int MaxDepth { get; }
        private readonly bool _bMaximizing;

        public TData Run()
        {
            InnerMinimax(Root, 0, _bMaximizing);

            return _bMaximizing ? Root.Nodes.Max().Data : Root.Nodes.Min().Data;
        }

        private void InnerMinimax(MinimaxNode<TData> node, int depth, bool bMaximizing)
        {
            if (depth == 0 || depth >= MaxDepth)
            {
                var res = Game.Evaluate(node.Data);
                node.Value = res;
                return;
            }

            foreach (var child in Game.GetPossibleMoves(node.Data).Select(move => new MinimaxNode<TData>(move, node)))
            {
                node.Nodes.Add(child);
                InnerMinimax(child, depth + 1, !bMaximizing);
            }

            node.Value = bMaximizing ? node.Nodes.Max(x => x.Value) : node.Nodes.Min(x => x.Value);
        }
    }
}
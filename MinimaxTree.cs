using System;

namespace MinimaxCS
{
    public class MinimaxTree<TGame, TData> where TGame : IGame<TData>
    {
        public MinimaxTree(TGame game, TData data, int maxDepth)
        {
            Game = game;
            MaxDepth = maxDepth;
            Root = new MinimaxNode<TData>(data, null);
        }

        public TGame Game { get; }
        public MinimaxNode<TData> Root { get; }
        public int MaxDepth { get; }

        public TData Run()
        {
            throw new NotImplementedException();
        }
    }
}
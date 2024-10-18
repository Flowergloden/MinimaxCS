namespace MinimaxCS
{
    public interface IGame<in TData>
    {
        public float Evaluate(TData data);
    }
}
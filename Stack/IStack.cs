namespace Stack
{
    public interface IStack<T>
    {
        int StackSize { get; }

        T Pop();
        void Push(T value);
    }
}
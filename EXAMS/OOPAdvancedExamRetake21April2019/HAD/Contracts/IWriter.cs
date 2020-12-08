namespace HAD.Contracts
{
    public interface IWriter
    {
        void WriteLine(string text);

        void Flush();
    }
}
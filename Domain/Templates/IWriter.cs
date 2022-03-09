namespace VideoVault.Domain.Templates
{
    public interface IWriter
    {
        public void Write(int row, int column, string value);
    }
}
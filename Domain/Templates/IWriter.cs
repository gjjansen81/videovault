namespace VideoVault.Domain.Templates
{
    public interface IWriter
    {
        public void WriteCell(int row, int column, string value);
    }
}
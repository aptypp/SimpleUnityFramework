namespace Tools.FileSaves
{
    public abstract class BaseSaves
    {
        protected readonly SaveFile _saveFile;

        protected BaseSaves() => _saveFile = new SaveFile(_fileName);
        protected abstract string _fileName { get; }
    }
}
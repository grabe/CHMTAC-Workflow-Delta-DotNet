namespace CHMR_DMP_PPR_Charlie_Docker.Helpers
{
    public abstract class Enum<T> where T :System.Enum
    {
        public T? Value { get; set; }
    }
}

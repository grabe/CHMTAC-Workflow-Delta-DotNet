namespace CHMR_DMP_PPR_Charlie_Docker.Database.SupportingNS
{
    public class Document
    {
        public Guid Uuid { get; set; } = Guid.NewGuid();
        public string Filename { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[] Filedata { get; set; } = Array.Empty<byte>();
        public ulong Filesize { get; set; } = 0L;

        public Document(string filename, string description, ref byte[] filedata)
        {
            if (filedata != null && filedata.Length > 0)
            {
                Filedata = new byte[filedata.Length];
                filedata.CopyTo(Filedata, 0);
            }
        }
    }
}

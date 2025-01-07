namespace PackWeaver.Models {
    public class PackData {
        public string description {get; set;}
        public int pack_format {get; set;}
    }

    public class PackMeta {
        public PackData pack {get; set;}
    }
}
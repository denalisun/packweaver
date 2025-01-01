namespace PackWeaver.Models {
    public class DatapackData {
        public string entrypoint {get; set;} = "src/main.lua";
    }

    public class Config {
        public string name {get; set;} = "";
        public string description {get; set;} = "";
        public int version {get; set;} = 61;
        public DatapackData datapack {get; set;}
    }
}
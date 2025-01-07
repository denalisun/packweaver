namespace PackWeaver.Models {
    public class FunctionTag {
        public string[] values {get; set;} = [];

        public FunctionTag(string[] values) {
            this.values = values;
        }
    }
}
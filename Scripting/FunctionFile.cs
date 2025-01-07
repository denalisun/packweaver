namespace PackWeaver.Scripting {
    public struct FunctionFile {
        public FunctionFile(string name) {
            this.Lines = new List<string>();
            this.Name = name;
            this.Id = Guid.NewGuid();
            this.isTick = false;
        }

        public List<string> Lines;
        public string Name;
        public Guid Id;
        public bool isTick;
    }
}
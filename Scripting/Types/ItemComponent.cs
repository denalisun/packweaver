namespace PackWeaver.Scripting.Types {
    public struct ItemComponent {
        public string Id;
        public string Value;

        public ItemComponent(string Id, string Value) {
            this.Id = Id;
            this.Value = Value;
        }
    }
}
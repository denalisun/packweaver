using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Types {
    public struct ItemComponent {
        public string Id;
        public object Value;

        public ItemComponent(string Id, object Value) {
            this.Id = Id;
            this.Value = Value;
        }
    }
}
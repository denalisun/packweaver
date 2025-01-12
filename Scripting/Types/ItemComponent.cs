using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Types {
    public struct ItemComponent {
        public string Id;
        public DynValue Value;

        public ItemComponent(string Id, DynValue Value) {
            this.Id = Id;
            this.Value = Value;
        }
    }
}
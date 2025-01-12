using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Types {
    public class ItemStack {
        public string Id;
        public int Count;
        public List<ItemComponent> itemComponents;

        public ItemStack(string Id, int Count) {
            this.Id = Id;
            this.Count = Count;
            this.itemComponents = new List<ItemComponent>();
        }

        public void AddComponent(string id, DynValue value) {
            ItemComponent component = new ItemComponent(id, value);
            this.itemComponents.Add(component);
        }

        public void RemoveComponent(string id) {
            foreach (var component in this.itemComponents) {
                if (component.Id == id)
                    this.itemComponents.Remove(component);
            }
        }
    }
}
using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Types {
    public struct Location {
        public double X;
        public double Y;
        public double Z;
        public bool IsRelative;
        
        public Location(double X, double Y, double Z, bool IsRelative = false) {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.IsRelative = IsRelative;
        }

        public override string ToString() {
            return IsRelative ? $"~{X} ~{Y} ~{Z}" : $"{X} {Y} {Z}";
        }
    }
}
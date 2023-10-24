using System;

namespace Vectors
{
    public class Vector2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2D()
        {
        }
        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    public class Vector : IVector
    {
       public double X { get; set; }
       public double Y { get; set; }
       public double Z { get; set; }

        public Vector()
        {
        }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            Vector vector = new Vector();
            vector.X = vector1.X + vector2.X;
            vector.Y = vector1.Y + vector2.Y;
            vector.Z = vector1.Z + vector2.Z;
            return vector;
        }
        public static Vector operator -(Vector vector1, Vector vector2)
        {
            Vector vector = new Vector();
            vector.X = vector1.X - vector2.X;
            vector.Y = vector1.Y - vector2.Y;
            vector.Z = vector1.Z - vector2.Z;
            return vector;
        }
        public static Vector operator *(Vector vector1, double value)
        {
            Vector vector = new Vector();
            vector.X = vector1.X * value;
            vector.Y = vector1.Y * value;
            vector.Z = vector1.Z * value;
            return vector;
        }
        public static double operator *(Vector vector1, Vector vector2)
        {
            Vector vector = new Vector();
            vector.X = vector1.X * vector2.X;
            vector.Y = vector1.Y * vector2.Y;
            vector.Z = vector1.Z * vector2.Z;
            double scal = vector.X + vector.Y + vector.Z;
            return scal;
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Vector vec = obj as Vector;
            return X.Equals(vec.X) && Y.Equals(vec.Y) && Z.Equals(vec.Z);
        }

        public override int GetHashCode()
        {
            int hashCode = -307843816;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            return hashCode;
        }

        public static bool operator true(Vector vector)
        {
            return vector != null; 
        }
        public static bool operator false(Vector vector)
        {
            return vector == null;
        }
      
        public static explicit operator double(Vector vector)
        {
            return vector.Length();
        }
        public static implicit operator Vector2D(Vector vector)
        {
            return new Vector2D(vector.X, vector.Y);
        }

        public static bool operator ==(Vector vector1, Vector vector2)
        {
            return Equals(vector1, vector2);
        }
        public static bool operator !=(Vector vector1, Vector vector2)
        {
            return !Equals(vector1, vector2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Vector
    {
        private int[] _vector;
        public int Size { get; set; }
        public Vector()
        {
            this._vector = new int[3];
            this.Size = 3;
        }
        public int this[int index]
        {
            get
            {
                return _vector[index];
            }
            set
            {
                _vector[index] = value;
            }
        }
        public static void Initializator(Vector vector)
        {
            for(int i = 0; i < vector._vector.Length; i++)
            {
                Console.Write($"Enter element for index {i}: ");
                vector._vector[i] = int.Parse(Console.ReadLine());
            }
        }
        public override string ToString()
        {
            string result = string.Empty;
            for(int i = 0; i < _vector.Length; i++)
            {
                result = result + _vector[i] + ",";
            }
            return result;
        }
    }
}

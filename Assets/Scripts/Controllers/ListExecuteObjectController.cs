using System.Collections;
using System;
using UnityEngine;

namespace ShooterBot
{
    public class ListExecuteObjectController : IEnumerator
    {
        private int _index = -1;

        private IExecute[] _interactivObjects;

        public int Lenght => _interactivObjects.Length;

        public object Current => _interactivObjects[_index];

        public IExecute this[int curr]
        {
            get => _interactivObjects[curr];
            private set => _interactivObjects[curr] = value;
        }

        public void Add(IExecute execute)
        {
            if(_interactivObjects == null)
            {
                _interactivObjects = new[] { execute };
                return;
            }

            Array.Resize(ref _interactivObjects, Lenght + 1);
            _interactivObjects[Lenght - 1] = execute;
        }

        public bool MoveNext()
        {
            if(_index == Lenght - 1) return false;

            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}
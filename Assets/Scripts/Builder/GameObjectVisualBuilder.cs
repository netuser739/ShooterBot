using ShooterBot;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Builder
{
    internal sealed class GameObjectVisualBuilder : GameObjectBuilder
    {
        public GameObjectVisualBuilder(GameObject gameObject) : base(gameObject) { }

        public GameObjectVisualBuilder Name(string name)
        {
            _gameObject.name = name;
            return this;
        }

        public GameObjectVisualBuilder Mesh(Mesh mesh)
        {
            var component = GetOrAddComponent<MeshFilter>();
            component.mesh = mesh;
            return this;

        }

        public GameObjectVisualBuilder Material(Material material)
        {
            var component = GetOrAddComponent<MeshRenderer>();
            component.material = material;
            return this;
        }

        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _gameObject.GetComponent<T>();
            if(!result)
            {
                result = _gameObject.AddComponent<T>();
            }
            return result;
        }
    }
}
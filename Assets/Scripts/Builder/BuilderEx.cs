using ShooterBot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Builder
{
    public class BuilderEx : MonoBehaviour
    {
        [SerializeField] private Mesh mesh;
        [SerializeField] private Material material;

        void Start()
        {
            var gameObjectBuilder = new GameObjectBuilder();

            GameObject bullet = gameObjectBuilder.Visual
                .Name("Bullet")
                .Material(material)
                .Mesh(mesh);
        }
    }
}
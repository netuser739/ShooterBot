using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Builder
{
    internal class GameObjectBuilder
    {
        protected GameObject _gameObject;

        public GameObjectBuilder() => _gameObject = new GameObject();
        protected GameObjectBuilder(GameObject gameObject) => _gameObject = gameObject;

        public GameObjectVisualBuilder Visual => new GameObjectVisualBuilder(_gameObject);

        //public GameObjectPhisicsBuilder Phisics => new GameObjectPhisicsBuilder(gameObject);

        public static implicit operator GameObject(GameObjectBuilder builder)
        {
            return builder._gameObject;
        }

    }
}
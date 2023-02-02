using System;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator
{
    public class ServiceLocator<T> : IServiceLocator<T>
    {
        protected Dictionary<Type, T> _items { get; }

        public ServiceLocator() 
        {
            _items = new Dictionary<Type, T>();
        }

        public TP GetService<TP>() where TP : T
        {
            var type = typeof(TP);
            if (!_items.ContainsKey(type))
            {
                throw new Exception($"There is no object of type {type}");
            }

            return (TP)_items[type];
        }

        public TP Register<TP>(TP newService) where TP : T
        {
            var type = newService.GetType();

            if (_items.ContainsKey(type))
            {
                throw new Exception($"Cannot add item of type {type}. This type allready exist");
            }
            
            _items[type] = newService;
            return newService;
        }

        public void Remove<TP>(TP service) where TP : T
        {
            var type = service.GetType();

            if (_items.ContainsKey(type))
            {
                _items.Remove(type);    
            }
        }
    }
}
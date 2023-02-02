using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator
{
    public abstract class ServiceBase : IService
    {
        public int Version { get; }

        public ServiceBase(int version)
        {
            Version = version;
        }
    }
}
using System.Text.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using Newtonsoft.Json;

namespace ShooterBot.Factory
{
    public struct Unit
    {
        public string type;
        public int health;
    }

    public class MainFactory : MonoBehaviour
    {
        private IFactoryBase magFactory;
        private IFactoryBase infantryFactory;

        private Unit[] units;

        private void Awake()
        {
            magFactory = new MagFactory();
            infantryFactory = new InfantryFactory();

            using(FileStream fs = new FileStream("units.json", FileMode.OpenOrCreate))
            {
                //Unit? unit = JsonSerializer.Deserialize<Unit>(fs);
            }
        }

        private void Update()
        {
            
        }


    }
}
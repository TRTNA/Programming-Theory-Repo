using UnityEngine;


namespace Assets.Scripts
{
    public class AICommands : ICommands
    {
        private readonly Animal animal;

        public AICommands(Animal animal)
        {
            this.animal = animal;
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
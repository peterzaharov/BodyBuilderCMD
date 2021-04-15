using System.Collections.Generic;

namespace BodyBuilder.BL.Controller
{
    public abstract class ControllerBase
    {
        private readonly IDataSaver manager = new SerializeDataSaver();
        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}

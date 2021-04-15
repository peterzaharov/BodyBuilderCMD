using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyBuilder.BL.Controller
{
    public interface IDataSaver
    {
        List<T> Load<T>() where T : class;
        void Save<T>(List<T> item) where T : class;
    }
}

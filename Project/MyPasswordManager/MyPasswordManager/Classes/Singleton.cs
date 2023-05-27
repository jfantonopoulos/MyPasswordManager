using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPasswordManager.Classes
{
    public sealed class Singleton<T> where T : class, new()
    {
        private static Dictionary<Type, object> instances = new Dictionary<Type, object>();
        private static readonly object padlock = new object();
        
        public static T GetInstance(params object[] args)
        {
            lock (padlock)
            {
                if (!instances.ContainsKey(typeof(T)) || instances[typeof(T)] == null)
                    instances[typeof(T)] = Activator.CreateInstance(typeof(T), args);
            }
            return instances[typeof(T)] as T;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ReflectionHelper
{
    public static class ReflectionHelper
    {
        public static List<T> GetAllNonabstractClassesOf<T>()
        {
            Object[] args = new Object[0];
            return GetAllNonabstractClassesOf<T>(args);
        }

        public static List<T> GetAllNonabstractClassesOf<T>(Object[] args)
        {
            List<T> retVal = new List<T>();
            LoadAllAssemblies();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                List<T> itemsToAdd = GetAllNonabstractClassesOfInAssembly<T>(args, assembly);
                retVal.AddRange(itemsToAdd);
            }
            return retVal;
        }

        public static List<T> GetAllNonabstractClassesOfInContainingAssembly<T>()
        {
            Object[] args = new Object[0];
            return GetAllNonabstractClassesOfInContainingAssembly<T>(args);
        }

        public static List<T> GetAllNonabstractClassesOfInContainingAssembly<T>(Object[] args)
        {
            Assembly containing = typeof(T).Assembly;
            return GetAllNonabstractClassesOfInAssembly<T>(args, Assembly.GetExecutingAssembly());
        }

        public static List<T> GetAllNonabstractClassesOfInAssembly<T>(Object[] args, Assembly assembly)
        {
            List<T> retVal = new List<T>();
            IEnumerable<object> instances = from t in assembly.GetTypes()
                                            where t.IsSubclassOf(typeof(T)) && !t.IsAbstract
                                            select Activator.CreateInstance(t, args) as object;
            foreach (T instance in instances)
            {
                retVal.Add(instance);
            }
            return retVal;

        }

        public static List<T> GetAllNonabstractClassesThatImplement<T>()
        {
            Object[] args = new Object[0];
            return GetAllNonabstractClassesThatImplement<T>(args);
        }

        public static List<T> GetAllNonabstractClassesThatImplement<T>(Object[] args)
        {
            List<T> retVal = new List<T>();

            LoadAllAssemblies();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                List<T> itemsToAdd = GetAllNonabstractClassesThatImplementInAssembly<T>(args, assembly);
            }
            return retVal;
        }

        public static List<T> GetAllNonabstractClassesThatImplementInAssembly<T>(Object[] args, Assembly assembly)
        {
            List<T> retVal = new List<T>();
            IEnumerable<object> instances = from t in assembly.GetTypes()
                                            where t.GetInterfaces().Contains(typeof(T)) && !t.IsAbstract
                                            select Activator.CreateInstance(t, args) as object;
            foreach (T instance in instances)
            {
                retVal.Add(instance);
            }
            return retVal;

        }
        
        public class MemInfo
        {
            public object value;
            public string name;
            public MemInfo(string name, object value)
            {
                this.name = name;
                this.value = value;
            }
        }

        public static List<MemInfo> GetAllPublicStaticFieldsOf(Type ContainingStaticClass, Type FieldTypeToLookFor)
        {
            List<MemInfo> retVal = new List<MemInfo>();

            object fieldVal;
            FieldInfo[] fields = ContainingStaticClass.GetFields(BindingFlags.Static | BindingFlags.Public);

            foreach (FieldInfo fi in fields)
            {
                fieldVal = fi.GetValue(null);
                if (fieldVal.GetType() == FieldTypeToLookFor)
                {
                    retVal.Add(new MemInfo(fi.Name, fieldVal));
                }
            }

            return retVal;
        }

        public static List<object> GetAllPublicStaticFieldValuesOf(Type ContainingStaticClass, Type FieldTypeToLookFor)
        {
            List<object> retVal = new List<object>();
            List<MemInfo> mems = GetAllPublicStaticFieldsOf(ContainingStaticClass, FieldTypeToLookFor);
            foreach (MemInfo mem in mems)
            {
                retVal.Add(mem.value);
            }
            return retVal;
        }


        private static void LoadAllAssemblies()
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic).ToList();
            var loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();

            var referencedPaths = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();
            foreach (string path in toLoad)
            {
                loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path)));
            }
        }
        
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FxConnectProxy.Tests.Data
{
    [TestClass]
    public abstract class BaseRowTests<T>
        where T : BaseRow, new()
    {
        private Random Rnd { get; set; }

        public BaseRowTests()
        {
            this.Rnd = new Random();
        }

        protected abstract RowType ExpectedRowType { get; }

        [TestMethod]
        public void ValidRowType()
        {
            var o = new T();
            Assert.AreEqual(this.ExpectedRowType, o.RowType);
        }

        [TestMethod]
        public void Clone()
        {
            var t = typeof(T);
            var m = t.GetMethod("Clone", BindingFlags.Instance | BindingFlags.Public);

            if (m == null)
            {
                throw new AssertFailedException("Object doesn't support cloning.");
            }

            var source = this.GetObjectForCloning();
            var clone = (T)m.Invoke(source, null);

            this.CompareObjects(source, clone);
        }

        protected T GetObjectForCloning()
        {
            var o = new T();

            var t = typeof(T);

            foreach (var p in t.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanRead && x.CanWrite))
            {
                if (p.PropertyType.Equals(typeof(string)))
                {
                    p.SetValue(o, p.Name);
                }
                else if (p.PropertyType.Equals(typeof(bool)))
                {
                    p.SetValue(o, this.Rnd.Next(2) == 1 ? true : false);
                }
                else if (p.PropertyType.Equals(typeof(int)))
                {
                    p.SetValue(o, this.GetRandomInt());
                }
                else if (p.PropertyType.Equals(typeof(uint)))
                {
                    p.SetValue(o, (uint)Math.Abs(this.GetRandomInt()));
                }
                else if (p.PropertyType.Equals(typeof(double)))
                {
                    p.SetValue(o, this.GetRandomInt());
                }
                else if (p.PropertyType.Equals(typeof(byte)))
                {
                    p.SetValue(o, (byte)this.GetRandomInt());
                }
                else if (p.PropertyType.Equals(typeof(DateTime)))
                {
                    p.SetValue(o, DateTime.Now.AddSeconds(this.GetRandomInt()));
                }
                else if (p.PropertyType.IsEnum)
                {
                    p.SetValue(o, this.GetRandomEnum(p.PropertyType));
                }
                else
                {
                    throw new InvalidOperationException("Unsupported type.");
                }
            }

            return o;
        }

        protected void CompareObjects(T source, T clone)
        {
            if (source == clone)
            {
                throw new AssertFailedException("Both source and clone are the same object.");
            }

            if (source == null)
            {
                throw new AssertFailedException("Source is null.");
            }

            if (clone == null)
            {
                throw new AssertFailedException("Clone is null.");
            }

            var t = typeof(T);

            foreach (var p in t.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanRead && x.CanWrite))
            {
                Assert.AreEqual(p.GetValue(source), p.GetValue(clone));
            }
        }

        private object GetRandomEnum(Type enumType)
        {
            var def = Activator.CreateInstance(enumType);

            var options = Enum.GetValues(enumType).Cast<object>().Where(x => x != def).OrderBy(x => Guid.NewGuid()).ToList();
            options.Add(def);

            return options.First();
        }

        private int GetRandomInt()
        {
            return -10000 + this.Rnd.Next(20000);
        }

        private double GetRandomDouble()
        {
            return (-10000 + this.Rnd.Next(20000)) / 100d;
        }
    }
}

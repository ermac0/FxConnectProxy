// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using FxConnectProxy.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxConnectProxy.Tests.Utils
{
    [TestClass]
    public class ObjectMapperTests
    {
        [TestMethod]
        public void AddMapping()
        {
            // Null.
            {
                var mapper = new ObjectMapper();
                mapper.AddMapping<ClassA, ClassB>(null);
            }

            // Normal.
            {
                var mapper = new ObjectMapper();
                var mapping = this.GetMapping();

                mapper.AddMapping<ClassA, ClassB>(mapping);
            }

            // Duplicate (allowed).
            {
                var mapper = new ObjectMapper();
                var mapping = this.GetMapping();

                mapper.AddMapping<ClassA, ClassB>(mapping);
                mapper.AddMapping<ClassA, ClassB>(mapping);
            }

            // Duplicate (not allowed).
            {
                var mapper = new ObjectMapper(true);
                var mapping = this.GetMapping();

                mapper.AddMapping<ClassA, ClassB>(mapping);

                AssertEx.Throws<InvalidOperationException>(() =>
                {
                    mapper.AddMapping<ClassA, ClassB>(mapping);
                });
            }
        }

        [TestMethod]
        public void MapUnknown()
        {
            {
                var mapper = new ObjectMapper();

                var from = new ClassA();
                var to = new ClassB();

                AssertEx.Throws<InvalidOperationException>(() =>
                {
                    mapper.Map(from, to);
                });
            }

            {
                var mapper = new ObjectMapper();

                var from = new ClassA();
                ClassB to = null;

                AssertEx.Throws<InvalidOperationException>(() =>
                {
                    to = mapper.Map<ClassA, ClassB>(from);
                });
            }
        }

        [TestMethod]
        public void MapNulls()
        {
            // Nulls
            {
                var mapper = new ObjectMapper();
                mapper.AddMapping(this.GetMapping());

                ClassA from = null;
                var to = new ClassB();

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    mapper.Map(from, to);
                });
            }

            // Nulls
            {
                var mapper = new ObjectMapper();
                mapper.AddMapping(this.GetMapping());

                ClassA from = null;
                ClassB to = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    to = mapper.Map<ClassA, ClassB>(from);
                });
            }

            // Nulls
            {
                var mapper = new ObjectMapper();
                mapper.AddMapping(this.GetMapping());

                ClassA from = new ClassA()
                {
                    Age = 11,
                    Name = "Joe Smith",
                    Time = new DateTime(2010, 1, 1),
                };

                ClassB to = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    mapper.Map(from, to);
                });
            }
        }

        [TestMethod]
        public void MapKnown()
        {
            {
                var mapper = new ObjectMapper();

                var from = new ClassA()
                {
                    Age = 11,
                    Name = "Joe Smith",
                    Time = new DateTime(2010, 1, 1),
                };

                var to = new ClassB();
                var mapping = this.GetMapping();
                mapper.AddMapping<ClassA, ClassB>(mapping);

                mapper.Map(from, to);

                Assert.AreEqual(from.Age, to.Age);
                Assert.AreEqual(from.Name, to.FullName);
                Assert.IsNull(to.City);
            }

            {
                var mapper = new ObjectMapper();

                var from = new ClassA()
                {
                    Age = 11,
                    Name = "Joe Smith",
                    Time = new DateTime(2010, 1, 1),
                };

                ClassB to = null;
                var mapping = this.GetMapping();
                mapper.AddMapping<ClassA, ClassB>(mapping);

                to = mapper.Map<ClassA, ClassB>(from);

                Assert.AreEqual(from.Age, to.Age);
                Assert.AreEqual(from.Name, to.FullName);
                Assert.IsNull(to.City);
            }

            // Value type.
            {
                var mapper = new ObjectMapper();

                mapper.AddMapping<double, int>((_from, _to, _m) =>
                {
                    _to = (int)_from;
                });

                double from = 4.5;
                int to;

                to = mapper.Map<double, int>(from);
            }
        }

        [TestMethod]
        public void DoubleMapping()
        {
            {
                var mapper = new ObjectMapper();
                mapper.AddMapping(this.GetMapping());
                mapper.AddMapping(this.GetMapping2());

                var from = new ClassA()
                {
                    Age = 11,
                    Name = "Joe Smith",
                    Time = new DateTime(2010, 1, 1),
                };

                var to = new ClassB();

                mapper.Map(from, to);

                Assert.AreEqual(from.Age + 10, to.Age);
                Assert.AreEqual("[" + from.Name + "]", to.FullName);
                Assert.AreEqual("Town", to.City);
            }

            {
                var mapper = new ObjectMapper();
                mapper.AddMapping(this.GetMapping());
                mapper.AddMapping(this.GetMapping2());

                var from = new ClassA()
                {
                    Age = 11,
                    Name = "Joe Smith",
                    Time = new DateTime(2010, 1, 1),
                };

                ClassB to = null;

                to = mapper.Map<ClassA, ClassB>(from);

                Assert.AreEqual(from.Age + 10, to.Age);
                Assert.AreEqual("[" + from.Name + "]", to.FullName);
                Assert.AreEqual("Town", to.City);
            }
        }

        [TestMethod]
        public void MapObjects()
        {
            // Unknown mapping
            {
                var mapper = new ObjectMapper();

                var from = new ClassA()
                {
                    Age = 11,
                    Name = "Joe Smith",
                    Time = new DateTime(2010, 1, 1),
                };

                var to = new ClassB();

                AssertEx.Throws<InvalidOperationException>(() =>
                {
                    mapper.MapObjects(from, to);
                });
            }

            // Nulls
            {
                var mapper = new ObjectMapper();
                mapper.AddMapping(this.GetMapping());

                ClassA from = null;
                ClassB to = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    mapper.MapObjects(from, to);
                });

                from = new ClassA()
                {
                    Age = 11,
                    Name = "Joe Smith",
                    Time = new DateTime(2010, 1, 1),
                };

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    mapper.MapObjects(from, to);
                });
            }

            // Known mapping
            {
                var mapper = new ObjectMapper();
                mapper.AddMapping(this.GetMapping());

                var from = new ClassA()
                {
                    Age = 11,
                    Name = "Joe Smith",
                    Time = new DateTime(2010, 1, 1),
                };

                var to = new ClassB();

                mapper.MapObjects(from, to);

                Assert.AreEqual(from.Age, to.Age);
                Assert.AreEqual(from.Name, to.FullName);
                Assert.IsNull(to.City);
            }
        }

        private Action<ClassA, ClassB, ObjectMapper> GetMapping()
        {
            return (Action<ClassA, ClassB, ObjectMapper>)((from, to, m) =>
            {
                to.Age = from.Age;
                to.FullName = from.Name;
            });
        }

        private Action<ClassA, ClassB, ObjectMapper> GetMapping2()
        {
            return (Action<ClassA, ClassB, ObjectMapper>)((from, to, m) =>
            {
                to.Age = from.Age + 10;
                to.FullName = "[" + from.Name + "]";
                to.City = "Town";
            });
        }

        class ClassA
        {
            public DateTime Time { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        class ClassB
        {
            public string FullName { get; set; }

            public string City { get; set; }

            public int Age { get; set; }
        }

    }
}

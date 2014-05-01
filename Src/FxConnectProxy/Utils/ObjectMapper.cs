// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Utils
{
    public class ObjectMapper
    {
        private readonly object _MappingsSync = new object();
        private Dictionary<Tuple<Type, Type>, object> Mappings { get; set; }
        private bool PreventDuplicateMappings { get; set; }

        public ObjectMapper(bool preventDuplicateMappings = false)
        {
            this.Mappings = new Dictionary<Tuple<Type, Type>, object>();
            this.PreventDuplicateMappings = preventDuplicateMappings;
        }

        private static Tuple<Type, Type> GetKey(Type from, Type to)
        {
            return Tuple.Create(from, to);
        }

        public void MapObjects(object from, object to)
        {
            if (from == null)
            {
                throw new ArgumentNullException("from");
            }

            if (to == null)
            {
                throw new ArgumentNullException("to");
            }

            var mapping = this.GetMapping(GetKey(from.GetType(), to.GetType())) as Delegate;

            mapping.Method.Invoke(mapping, new [] { from, to, this });
        }

        public void Map<TFrom, TTo>(TFrom from, TTo to)
        {
            if (from == null)
            {
                throw new ArgumentNullException("from");
            }

            if (to == null)
            {
                throw new ArgumentNullException("to");
            }

            var mapping = this.GetMapping(GetKey(typeof(TFrom), typeof(TTo))) as Action<TFrom, TTo, ObjectMapper>;

            mapping(from, to, this);
        }

        public TTo Map<TFrom, TTo>(TFrom source)
            where TTo : new()
        {
            var to = new TTo();

            this.Map<TFrom, TTo>(source, to);

            return to;
        }

        private object GetMapping(Tuple<Type, Type> key)
        {
            lock (this._MappingsSync)
            {
                if (!this.Mappings.ContainsKey(key))
                {
                    throw new InvalidOperationException("Required mapping not found.");
                }

                return this.Mappings[key];
            }
        }

        public void AddMapping<TFrom, TTo>(Action<TFrom, TTo, ObjectMapper> mapping)
        {
            if (mapping == null)
            {
                return;
            }

            lock (this._MappingsSync)
            {
                var key = GetKey(typeof(TFrom), typeof(TTo));

                if (this.Mappings.ContainsKey(key) && this.PreventDuplicateMappings)
                {
                    throw new InvalidOperationException("Mapping already defined for that pair.");
                }

                this.Mappings[key] = mapping;
            }
        }
    }
}

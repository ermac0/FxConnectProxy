// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class ValueMap
    {
        // Both lists are public, so their content may be changed
        // externally. But this is not an immutable structure at the moment.
        public List<ValueMapItemBase> Values { get; private set; }
        public List<ValueMap> ChildMaps { get; private set; }

        public ValueMap()
        {
            this.Values = new List<ValueMapItemBase>();
            this.ChildMaps = new List<ValueMap>();
        }

        public void AddParam(RequestParam param, bool value)
        {
            this.Values.Add(new ValueMapItem<bool>(ValueMapItemType.Boolean, param, value));
        }

        public void AddParam(RequestParam param, double value)
        {
            this.Values.Add(new ValueMapItem<double>(ValueMapItemType.Double, param, value));
        }

        public void AddParam(RequestParam param, int value)
        {
            this.Values.Add(new ValueMapItem<int>(ValueMapItemType.Int, param, value));
        }

        public void AddParam(RequestParam param, string value)
        {
            this.Values.Add(new ValueMapItem<string>(ValueMapItemType.String, param, value));
        }

        public void AddParam(RequestParam param, RequestCommand value)
        {
            this.Values.Add(new ValueMapItem<RequestCommand>(ValueMapItemType.Command, param, value));
        }

        public void AddChild(ValueMap map)
        {
            if (map != null)
            {
                this.ChildMaps.Add(map);
            }
        }

        public void Clear()
        {
            this.Values.Clear();
            this.ChildMaps.Clear();
        }
    }

    public abstract class ValueMapItemBase
    {
        public ValueMapItemType Type { get; set; }

        public RequestParam Param { get; set; }
    }

    public class ValueMapItem<T> : ValueMapItemBase
    {
        public T Value { get; set; }

        public ValueMapItem()
        {
        }

        public ValueMapItem(ValueMapItemType type, RequestParam param, T value)
        {
            this.Type = type;
            this.Param = param;
            this.Value = value;
        }
    }

    public enum ValueMapItemType
    {
        Boolean = 0,
        Double = 1,
        Int = 2,
        String = 3,
        Command = 4,
    }
}

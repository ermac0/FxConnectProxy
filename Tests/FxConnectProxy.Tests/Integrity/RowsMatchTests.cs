using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using fxcore2;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;

namespace FxConnectProxy.Tests.Integrity
{
    /// <summary>
    /// This module does the integrity testing - checks if properties on FxConnectProxy data objects
    /// match those in ForexConnect.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RowsMatchTests
    {
        private Dictionary<Tuple<Type, Type, string, string, Type, Type>, object> AllowedConversions { get; set; }

        /// <summary>
        /// Method goes thru defined mappings and checks Source and Target objects (Types) and tries to establish
        /// whether the properties on both sides match. It's useful when version of ForexConnect is updated
        /// to see if nothing is out of order.
        /// It also compares PropertyType on both objects.
        /// </summary>
        [TestMethod]
        public void CompareObjects()
        {
            this.AllowedConversions = this.GetAllowedConversions();

            foreach (var item in this.GetMappings())
            {
                this.CompareMapping(item);
            }
        }

        private Dictionary<Tuple<Type, Type, string, string, Type, Type>, object> GetAllowedConversions()
        {
            var dict = new Dictionary<Tuple<Type, Type, string, string, Type, Type>, object>();

            this.AddAllowedConversion<O2GAccountRow, AccountRow, string, AccountMaintenanceType>(dict, "MaintenanceType");
            this.AddAllowedConversion<O2GAccountRow, AccountRow, string, AccountKind>(dict, "AccountKind");

            this.AddAllowedConversion<O2GClosedTradeRow, ClosedTradeRow, string, BuySellEnum>(dict, "BuySell");
            this.AddAllowedConversion<O2GClosedTradeRow, ClosedTradeRow, string, AccountKind>(dict, "AccountKind");

            this.AddAllowedConversion<O2GMessageRow, MessageRow, string, MessageFeature>(dict, "Feature");
            this.AddAllowedConversion<O2GMessageRow, MessageRow, string, MessageType>(dict, "Type");

            this.AddAllowedConversion<O2GOfferRow, OfferRow, string, InstrumentTradingStatus>(dict, "TradingStatus");
            this.AddAllowedConversion<O2GOfferRow, OfferRow, int, InstrumentType>(dict, "InstrumentType");
            this.AddAllowedConversion<O2GOfferRow, OfferRow, string, PriceTradable>(dict, "AskTradable");
            this.AddAllowedConversion<O2GOfferRow, OfferRow, string, PriceTradable>(dict, "BidTradable");

            this.AddAllowedConversion<O2GOrderRow, OrderRow, int, ContingencyType>(dict, "ContingencyType");
            this.AddAllowedConversion<O2GOrderRow, OrderRow, string, AccountKind>(dict, "AccountKind");
            this.AddAllowedConversion<O2GOrderRow, OrderRow, string, TimeInForce>(dict, "TimeInForce");
            this.AddAllowedConversion<O2GOrderRow, OrderRow, string, OrderStatus>(dict, "Status");
            this.AddAllowedConversion<O2GOrderRow, OrderRow, string, OrderStage>(dict, "Stage");
            this.AddAllowedConversion<O2GOrderRow, OrderRow, string, OrderType>(dict, "Type");
            this.AddAllowedConversion<O2GOrderRow, OrderRow, string, BuySellEnum>(dict, "BuySell");

            this.AddAllowedConversion<O2GTradeRow, TradeRow, string, BuySellEnum>(dict, "BuySell");
            this.AddAllowedConversion<O2GTradeRow, TradeRow, string, AccountKind>(dict, "AccountKind");

            return dict;
        }

        private void AddAllowedConversion<TFrom, TTo, TSource, TTarget>(Dictionary<Tuple<Type, Type, string, string, Type, Type>, object> dict, string property)
        {
            dict.Add(Tuple.Create(typeof(TFrom), typeof(TTo), property, property, typeof(TSource), typeof(TTarget)), null);
        }

        private void CompareMapping(Tuple<Type, Type> mapping)
        {
            var from = mapping.Item1;
            var to = mapping.Item2;

            var sourceProps = from.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance)
                .Where(x => x.CanRead).ToDictionary(x => x.Name, StringComparer.OrdinalIgnoreCase);
            var targetProps = to.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance)
                .Where(x => x.CanWrite).ToDictionary(x => x.Name, StringComparer.OrdinalIgnoreCase);

            // Check for not mapped properties.
            foreach (var item in sourceProps.Select(x => x.Value).ToList())
            {
                if (!targetProps.ContainsKey(item.Name))
                {
                    throw new AssertFailedException("Missing property '" + item.Name + "' on '" + to.Name + "'.");
                }

                // Compare the types of the properties - see if they match.
                var target = targetProps[item.Name];
                if (!item.PropertyType.Equals(target.PropertyType) && !this.IsConversionAllowed(from, to, item, target))
                {
                    throw new AssertFailedException("Properties' types don't match: '" + from.Name + "." + item.Name + " (" + item.PropertyType.Name + ")'  ==> '" + to.Name + "." + target.Name + " (" + target.PropertyType.Name + ")'.");
                }

                targetProps.Remove(item.Name);
            }

            // Extra properties.
            foreach (var item in targetProps.Select(x => x.Value).ToList())
            {
                if (!sourceProps.ContainsKey(item.Name))
                {
                    // Extra property.
                    Assert.Inconclusive("Extra property '{0}' on '{1}'.", item.Name, to.Name);
                }
            }
        }

        private bool IsConversionAllowed(Type from, Type to, PropertyInfo sourceProp, PropertyInfo targetProp)
        {
            return this.AllowedConversions.ContainsKey(Tuple.Create(from, to, sourceProp.Name, targetProp.Name,
                sourceProp.PropertyType, targetProp.PropertyType));
        }

        private List<Tuple<Type, Type>> GetMappings()
        {
            var mappings = new List<Tuple<Type, Type>>();

            this.AddMapping<O2GAccountRow, AccountRow>(mappings);
            this.AddMapping<O2GAccountTableRow, AccountTableRow>(mappings);

            this.AddMapping<O2GClosedTradeRow, ClosedTradeRow>(mappings);
            this.AddMapping<O2GClosedTradeTableRow, ClosedTradeTableRow>(mappings);

            this.AddMapping<O2GMessageRow, MessageRow>(mappings);
            this.AddMapping<O2GMessageTableRow, MessageTableRow>(mappings);

            this.AddMapping<O2GOfferRow, OfferRow>(mappings);
            this.AddMapping<O2GOfferTableRow, OfferTableRow>(mappings);

            this.AddMapping<O2GOrderRow, OrderRow>(mappings);
            this.AddMapping<O2GOrderTableRow, OrderTableRow>(mappings);

            this.AddMapping<O2GSummaryRow, SummaryRow>(mappings);
            this.AddMapping<O2GSummaryTableRow, SummaryTableRow>(mappings);

            this.AddMapping<O2GTradeRow, TradeRow>(mappings);
            this.AddMapping<O2GTradeTableRow, TradeTableRow>(mappings);

            return mappings;
        }

        private void AddMapping<TFrom, TTo>(List<Tuple<Type, Type>> mappings)
        {
            if (mappings == null)
            {
                throw new ArgumentNullException("mappings");
            }

            mappings.Add(Tuple.Create(typeof(TFrom), typeof(TTo)));
        }

        /// <summary>
        /// This method goes thru all objects derived from O2GRow and checks if appropriate mapping was
        /// defined for more detailed object comparison.
        /// </summary>
        [TestMethod]
        public void AreAllObjectsMapped()
        {
            var bt = typeof(O2GRow);
            var asm = bt.Assembly;
            var mappings = this.GetMappings();

            var rows = asm.GetTypes().Where(x => !x.IsAbstract && bt.IsAssignableFrom(x) && !bt.Equals(x));

            foreach (var item in rows)
            {
                if (!mappings.Any(x => x.Item1.Equals(item)))
                {
                    throw new AssertFailedException("Missing mapping for '" + item.Name + "'.");
                }
            }
        }
    }
}

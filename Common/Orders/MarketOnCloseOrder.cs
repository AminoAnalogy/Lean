﻿/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using QuantConnect.Securities;

namespace QuantConnect.Orders
{
    /// <summary>
    /// Market on close order type - submits a market order on exchange close
    /// </summary>
    public class MarketOnCloseOrder : Order
    {
        /// <summary>
        /// MarketOnClose Order Type
        /// </summary>
        public override OrderType Type
        {
            get { return OrderType.MarketOnClose; }
        }

        /// <summary>
        /// Value of the order at limit price if a limit order, or market price if a market order.
        /// </summary>
        public override decimal Value
        {
            get { return AbsoluteQuantity * Price; }
        }

        /// <summary>
        /// Intiializes a new instance of the <see cref="MarketOnCloseOrder"/> class.
        /// </summary>
        public MarketOnCloseOrder()
        {
        }

        /// <summary>
        /// Intiializes a new instance of the <see cref="MarketOnCloseOrder"/> class.
        /// </summary>
        /// <param name="symbol">The security's symbol being ordered</param>
        /// <param name="type">The security type of the symbol</param>
        /// <param name="quantity">The number of units to order</param>
        /// <param name="time">The current time</param>
        /// <param name="tag">A user defined tag for the order</param>
        public MarketOnCloseOrder(Symbol symbol, SecurityType type, int quantity, DateTime time, string tag = "")
            : base(symbol, quantity, time, tag, type)
        {
        }

        /// <summary>
        /// Gets the value of this order at the given market price.
        /// </summary>
        /// <param name="currentMarketPrice">The current market price of the security</param>
        /// <returns>The value of this order given the current market price</returns>
        public override decimal GetValue(decimal currentMarketPrice)
        {
            return Quantity * currentMarketPrice;
        }

        /// <summary>
        /// Creates a deep-copy clone of this order
        /// </summary>
        /// <returns>A copy of this order</returns>
        public override Order Clone()
        {
            var order = new MarketOnCloseOrder();
            CopyTo(order);
            return order;
        }
    }
}

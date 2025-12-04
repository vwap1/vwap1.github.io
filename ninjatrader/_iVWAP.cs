
/*
Calculate 옵션에 따라서 폭주하는 버그를 수정
*/

#region Using declarations

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.SuperDom;
using NinjaTrader.Data;
using NinjaTrader.NinjaScript;
using NinjaTrader.Core.FloatingPoint;
using NinjaTrader.NinjaScript.DrawingTools;

#endregion

//This namespace holds Indicators in this folder and is required. Do not change it. 
namespace NinjaTrader.NinjaScript.Indicators
{
	public class _iVWAP : Indicator
	{
		private	Series<double>	iCumVolume;
		private	Series<double>	iCumTypicalVolume;

		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Calculate	= Calculate.OnEachTick;
				IsOverlay	= true;

				AddPlot(Brushes.DimGray, "iVWAP");
			}
			else if (State == State.DataLoaded)
			{
				iCumVolume			= new Series<double>(this, MaximumBarsLookBack.Infinite);
				iCumTypicalVolume	= new Series<double>(this, MaximumBarsLookBack.Infinite);
			}
			else if (State == State.Terminated)
			{
			}
		}

		protected override void OnBarUpdate()
		{
			if (Bars.IsFirstBarOfSession)
			{
				iCumVolume[0]			= Volume[0];
				iCumTypicalVolume[0]	= Volume[0] * Typical[0];
			}
			else
			{
				iCumVolume[0]			= iCumVolume[1] + Volume[0];
				iCumTypicalVolume[0]	= iCumTypicalVolume[1] + (Volume[0] * Typical[0]);
			}

			Value[0] = iCumTypicalVolume[0] / iCumVolume[0];
		}
	}
}

#region NinjaScript generated code. Neither change nor remove.

namespace NinjaTrader.NinjaScript.Indicators
{
	public partial class Indicator : NinjaTrader.Gui.NinjaScript.IndicatorRenderBase
	{
		private _iVWAP[] cache_iVWAP;
		public _iVWAP _iVWAP()
		{
			return _iVWAP(Input);
		}

		public _iVWAP _iVWAP(ISeries<double> input)
		{
			if (cache_iVWAP != null)
				for (int idx = 0; idx < cache_iVWAP.Length; idx++)
					if (cache_iVWAP[idx] != null &&  cache_iVWAP[idx].EqualsInput(input))
						return cache_iVWAP[idx];
			return CacheIndicator<_iVWAP>(new _iVWAP(), input, ref cache_iVWAP);
		}
	}
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
	public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
	{
		public Indicators._iVWAP _iVWAP()
		{
			return indicator._iVWAP(Input);
		}

		public Indicators._iVWAP _iVWAP(ISeries<double> input )
		{
			return indicator._iVWAP(input);
		}
	}
}

namespace NinjaTrader.NinjaScript.Strategies
{
	public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
	{
		public Indicators._iVWAP _iVWAP()
		{
			return indicator._iVWAP(Input);
		}

		public Indicators._iVWAP _iVWAP(ISeries<double> input )
		{
			return indicator._iVWAP(input);
		}
	}
}

#endregion

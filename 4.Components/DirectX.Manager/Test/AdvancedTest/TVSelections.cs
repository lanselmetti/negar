// ------------------------------------------------------------------
// Negar.DirectX.Capture.Manager
//
// History:
//	2007-Jan-13	HV		- created
//
//      2009-Feb-27	HV		- modified
//      - Removed broadcast frequency support
//
// Copyright (C) 2006, 2009 Hans Vosman
//
// Example code to make pre-selection of TV broadcast stations easier.
//
// The normal way for selecting a TV broadcast station is using Channel
// in the Tuner class. Usually for European countries a channel number
// has a range from 1 to 368. This channel number maps to a pre-defined
// TV broadcast frequency. Unless the mapping is known, the use of this
// channel nummber is not really straightforward.
// 
// In this example the broadcast information is stored hard coded.
// This example can easily be modified to read the data from file or
// another source.
// ------------------------------------------------------------------

using System;

namespace Negar.DirectX.Capture.Manager
{
	/// <summary>
	/// Summary description for TVSelections.
	/// </summary>
	public class TVSelections
	{
		public TVSelections()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public String GetChannelName
		{
			get
			{
				return BroadcastStations[CurrentChannel - 1];
			}
		}

		public Int32 GetChannelNumber
		{
			get
			{
				return ChannelNumbers[CurrentChannel - 1];
			}
		}

		public Int32 CurrentChannel
		{
			set
			{
				if((value >= 1)&&(value <= MaxNbrStations))
				{
					currentChannel = value;
				}
			}
			get
			{
				return currentChannel;
			}
		}

		public Int32 NbrTunerChannels 
		{
			get { return MaxNbrStations; }
		}

		// Example data to make selection of TV broadcast stations.
		private const Int32 MaxNbrStations = 15;
		private Int32 currentChannel = 1;

		private String[] BroadcastStations = new String[MaxNbrStations]
		{
			"Nederland 1",
			"Nederland 2",
			"Nederland 3",
			"RTL 4",
			"RTL 5",
			"RTL 7",
			"SBS 6",
			"Veronica",
			"Net 5",
			"Omroep Flevoland",
			"TMF",
			"Discovery Channel",
			"National Geographic",
			"CNN",
			"BBC World",
		};

		// Set TV broadcast station via Tuner.Channel = ChannelNumbers[index];
		private Int32[] ChannelNumbers = new Int32[MaxNbrStations]
		{
			88,
			70,
			74,
			289,
			293,
			298,
			323,
			265,
			319,
			110,
			212,
			207,
			256,
			306,
			234,
		};
	}
}


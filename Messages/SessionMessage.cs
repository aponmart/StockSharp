#region S# License
/******************************************************************************************
NOTICE!!!  This program and source code is owned and licensed by
StockSharp, LLC, www.stocksharp.com
Viewing or use of this code requires your acceptance of the license
agreement found at https://github.com/StockSharp/StockSharp/blob/master/LICENSE
Removal of this comment is a violation of the license agreement.

Project: StockSharp.Messages.Messages
File: SessionMessage.cs
Created: 2015, 11, 11, 2:32 PM

Copyright 2010 by StockSharp, LLC
*******************************************************************************************/
#endregion S# License
namespace StockSharp.Messages
{
	using System;
	using System.Runtime.Serialization;

	using Ecng.Common;

	using StockSharp.Localization;

	/// <summary>
	/// Session states.
	/// </summary>
	[DataContract]
	[Serializable]
	public enum SessionStates
	{
		/// <summary>
		/// Session assigned. Cannot register new orders, but can cancel.
		/// </summary>
		[EnumMember]
		[EnumDisplayNameLoc(LocalizedStrings.Str399Key)]
		Assigned,

		/// <summary>
		/// Session active. Can register and cancel orders.
		/// </summary>
		[EnumMember]
		[EnumDisplayNameLoc(LocalizedStrings.Str238Key)]
		Active,

		/// <summary>
		/// Suspended. Cannot register new orders, but can cancel.
		/// </summary>
		[EnumMember]
		[EnumDisplayNameLoc(LocalizedStrings.Str400Key)]
		Paused,

		/// <summary>
		/// Rejected. Cannot register and cancel orders.
		/// </summary>
		[EnumMember]
		[EnumDisplayNameLoc(LocalizedStrings.Str401Key)]
		ForceStopped,

		/// <summary>
		/// Finished. Cannot register and cancel orders.
		/// </summary>
		[EnumMember]
		[EnumDisplayNameLoc(LocalizedStrings.Str402Key)]
		Ended,
	}

	/// <summary>
	/// Session change changed message.
	/// </summary>
	[DataContract]
	[Serializable]
	public class SessionMessage : Message
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SessionMessage"/>.
		/// </summary>
		public SessionMessage()
			: base(MessageTypes.Session)
		{
		}

		/// <summary>
		/// Board code.
		/// </summary>
		[DataMember]
		public string BoardCode { get; set; }

		/// <summary>
		/// Session state.
		/// </summary>
		[DataMember]
		public SessionStates State { get; set; }

		/// <summary>
		/// Create a copy of <see cref="SessionMessage"/>.
		/// </summary>
		/// <returns>Copy.</returns>
		public override Message Clone()
		{
			return new SessionMessage
			{
				BoardCode = BoardCode,
				State = State,
				LocalTime = LocalTime
			};
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return base.ToString() + ",Board={0},State={1}".Put(BoardCode, State);
		}
	}
}
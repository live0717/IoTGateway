﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Waher.Networking.Cluster.Serialization.Properties
{
	/// <summary>
	/// Int64 property
	/// </summary>
	public class Int64Property : Property
	{
		/// <summary>
		/// Property Type
		/// </summary>
		public override Type PropertyType => typeof(long);

		/// <summary>
		/// Serializes the property value of an object.
		/// </summary>
		/// <param name="Output">Output</param>
		/// <param name="Value">Value to serialize</param>
		public override void Serialize(Serializer Output, object Value)
		{
			Output.WriteInt64((long)Value);
		}

		/// <summary>
		/// Deserializes the property value
		/// </summary>
		/// <param name="Input">Binary representation.</param>
		/// <param name="ExpectedType">Expected Type</param>
		/// <returns>Deserialized value.</returns>
		public override object Deserialize(Deserializer Input, Type ExpectedType)
		{
			return Input.ReadInt64();
		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using Waher.Security.EllipticCurves;

namespace Waher.Networking.XMPP.P2P.E2E
{
	/// <summary>
	/// NIST P-224 Curve
	/// </summary>
	public class NistP224Aes : EcAes256
	{
		/// <summary>
		/// NIST P-224 Curve
		/// </summary>
		/// <param name="X">X-coordinate of remote public key.</param>
		/// <param name="Y">Y-coordinate of remote public key.</param>
		/// <param name="LocalEndpoint">Local security endpoint, if available.</param>
		public NistP224Aes(byte[] X, byte[] Y, EndpointSecurity LocalEndpoint)
			: base(X, Y, LocalEndpoint)
		{
		}

		/// <summary>
		/// Security strength of End-to-End encryption scheme.
		/// </summary>
		public override int SecurityStrength => 112;

		/// <summary>
		/// Name of elliptic curve
		/// </summary>
		public override string CurveName => this.localEndpoint.p224.CurveName;

		/// <summary>
		/// Elliptic Curve
		/// </summary>
		protected override CurvePrimeField Curve => this.localEndpoint.p224;

		/// <summary>
		/// Previous Elliptic Curve
		/// </summary>
		protected override CurvePrimeField PrevCurve => this.localEndpoint.p224Old;
	}
}
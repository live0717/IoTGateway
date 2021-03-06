﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Waher.Content.Markdown.Model.SpanElements
{
	/// <summary>
	/// Sub-script text
	/// </summary>
	public class SubScript : MarkdownElementChildren
	{
		/// <summary>
		/// Sub-script text
		/// </summary>
		/// <param name="Document">Markdown document.</param>
		/// <param name="ChildElements">Child elements.</param>
		public SubScript(MarkdownDocument Document, IEnumerable<MarkdownElement> ChildElements)
			: base(Document, ChildElements)
		{
		}

		/// <summary>
		/// Sub-script text
		/// </summary>
		/// <param name="Document">Markdown document.</param>
		/// <param name="Text">Subscript text.</param>
		public SubScript(MarkdownDocument Document, string Text)
			: base(Document, new MarkdownElement[] { new InlineText(Document, Text) })
		{
		}

		/// <summary>
		/// Generates Markdown for the markdown element.
		/// </summary>
		/// <param name="Output">Markdown will be output here.</param>
		public override void GenerateMarkdown(StringBuilder Output)
		{
			Output.Append('[');
			base.GenerateMarkdown(Output);
			Output.Append(']');
		}

		/// <summary>
		/// Generates HTML for the markdown element.
		/// </summary>
		/// <param name="Output">HTML will be output here.</param>
		public override void GenerateHTML(StringBuilder Output)
		{
			Output.Append("<sub>");

			foreach (MarkdownElement E in this.Children)
				E.GenerateHTML(Output);

			Output.Append("</sub>");
		}

		/// <summary>
		/// Generates XAML for the markdown element.
		/// </summary>
		/// <param name="Output">XAML will be output here.</param>
		/// <param name="TextAlignment">Alignment of text in element.</param>
		public override void GenerateXAML(XmlWriter Output, TextAlignment TextAlignment)
		{
			Output.WriteStartElement("Run");
			Output.WriteAttributeString("Typography.Variants", "Subscript");

			foreach (MarkdownElement E in this.Children)
				E.GenerateXAML(Output, TextAlignment);

			Output.WriteEndElement();
		}

		/// <summary>
		/// Generates plain text for the markdown element.
		/// </summary>
		/// <param name="Output">Plain text will be output here.</param>
		public override void GeneratePlainText(StringBuilder Output)
		{
			StringBuilder sb = new StringBuilder();
			int i;

			base.GeneratePlainText(sb);

			foreach (char ch in sb.ToString())
			{
				i = nrmScriptLetters.IndexOf(ch);
				if (i < 0)
					Output.Append(ch);
				else
					Output.Append(subScriptLetters[i]);
			}
		}

		private const string nrmScriptLetters = "0123456789+-=()aeoxhklmnpst";
		private const string subScriptLetters = "₀₁₂₃₄₅₆₇₈₉₊₋₌₍₎ₐₑₒₓₕₖₗₘₙₚₛₜ";

		/// <summary>
		/// If the element is an inline span element.
		/// </summary>
		internal override bool InlineSpanElement
		{
			get { return true; }
		}

		/// <summary>
		/// Exports the element to XML.
		/// </summary>
		/// <param name="Output">XML Output.</param>
		public override void Export(XmlWriter Output)
		{
			this.Export(Output, "SubScript");
		}

		/// <summary>
		/// Creates an object of the same type, and meta-data, as the current object,
		/// but with content defined by <paramref name="Children"/>.
		/// </summary>
		/// <param name="Children">New content.</param>
		/// <param name="Document">Document that will contain the element.</param>
		/// <returns>Object of same type and meta-data, but with new content.</returns>
		public override MarkdownElementChildren Create(IEnumerable<MarkdownElement> Children, MarkdownDocument Document)
		{
			return new SubScript(Document, Children);
		}

	}
}

﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision: 5343 $</version>
// </file>

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

using ICSharpCode.FormsDesigner;
using ICSharpCode.RubyBinding;
using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace RubyBinding.Tests.Utils
{
	/// <summary>
	/// Gives access to various protected methods
	/// of the RubyDesignerGenerator class for testing.
	/// </summary>
	public class DerivedRubyDesignerGenerator : RubyDesignerGenerator
	{
		string fileNamePassedToParseFile;
		string textContentPassedToParseFile;
		ParseInformation parseInfoToReturnFromParseFile;

		public DerivedRubyDesignerGenerator() : this(new MockTextEditorProperties())
		{
		}
		
		public DerivedRubyDesignerGenerator(ITextEditorProperties textEditorProperties) 
			: base(textEditorProperties)
		{
		}
								
		/// <summary>
		/// Gets the filename passed to the ParseFile method. This is called
		/// at the start of the GetInitializeComponents method to get the
		/// latest parse information.
		/// </summary>
		public string FileNamePassedToParseFileMethod {
			get { return fileNamePassedToParseFile; }
		}
		
		/// <summary>
		/// Gets the text content passed to the ParseFile method when 
		/// the GetInitializeComponents method is called.
		/// </summary>
		public string TextContentPassedToParseFileMethod {
			get { return textContentPassedToParseFile; }
		}
		
		
		/// <summary>
		/// Gets or sets the parse information that will be returned from the
		/// ParseFile method.
		/// </summary>
		public ParseInformation ParseInfoToReturnFromParseFileMethod {
			get { return parseInfoToReturnFromParseFile; }
			set { parseInfoToReturnFromParseFile = value; }
		}
		
		/// <summary>
		/// Gets the view content attached to the Ruby Designer Generator.
		/// </summary>
		public FormsDesignerViewContent GetViewContent()
		{
			return base.ViewContent;
		}

		/// <summary>
		/// Calls the RubyDesignerGenerator's CreateEventHandler method.
		/// </summary>
		public string CallCreateEventHandler(string eventMethodName, string body, string indentation)
		{
			return base.CreateEventHandler(eventMethodName, body, indentation);
		}
				
		protected override ParseInformation ParseFile(string fileName, string textContent)
		{
			fileNamePassedToParseFile = fileName;
			textContentPassedToParseFile = textContent;
			return parseInfoToReturnFromParseFile;
		}
	}
}

﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision: 5343 $</version>
// </file>

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Scripting.Hosting.Shell;
using ICSharpCode.RubyBinding;
using NUnit.Framework;

namespace RubyBinding.Tests.Console
{
	/// <summary>
	/// The Home Key should return the user to the start of the line after the prompt.
	/// </summary>
	[TestFixture]
	public class RubyConsoleHomeKeyTestFixture
	{
		MockTextEditor textEditor;
		RubyConsole console;
		string prompt = ">>> ";

		[SetUp]
		public void Init()
		{
			textEditor = new MockTextEditor();
			console = new RubyConsole(textEditor, null);
			console.Write(prompt, Style.Prompt);
		}
		
		[Test]
		public void HomeKeyPressedWhenNoUserTextInConsole()
		{
			textEditor.RaiseDialogKeyPressEvent(Keys.Home);
		
			int expectedColumn = prompt.Length;
			Assert.AreEqual(expectedColumn, textEditor.Column);
		}
		
		[Test]
		public void HomeKeyPressedWhenTextInConsole()
		{
			textEditor.RaiseKeyPressEvent('a');
			textEditor.RaiseDialogKeyPressEvent(Keys.Home);

			int expectedColumn = prompt.Length;
			Assert.AreEqual(expectedColumn, textEditor.Column);
		}
	}
}

﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision: 4063 $</version>
// </file>

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.PythonBinding;
using IronPython;
using IronPython.Compiler;
using IronPython.Compiler.Ast;
using IronPython.Runtime;
using Microsoft.CSharp;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;
using NRefactory = ICSharpCode.NRefactory;

namespace PyWalker
{
	public partial class MainForm : Form, IOutputWriter
	{
		public MainForm()
		{
			InitializeComponent();			
		}
		
		public void WriteLine(string s)
		{
			walkerOutputTextBox.Text += String.Concat(s, "\r\n");
		}
		
		void RunAstWalkerButtonClick(object sender, EventArgs e)
		{
			try {
				IronPython.Hosting.Python.CreateEngine();
				Clear();
				PythonCompilerSink sink = new PythonCompilerSink();
				SourceUnit source = DefaultContext.DefaultPythonContext.CreateFileUnit(@"D:\Temp.py", codeTextBox.Text);
				CompilerContext context = new CompilerContext(source, new PythonCompilerOptions(), sink);
				Parser parser = Parser.CreateParser(context, new PythonOptions());
				PythonAst ast = parser.ParseFile(false);
				if (sink.Errors.Count == 0) {
					ResolveWalker walker = new ResolveWalker(this);
					ast.Walk(walker);
				} else {
					walkerOutputTextBox.Text += "\r\n";
					foreach (PythonCompilerError error in sink.Errors) {
						walkerOutputTextBox.Text += error.ToString() + "\r\n";
					}
				}
			} catch (Exception ex) {
				walkerOutputTextBox.Text = ex.ToString();
			}
		}
		
		void ClearButtonClick(object sender, EventArgs e)
		{
			Clear();
		}
		
		void Clear()
		{
			walkerOutputTextBox.Text = String.Empty;
		}
				
		/// <summary>
		/// Round trips the Python code through the code DOM and back
		/// to source code.
		/// </summary>
		void RunRoundTripButtonClick(object sender, EventArgs e)
		{
			try {
				Clear();
//				PythonProvider provider = new PythonProvider();
//				CodeCompileUnit unit = provider.Parse(new StringReader(codeTextBox.Text));
//				StringWriter writer = new StringWriter();
//				CodeGeneratorOptions options = new CodeGeneratorOptions();
//				options.BlankLinesBetweenMembers = false;
//				options.IndentString = "\t";
//				provider.GenerateCodeFromCompileUnit(unit, writer, options);
//				
//				walkerOutputTextBox.Text = writer.ToString();
			} catch (Exception ex) {
				walkerOutputTextBox.Text = ex.ToString();
			}
		}
		
		/// <summary>
		/// Converts the C# code to a code dom using the NRefactory
		/// library and then visits the code dom.
		/// </summary>
		void RunCSharpToPythonClick(object sender, EventArgs e)
		{
			try {
				Clear();
				NRefactoryToPythonConverter converter = new NRefactoryToPythonConverter(NRefactory.SupportedLanguage.CSharp);
				walkerOutputTextBox.Text = converter.Convert(codeTextBox.Text);
			} catch (Exception ex) {
				walkerOutputTextBox.Text = ex.ToString();
			}			
		}
		
		/// <summary>
		/// Converts C# to python using the code dom generated by the
		/// NRefactory parser.
		/// </summary>
		void RunNRefactoryCSharpCodeDomVisitorClick(object sender, EventArgs e)
		{
			try {
				Clear();
				using (NRefactory.IParser parser = NRefactory.ParserFactory.CreateParser(NRefactory.SupportedLanguage.CSharp, new StringReader(codeTextBox.Text))) {
					parser.ParseMethodBodies = false;
					parser.Parse();
					NRefactory.Visitors.CodeDomVisitor visitor = new NRefactory.Visitors.CodeDomVisitor();
					visitor.VisitCompilationUnit(parser.CompilationUnit, null);
					CodeDomVisitor codeDomVisitor = new CodeDomVisitor(this);
					codeDomVisitor.Visit(visitor.codeCompileUnit);					
				}
			} catch (Exception ex) {
				walkerOutputTextBox.Text = ex.ToString();
			}			
		}		
		
		void RunCSharpNRefactoryVisitorClick(object sender, EventArgs e)
		{
			try {
				Clear();
				using (NRefactory.IParser parser = NRefactory.ParserFactory.CreateParser(NRefactory.SupportedLanguage.CSharp, new StringReader(codeTextBox.Text))) {
					parser.ParseMethodBodies = false;
					parser.Parse();
					NRefactoryAstVisitor visitor = new NRefactoryAstVisitor(this);
					visitor.VisitCompilationUnit(parser.CompilationUnit, null);
				}
			} catch (Exception ex) {
				walkerOutputTextBox.Text = ex.ToString();
			}			
		}
	}
}

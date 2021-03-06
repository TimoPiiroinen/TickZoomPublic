﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision: 4482 $</version>
// </file>

using System;
using System.IO;
using NUnit.Framework;
using ICSharpCode.NRefactory.Parser;
using ICSharpCode.NRefactory.Ast;

namespace ICSharpCode.NRefactory.Tests.Ast
{
	[TestFixture]
	public class FixedStatementTests
	{
		#region C#
		[Test]
		public void CSharpFixedStatementTest()
		{
			FixedStatement fixedStmt = ParseUtilCSharp.ParseStatement<FixedStatement>("fixed (int* ptr = &myIntArr) { }");
			// TODO : Extend test.
		}
		#endregion
		
		#region VB.NET
			// No VB.NET representation
		#endregion	
	}
}

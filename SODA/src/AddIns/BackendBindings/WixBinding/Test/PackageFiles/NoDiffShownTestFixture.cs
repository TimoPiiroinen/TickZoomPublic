﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision: 2785 $</version>
// </file>

using ICSharpCode.WixBinding;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WixBinding.Tests.PackageFiles
{
	/// <summary>
	/// Tests that no diff is shown in the IWixPackageFilesView via
	/// the WixPackagesFileEditor
	/// </summary>
	[TestFixture]
	public class NoDiffShownTestFixture : PackageFilesTestFixtureBase
	{
		List<string> directories;

		[Test]
		public void NoDirectorySelected()
		{
			base.InitFixture();
			directories = new List<string>();
			editor.ShowDiff();
			Assert.IsTrue(view.IsNoDifferencesFoundMessageDisplayed);
			Assert.AreEqual(1, directories.Count);
			Assert.AreEqual(@"C:\Projects\Test\bin", directories[0]);
		}
		
		public override string[] GetFiles(string path)
		{
			directories.Add(path);
			return new string[] {@"license.rtf"};
		}

		protected override string GetWixXml()
		{
			return "<Wix xmlns='http://schemas.microsoft.com/wix/2006/wi'>\r\n" +
				"\t<Product Name='Test' \r\n" +
				"\t         Version='1.0' \r\n" +
				"\t         Language='1013' \r\n" +
				"\t         Manufacturer='#develop' \r\n" +
				"\t         Id='????????-????-????-????-????????????'>\r\n" +
				"\t\t<Package/>\r\n" +
				"\t\t<Directory Id='TARGETDIR' SourceName='SourceDir'>\r\n" +
				"\t\t\t<Directory Id='ProgramFilesFolder' Name='PFiles'>\r\n" +
				"\t\t\t\t<Directory Id='INSTALLDIR' Name='YourApp' LongName='Your Application'>\r\n" +
				"\t\t\t\t\t<Component Id='MyComponent' DiskId='1'>\r\n" +
				"\t\t\t\t\t\t<File Id='LicenseFile' Name='license.rtf' Source='bin\\license.rtf' />\r\n" +
				"\t\t\t\t\t</Component>\r\n" +
				"\t\t\t\t</Directory>\r\n" +
				"\t\t\t</Directory>\r\n" +
				"\t\t</Directory>\r\n" +
				"\t</Product>\r\n" +
				"</Wix>";
		}
	}
}

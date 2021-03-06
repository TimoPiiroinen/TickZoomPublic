// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 3135 $</version>
// </file>

// This file is automatically generated - any changes will be lost

#pragma warning disable 1591

namespace Debugger.Wrappers.CorSym
{
	using System;
	
	
	public partial class CorSymReader_deprecatedClass
	{
		
		private Debugger.Interop.CorSym.CorSymReader_deprecatedClass wrappedObject;
		
		internal Debugger.Interop.CorSym.CorSymReader_deprecatedClass WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public CorSymReader_deprecatedClass(Debugger.Interop.CorSym.CorSymReader_deprecatedClass wrappedObject)
		{
			this.wrappedObject = wrappedObject;
			ResourceManager.TrackCOMObject(wrappedObject, typeof(CorSymReader_deprecatedClass));
		}
		
		public static CorSymReader_deprecatedClass Wrap(Debugger.Interop.CorSym.CorSymReader_deprecatedClass objectToWrap)
		{
			if ((objectToWrap != null))
			{
				return new CorSymReader_deprecatedClass(objectToWrap);
			} else
			{
				return null;
			}
		}
		
		~CorSymReader_deprecatedClass()
		{
			object o = wrappedObject;
			wrappedObject = null;
			ResourceManager.ReleaseCOMObject(o, typeof(CorSymReader_deprecatedClass));
		}
		
		public bool Is<T>() where T: class
		{
			System.Reflection.ConstructorInfo ctor = typeof(T).GetConstructors()[0];
			System.Type paramType = ctor.GetParameters()[0].ParameterType;
			return paramType.IsInstanceOfType(this.WrappedObject);
		}
		
		public T As<T>() where T: class
		{
			try {
				return CastTo<T>();
			} catch {
				return null;
			}
		}
		
		public T CastTo<T>() where T: class
		{
			return (T)Activator.CreateInstance(typeof(T), this.WrappedObject);
		}
		
		public static bool operator ==(CorSymReader_deprecatedClass o1, CorSymReader_deprecatedClass o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(CorSymReader_deprecatedClass o1, CorSymReader_deprecatedClass o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			CorSymReader_deprecatedClass casted = o as CorSymReader_deprecatedClass;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
		}
		
		
		public ISymUnmanagedDocument GetDocument(System.IntPtr url, System.Guid language, System.Guid languageVendor, System.Guid documentType)
		{
			return ISymUnmanagedDocument.Wrap(this.WrappedObject.GetDocument(url, language, languageVendor, documentType));
		}
		
		public void GetDocuments(uint cDocs, out uint pcDocs, ISymUnmanagedDocument[] pDocs)
		{
			Debugger.Interop.CorSym.ISymUnmanagedDocument[] array_pDocs = new Debugger.Interop.CorSym.ISymUnmanagedDocument[pDocs.Length];
			for (int i = 0; (i < pDocs.Length); i = (i + 1))
			{
				if ((pDocs[i] != null))
				{
					array_pDocs[i] = pDocs[i].WrappedObject;
				}
			}
			this.WrappedObject.GetDocuments(cDocs, out pcDocs, array_pDocs);
			for (int i = 0; (i < pDocs.Length); i = (i + 1))
			{
				if ((array_pDocs[i] != null))
				{
					pDocs[i] = ISymUnmanagedDocument.Wrap(array_pDocs[i]);
				} else
				{
					pDocs[i] = null;
				}
			}
		}
		
		public int GetDocumentVersion(ISymUnmanagedDocument pDoc, out int version)
		{
			int pbCurrent;
			this.WrappedObject.GetDocumentVersion(pDoc.WrappedObject, out version, out pbCurrent);
			return pbCurrent;
		}
		
		public void GetGlobalVariables(uint cVars, out uint pcVars, System.IntPtr pVars)
		{
			this.WrappedObject.GetGlobalVariables(cVars, out pcVars, pVars);
		}
		
		public ISymUnmanagedMethod GetMethod(uint token)
		{
			return ISymUnmanagedMethod.Wrap(this.WrappedObject.GetMethod(token));
		}
		
		public ISymUnmanagedMethod GetMethodByVersion(uint token, int version)
		{
			return ISymUnmanagedMethod.Wrap(this.WrappedObject.GetMethodByVersion(token, version));
		}
		
		public ISymUnmanagedMethod GetMethodFromDocumentPosition(ISymUnmanagedDocument document, uint line, uint column)
		{
			return ISymUnmanagedMethod.Wrap(this.WrappedObject.GetMethodFromDocumentPosition(document.WrappedObject, line, column));
		}
		
		public void GetMethodsFromDocumentPosition(ISymUnmanagedDocument document, uint line, uint column, uint cMethod, out uint pcMethod, System.IntPtr pRetVal)
		{
			this.WrappedObject.GetMethodsFromDocumentPosition(document.WrappedObject, line, column, cMethod, out pcMethod, pRetVal);
		}
		
		public int GetMethodVersion(ISymUnmanagedMethod pMethod)
		{
			int version;
			this.WrappedObject.GetMethodVersion(pMethod.WrappedObject, out version);
			return version;
		}
		
		public void GetNamespaces(uint cNameSpaces, out uint pcNameSpaces, System.IntPtr namespaces)
		{
			this.WrappedObject.GetNamespaces(cNameSpaces, out pcNameSpaces, namespaces);
		}
		
		public void GetSymAttribute(uint parent, System.IntPtr name, uint cBuffer, out uint pcBuffer, System.IntPtr buffer)
		{
			this.WrappedObject.GetSymAttribute(parent, name, cBuffer, out pcBuffer, buffer);
		}
		
		public void GetSymbolStoreFileName(uint cchName, out uint pcchName, System.IntPtr szName)
		{
			this.WrappedObject.GetSymbolStoreFileName(cchName, out pcchName, szName);
		}
		
		public uint UserEntryPoint
		{
			get
			{
				return this.WrappedObject.GetUserEntryPoint();
			}
		}
		
		public void GetVariables(uint parent, uint cVars, out uint pcVars, System.IntPtr pVars)
		{
			this.WrappedObject.GetVariables(parent, cVars, out pcVars, pVars);
		}
		
		public void Initialize(object importer, System.IntPtr filename, System.IntPtr searchPath, IStream pIStream)
		{
			this.WrappedObject.Initialize(importer, filename, searchPath, pIStream.WrappedObject);
		}
		
		public void ReplaceSymbolStore(System.IntPtr filename, IStream pIStream)
		{
			this.WrappedObject.ReplaceSymbolStore(filename, pIStream.WrappedObject);
		}
		
		public void UpdateSymbolStore(System.IntPtr filename, IStream pIStream)
		{
			this.WrappedObject.UpdateSymbolStore(filename, pIStream.WrappedObject);
		}
	}
}

#pragma warning restore 1591

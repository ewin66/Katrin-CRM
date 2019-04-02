#region Copyright (c) 2000-2012 Developer Express Inc.
/*
{*******************************************************************}
{                                                                   }
{       Developer Express .NET Component Library                    }
{       eXpressApp Framework                                        }
{                                                                   }
{       Copyright (c) 2000-2012 Developer Express Inc.              }
{       ALL RIGHTS RESERVED                                         }
{                                                                   }
{   The entire contents of this file is protected by U.S. and       }
{   International Copyright Laws. Unauthorized reproduction,        }
{   reverse-engineering, and distribution of all or any portion of  }
{   the code contained in this file is strictly prohibited and may  }
{   result in severe civil and criminal penalties and will be       }
{   prosecuted to the maximum extent possible under the law.        }
{                                                                   }
{   RESTRICTIONS                                                    }
{                                                                   }
{   THIS SOURCE CODE AND ALL RESULTING INTERMEDIATE FILES           }
{   ARE CONFIDENTIAL AND PROPRIETARY TRADE                          }
{   SECRETS OF DEVELOPER EXPRESS INC. THE REGISTERED DEVELOPER IS   }
{   LICENSED TO DISTRIBUTE THE PRODUCT AND ALL ACCOMPANYING .NET    }
{   CONTROLS AS PART OF AN EXECUTABLE PROGRAM ONLY.                 }
{                                                                   }
{   THE SOURCE CODE CONTAINED WITHIN THIS FILE AND ALL RELATED      }
{   FILES OR ANY PORTION OF ITS CONTENTS SHALL AT NO TIME BE        }
{   COPIED, TRANSFERRED, SOLD, DISTRIBUTED, OR OTHERWISE MADE       }
{   AVAILABLE TO OTHER INDIVIDUALS WITHOUT EXPRESS WRITTEN CONSENT  }
{   AND PERMISSION FROM DEVELOPER EXPRESS INC.                      }
{                                                                   }
{   CONSULT THE END USER LICENSE AGREEMENT FOR INFORMATION ON       }
{   ADDITIONAL RESTRICTIONS.                                        }
{                                                                   }
{*******************************************************************}
*/
#endregion Copyright (c) 2000-2012 Developer Express Inc.

using System;
using System.Collections.Generic;
using System.Text;
//using DevExpress.ExpressApp.Localization;
namespace Katrin.AppFramework
{
	public interface IDisposableExt : IDisposable {
		bool IsDisposed { get; }
	}
	public class DisposeIndicator : IDisposableExt {
		private bool isDisposed = false;
		#region IDisposableExt Members
		public bool IsDisposed {
			get { return isDisposed; }
		}
		#endregion
		#region IDisposable Members
		public void Dispose() {
			isDisposed = true;
		}
		#endregion
	}
}
namespace Katrin.AppFramework.Utils
{
	public static class Guard {
		internal static void Assert(bool assertion, string message) {
			if(!assertion) {
				throw new InvalidOperationException("Assertion broken: " + message);
			}
		}
		public static void ArgumentNotNull(object argumentValue, string argumentName) {
            if (argumentValue == null)
                throw new ArgumentNullException(argumentName);
		}
		public static void ArgumentNotNullOrEmpty(string argumentValue, string argumentName) {
			if (String.IsNullOrEmpty(argumentValue)) {
				throw new ArgumentNullException(argumentName); 
			}
		}
        //public static void TypeArgumentIs(Type expectedType, Type passedType, string argumentName) {
        //    if(!expectedType.IsAssignableFrom(passedType)) {
        //        throw new ArgumentException(SystemExceptionLocalizer.GetExceptionMessage(ExceptionId.TheTypeIsNotDescendantOf, passedType, expectedType), argumentName);
        //    }
        //}
		public static void NotDisposed(IDisposableExt obj) {
			if (obj.IsDisposed) {
				throw new ObjectDisposedException(obj.GetType().FullName);
			}
		}
        //public static void CheckObjectFromObjectSpace(IObjectSpace objectSpace, Object obj) {
        //    if((obj != null) && !objectSpace.Contains(obj)) {
        //        throw new ArgumentException(SystemExceptionLocalizer.GetExceptionMessage(ExceptionId.PassedObjectBelongsToAnotherObjectSpace));
        //    }
        //}
		public static ArgumentOutOfRangeException CreateArgumentOutOfRangeException(object argumentValue, string argumentName) {
			return new ArgumentOutOfRangeException(argumentName, argumentValue, new ArgumentOutOfRangeException().Message);
		}
	}
}

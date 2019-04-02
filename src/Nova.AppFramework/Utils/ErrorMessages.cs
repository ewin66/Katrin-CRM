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
namespace Katrin.AppFramework.Utils
{
	public class ErrorMessages {
		const string separator = "\n";
		private Dictionary<string, List<string>> messages;
		private int lockCallCount;
		private bool needRaiseEvent;
		private string GetTargetKey(object target) {
			return target == null ? string.Empty : "-" + target.GetHashCode().ToString();
		}
		private string GetKey(string propertyName, object target) {
			return propertyName + GetTargetKey(target);
		}
		protected virtual void RaiseMessagesChanged() {
			if(lockCallCount == 0) {
				if(MessagesChanged != null) {
					MessagesChanged(this, EventArgs.Empty);
				}
			}
			else {
				needRaiseEvent = true;
			}
		}
		public ErrorMessages() {
			messages = new Dictionary<string, List<string>>();
		}
		public void AddMessage(string propertyName, object target, string message) {
			string key = GetKey(propertyName, target);
			List<string> list;
			lock(messages) {
				if(!messages.TryGetValue(key, out list)) {
					list = new List<string>();
					messages.Add(key, list);
				}
			}
			if(!list.Contains(message)) {
				list.Add(message);
				RaiseMessagesChanged();
			}
		}
		public void LoadMessages(ErrorMessages source) {
			lock(messages) {
				messages = new Dictionary<string, List<string>>(source.messages);
			}
			RaiseMessagesChanged();
		}
		public string GetMessage(string propertyName, object target) {
			if(!IsEmpty) {
				if(propertyName.Contains("!")) {
					propertyName = propertyName.TrimEnd('!');
					if(propertyName.Contains("!")) {
						propertyName = string.Join("", propertyName.Split('!'));
					}
				}
				int length = propertyName.Length;
				while(length > 0) {
					propertyName = propertyName.Substring(0, length);
					List<string> result;
					lock(messages) {
						if(messages.TryGetValue(GetKey(propertyName, target), out result)) {
							result.Sort();
							return string.Join(separator, result.ToArray());
						}
					}
					length = propertyName.LastIndexOf('.');
				}
			}
			return null;
		}

        //public string GetRelatedMessage(string propertyName, object target) {
        //    string result = null;
        //    if(!IsEmpty) {
        //        int length = propertyName.Length;
        //        string[] splittedName = propertyName.Split(".".ToCharArray(), 2);
        //        result = GetMessage(propertyName, target);
        //        if(result == null && splittedName.Length > 1) {
        //            object value;
        //            try {
        //                ITypeInfo typeInfo = XafTypesInfo.Instance.FindTypeInfo(target.GetType());
        //                if (typeInfo == null) return null;
        //                IMemberInfo memberInfo = typeInfo.FindMember(splittedName[0]);
        //                if (memberInfo == null) return null;
        //                value = memberInfo.GetValue(target);
        //            }catch{
        //                return null;
        //            }
        //            result = GetRelatedMessage(splittedName[1], value);
        //        }
        //    }
        //    return result;
        //}

		public string GetMessages(object target) {
			if(target == null)
				return null;
			string keyEnd = GetTargetKey(target);
			List<string> result = new List<string>();
			lock(messages) {
				foreach(KeyValuePair<string, List<string>> pair in messages) {
					if(pair.Key.EndsWith(keyEnd)) {
						List<string> currentList = pair.Value;
						for(int i = 0; i < currentList.Count; i++) {
							if(!result.Contains(currentList[i]))
								result.Add(currentList[i]);
						}
					}
				}
			}
			result.Sort();
			return string.Join(separator, result.ToArray());
		}
		public void Clear() {
			if(!IsEmpty) {
				lock(messages) {
					messages.Clear();
				}
				RaiseMessagesChanged();
			}
		}
		public void LockEvents() {
			lockCallCount++;
		}
		public void UnlockEvents() {
			lockCallCount--;
			if(lockCallCount == 0 && needRaiseEvent) {
				needRaiseEvent = false;
				RaiseMessagesChanged();
			}
		}
		public bool IsEmpty {
			get { return messages.Count == 0; }
		}
		public event EventHandler MessagesChanged;
	}
}

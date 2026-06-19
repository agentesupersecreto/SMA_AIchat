using System;
using System.Collections;
using System.Reflection;
using System.Text;
using com.ootii.Geometry;
using com.ootii.Helpers;
using com.ootii.Utilities;
using com.ootii.Utilities.Debug;
using UnityEngine;

namespace com.ootii.Data.Serializers
{
	// Token: 0x0200005F RID: 95
	public class JSONSerializer
	{
		// Token: 0x06000483 RID: 1155 RVA: 0x0001A1A0 File Offset: 0x000183A0
		public static string Serialize(object rObject, bool rIncludeProperties)
		{
			if (rObject == null)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{");
			stringBuilder.Append("__Type");
			stringBuilder.Append(" : ");
			stringBuilder.Append("\"");
			stringBuilder.Append(rObject.GetType().AssemblyQualifiedName);
			stringBuilder.Append("\"");
			if (ReflectionHelper.IsPrimitive(rObject.GetType()))
			{
				string text = JSONSerializer.SerializeValue(rObject);
				stringBuilder.Append(", ");
				stringBuilder.Append("__Value");
				stringBuilder.Append(" : ");
				stringBuilder.Append(text);
			}
			else if (rObject.GetType() == typeof(string))
			{
				string text2 = JSONSerializer.SerializeValue(rObject);
				stringBuilder.Append(", ");
				stringBuilder.Append("__Value");
				stringBuilder.Append(" : ");
				stringBuilder.Append(text2);
			}
			else
			{
				if (rIncludeProperties)
				{
					foreach (PropertyInfo propertyInfo in rObject.GetType().GetProperties())
					{
						if (propertyInfo.CanRead && propertyInfo.CanWrite && !ReflectionHelper.IsDefined(propertyInfo, typeof(SerializationIgnoreAttribute)))
						{
							string name = propertyInfo.Name;
							object obj = null;
							try
							{
								obj = propertyInfo.GetValue(rObject, null);
								if (obj == null)
								{
									goto IL_018E;
								}
							}
							catch
							{
								obj = rObject;
							}
							string text3 = JSONSerializer.SerializeValue(obj);
							stringBuilder.Append(", ");
							stringBuilder.Append(name);
							stringBuilder.Append(" : ");
							stringBuilder.Append(text3);
						}
						IL_018E:;
					}
				}
				foreach (FieldInfo fieldInfo in rObject.GetType().GetFields())
				{
					if (!fieldInfo.IsInitOnly && !fieldInfo.IsLiteral && !ReflectionHelper.IsDefined(fieldInfo, typeof(NonSerializedAttribute)) && (fieldInfo.IsPublic || ReflectionHelper.IsDefined(fieldInfo, typeof(SerializeField)) || ReflectionHelper.IsDefined(fieldInfo, typeof(SerializableAttribute))))
					{
						string name2 = fieldInfo.Name;
						object value = fieldInfo.GetValue(rObject);
						if (value != null)
						{
							string text4 = JSONSerializer.SerializeValue(value);
							stringBuilder.Append(", ");
							stringBuilder.Append(name2);
							stringBuilder.Append(" : ");
							stringBuilder.Append(text4);
						}
					}
				}
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0001A440 File Offset: 0x00018640
		public static string SerializeValue(string rName, object rValue)
		{
			if (rValue == null)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{");
			stringBuilder.Append(rName);
			stringBuilder.Append(" : ");
			stringBuilder.Append(JSONSerializer.SerializeValue(rValue));
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0001A49C File Offset: 0x0001869C
		public static Type GetType(string rJSON)
		{
			JSONNode jsonnode = JSONNode.Parse(rJSON);
			if (jsonnode == null)
			{
				return null;
			}
			string value = jsonnode["__Type"].Value;
			if (value == null || value.Length == 0)
			{
				return null;
			}
			return Type.GetType(value);
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0001A4E0 File Offset: 0x000186E0
		public static T DeserializeValue<T>(string rJSON)
		{
			Type typeFromHandle = typeof(T);
			if (rJSON == null || rJSON.Length == 0)
			{
				return default(T);
			}
			JSONNode jsonnode = JSONNode.Parse(rJSON);
			if (jsonnode == null || jsonnode.Count == 0)
			{
				return default(T);
			}
			object obj = JSONSerializer.DeserializeValue(typeFromHandle, jsonnode[0]);
			if (obj == null || obj.GetType() != typeFromHandle)
			{
				return default(T);
			}
			return (T)((object)obj);
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x0001A55E File Offset: 0x0001875E
		public static T Deserialize<T>(string rJSON)
		{
			return (T)((object)JSONSerializer.Deserialize(rJSON));
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x0001A56C File Offset: 0x0001876C
		public static object Deserialize(string rJSON)
		{
			JSONNode jsonnode = JSONNode.Parse(rJSON);
			if (jsonnode == null)
			{
				return null;
			}
			string value = jsonnode["__Type"].Value;
			if (value == null || value.Length == 0)
			{
				return null;
			}
			Type type = Type.GetType(value);
			if (ReflectionHelper.IsPrimitive(type))
			{
				JSONNode jsonnode2 = jsonnode["__Value"];
				return JSONSerializer.DeserializeValue(type, jsonnode2);
			}
			if (type == typeof(string))
			{
				JSONNode jsonnode3 = jsonnode["__Value"];
				return JSONSerializer.DeserializeValue(type, jsonnode3);
			}
			object obj = null;
			try
			{
				obj = Activator.CreateInstance(type);
			}
			catch (Exception ex)
			{
				Debug.Log(string.Format("JSONSerializer.Deserialize() {0} {1} {2}", value, ex.Message, ex.StackTrace));
			}
			if (obj == null)
			{
				return null;
			}
			foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
			{
				if (propertyInfo.CanWrite && !ReflectionHelper.IsDefined(propertyInfo, typeof(SerializationIgnoreAttribute)))
				{
					JSONNode jsonnode4 = jsonnode[propertyInfo.Name];
					if (jsonnode4 != null)
					{
						object obj2 = JSONSerializer.DeserializeValue(propertyInfo.PropertyType, jsonnode4);
						if (obj2 != null)
						{
							propertyInfo.SetValue(obj, obj2, null);
						}
					}
				}
			}
			foreach (FieldInfo fieldInfo in obj.GetType().GetFields())
			{
				if (!fieldInfo.IsInitOnly && !fieldInfo.IsLiteral && !ReflectionHelper.IsDefined(fieldInfo, typeof(NonSerializedAttribute)))
				{
					JSONNode jsonnode5 = jsonnode[fieldInfo.Name];
					if (jsonnode5 != null)
					{
						object obj3 = JSONSerializer.DeserializeValue(fieldInfo.FieldType, jsonnode5);
						if (obj3 != null)
						{
							fieldInfo.SetValue(obj, obj3);
						}
					}
				}
			}
			return obj;
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0001A740 File Offset: 0x00018940
		public static void DeserializeInto(string rJSON, ref object rObject)
		{
			if (rJSON == null || rJSON.Length == 0)
			{
				return;
			}
			JSONNode jsonnode = JSONNode.Parse(rJSON);
			if (jsonnode == null || jsonnode.Count == 0)
			{
				return;
			}
			if (rObject == null)
			{
				string value = jsonnode["__Type"].Value;
				if (value == null || value.Length == 0)
				{
					return;
				}
				try
				{
					rObject = Activator.CreateInstance(Type.GetType(value));
				}
				catch (Exception ex)
				{
					Log.ConsoleWriteError(string.Format("JSONSerializer.DeserializeInto() {0} {1} {2}", value, ex.Message, ex.StackTrace));
				}
				if (rObject == null)
				{
					return;
				}
			}
			foreach (FieldInfo fieldInfo in rObject.GetType().GetFields())
			{
				if (!fieldInfo.IsInitOnly && !fieldInfo.IsLiteral && !ReflectionHelper.IsDefined(fieldInfo, typeof(NonSerializedAttribute)))
				{
					JSONNode jsonnode2 = jsonnode[fieldInfo.Name];
					if (jsonnode2 != null)
					{
						object obj = JSONSerializer.DeserializeValue(fieldInfo.FieldType, jsonnode2);
						if (obj != null)
						{
							fieldInfo.SetValue(rObject, obj);
						}
					}
				}
			}
			foreach (PropertyInfo propertyInfo in rObject.GetType().GetProperties())
			{
				if (propertyInfo.CanWrite && !ReflectionHelper.IsDefined(propertyInfo, typeof(SerializationIgnoreAttribute)))
				{
					JSONNode jsonnode3 = jsonnode[propertyInfo.Name];
					if (jsonnode3 != null)
					{
						object obj2 = JSONSerializer.DeserializeValue(propertyInfo.PropertyType, jsonnode3);
						if (obj2 != null)
						{
							propertyInfo.SetValue(rObject, obj2, null);
						}
					}
				}
			}
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0001A8D8 File Offset: 0x00018AD8
		private static string SerializeValue(object rValue)
		{
			if (rValue == null)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder("");
			Type type = rValue.GetType();
			if (type == typeof(string))
			{
				stringBuilder.Append("\"");
				stringBuilder.Append((string)rValue);
				stringBuilder.Append("\"");
			}
			else if (type == typeof(int))
			{
				stringBuilder.Append(((int)rValue).ToString());
			}
			else if (type == typeof(float))
			{
				stringBuilder.Append(((float)rValue).ToString("G8"));
			}
			else if (type == typeof(bool))
			{
				stringBuilder.Append(((bool)rValue).ToString());
			}
			else if (type == typeof(Vector2))
			{
				stringBuilder.Append("\"");
				stringBuilder.Append(((Vector2)rValue).ToString("G8"));
				stringBuilder.Append("\"");
			}
			else if (type == typeof(Vector3))
			{
				stringBuilder.Append("\"");
				stringBuilder.Append(((Vector3)rValue).ToString("G8"));
				stringBuilder.Append("\"");
			}
			else if (type == typeof(Vector4))
			{
				stringBuilder.Append("\"");
				stringBuilder.Append(((Vector4)rValue).ToString("G8"));
				stringBuilder.Append("\"");
			}
			else if (type == typeof(Quaternion))
			{
				stringBuilder.Append("\"");
				stringBuilder.Append(((Quaternion)rValue).ToString("G8"));
				stringBuilder.Append("\"");
			}
			else if (type == typeof(HumanBodyBones))
			{
				stringBuilder.Append(((int)rValue).ToString());
			}
			else if (type == typeof(Transform))
			{
				Transform transform = rValue as Transform;
				if (transform != null)
				{
					string text = ((JSONSerializer.RootObject != null) ? JSONSerializer.GetFullPath(JSONSerializer.RootObject.transform) : "");
					string text2 = JSONSerializer.GetFullPath(transform);
					if ((float)text.Length > 0f)
					{
						text2 = JSONSerializer.ReplaceFirst(text2, text, "[OOTII_ROOT]");
					}
					stringBuilder.Append("\"");
					stringBuilder.Append(text2);
					stringBuilder.Append("\"");
				}
			}
			else if (type == typeof(GameObject))
			{
				GameObject gameObject = rValue as GameObject;
				if (gameObject != null)
				{
					string text3 = ((JSONSerializer.RootObject != null) ? JSONSerializer.GetFullPath(JSONSerializer.RootObject.transform) : "");
					string text4 = JSONSerializer.GetFullPath(gameObject.transform);
					if ((float)text3.Length > 0f)
					{
						text4 = JSONSerializer.ReplaceFirst(text4, text3, "[OOTII_ROOT]");
					}
					stringBuilder.Append("\"");
					stringBuilder.Append(text4);
					stringBuilder.Append("\"");
				}
			}
			else if (type == typeof(Component))
			{
				Component component = rValue as Component;
				if (component != null)
				{
					string text5 = ((JSONSerializer.RootObject != null) ? JSONSerializer.GetFullPath(JSONSerializer.RootObject.transform) : "");
					string text6 = JSONSerializer.GetFullPath(component.transform);
					if ((float)text5.Length > 0f)
					{
						text6 = JSONSerializer.ReplaceFirst(text6, text5, "[OOTII_ROOT]");
					}
					stringBuilder.Append("\"");
					stringBuilder.Append(text6);
					stringBuilder.Append("\"");
				}
			}
			else if (rValue is IList)
			{
				stringBuilder.Append("[");
				for (int i = 0; i < ((IList)rValue).Count; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(JSONSerializer.SerializeValue(((IList)rValue)[i]));
				}
				stringBuilder.Append("]");
			}
			else if (rValue is IDictionary)
			{
				stringBuilder.Append("[");
				foreach (object obj in ((IDictionary)rValue).Keys)
				{
					string text7 = JSONSerializer.SerializeValue(obj);
					string text8 = JSONSerializer.SerializeValue(((IDictionary)rValue)[obj]);
					stringBuilder.Append("{ ");
					stringBuilder.Append(text7);
					stringBuilder.Append(" : ");
					stringBuilder.Append(text8);
					stringBuilder.Append(" }");
				}
				stringBuilder.Append("]");
			}
			else if (type == typeof(AnimationCurve))
			{
				stringBuilder.Append("\"");
				AnimationCurve animationCurve = rValue as AnimationCurve;
				for (int j = 0; j < animationCurve.keys.Length; j++)
				{
					Keyframe keyframe = animationCurve.keys[j];
					stringBuilder.Append(string.Concat(new string[]
					{
						keyframe.time.ToString("f5"),
						"|",
						keyframe.value.ToString("f5"),
						"|",
						keyframe.tangentMode.ToString(),
						"|",
						keyframe.inTangent.ToString("f5"),
						"|",
						keyframe.outTangent.ToString("f5")
					}));
					if (j < animationCurve.keys.Length - 1)
					{
						stringBuilder.Append(";");
					}
				}
				stringBuilder.Append("\"");
			}
			else
			{
				stringBuilder.Append(JSONSerializer.Serialize(rValue, false));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0001AF64 File Offset: 0x00019164
		private static object DeserializeValue(Type rType, JSONNode rValue)
		{
			if (rValue == null)
			{
				return ReflectionHelper.GetDefaultValue(rType);
			}
			if (rType == typeof(string))
			{
				return rValue.Value;
			}
			if (rType == typeof(int))
			{
				return rValue.AsInt;
			}
			if (rType == typeof(float))
			{
				return rValue.AsFloat;
			}
			if (rType == typeof(bool))
			{
				return rValue.AsBool;
			}
			if (rType == typeof(Vector2))
			{
				return Vector2.zero.FromString(rValue.Value);
			}
			if (rType == typeof(Vector3))
			{
				return Vector3.zero.FromString(rValue.Value);
			}
			if (rType == typeof(Vector4))
			{
				return Vector4.zero.FromString(rValue.Value);
			}
			if (rType == typeof(Quaternion))
			{
				return Quaternion.identity.FromString(rValue.Value);
			}
			if (rType == typeof(HumanBodyBones))
			{
				return (HumanBodyBones)rValue.AsInt;
			}
			if (rType == typeof(Transform))
			{
				string text = rValue.Value;
				Transform transform = null;
				if (text.Contains("[OOTII_ROOT]") && JSONSerializer.RootObject != null)
				{
					text = rValue.Value.Replace("[OOTII_ROOT]", "");
					if (text.Length > 0 && text.Substring(0, 1) == "/")
					{
						text = text.Substring(1);
					}
					transform = ((text.Length == 0) ? JSONSerializer.RootObject.transform : JSONSerializer.RootObject.transform.Find(text));
				}
				else
				{
					GameObject gameObject = GameObject.Find(text);
					if (gameObject != null)
					{
						transform = gameObject.transform;
					}
				}
				if (transform == null)
				{
					Debug.LogWarning("ootii.JSONSerializer.DeserializeValue - Transform name '" + text + "' not found, resulting in null");
					return null;
				}
				return transform;
			}
			else if (rType == typeof(GameObject))
			{
				string text2 = rValue.Value;
				Transform transform2 = null;
				if (text2.Contains("[OOTII_ROOT]") && JSONSerializer.RootObject != null)
				{
					text2 = rValue.Value.Replace("[OOTII_ROOT]", "");
					if (text2.Length > 0 && text2.Substring(0, 1) == "/")
					{
						text2 = text2.Substring(1);
					}
					transform2 = ((text2.Length == 0) ? JSONSerializer.RootObject.transform : JSONSerializer.RootObject.transform.Find(text2));
				}
				else
				{
					GameObject gameObject2 = GameObject.Find(text2);
					if (gameObject2 != null)
					{
						transform2 = gameObject2.transform;
					}
				}
				if (transform2 == null)
				{
					Debug.LogWarning("ootii.JSONSerializer.DeserializeValue - GameObject name '" + text2 + "' not found, resulting in null");
					return null;
				}
				return transform2.gameObject;
			}
			else if (ReflectionHelper.IsAssignableFrom(typeof(Component), rType))
			{
				string text3 = rValue.Value;
				Transform transform3 = null;
				if (text3.Contains("[OOTII_ROOT]") && JSONSerializer.RootObject != null)
				{
					text3 = rValue.Value.Replace("[OOTII_ROOT]", "");
					if (text3.Length > 0 && text3.Substring(0, 1) == "/")
					{
						text3 = text3.Substring(1);
					}
					transform3 = ((text3.Length == 0) ? JSONSerializer.RootObject.transform : JSONSerializer.RootObject.transform.Find(text3));
				}
				else
				{
					GameObject gameObject3 = GameObject.Find(text3);
					if (gameObject3 != null)
					{
						transform3 = gameObject3.transform;
					}
				}
				if (transform3 == null)
				{
					Debug.LogWarning("ootii.JSONSerializer.DeserializeValue - Component  name '" + text3 + "' not found, resulting in null");
					return null;
				}
				return transform3.gameObject.GetComponent(rType);
			}
			else
			{
				if (typeof(IList).IsAssignableFrom(rType))
				{
					IList list = null;
					Type type = rType;
					JSONArray asArray = rValue.AsArray;
					if (ReflectionHelper.IsGenericType(rType))
					{
						type = rType.GetGenericArguments()[0];
						list = Activator.CreateInstance(rType) as IList;
					}
					else if (rType.IsArray)
					{
						type = rType.GetElementType();
						list = Array.CreateInstance(type, asArray.Count);
					}
					for (int i = 0; i < asArray.Count; i++)
					{
						JSONNode jsonnode = asArray[i];
						object obj = JSONSerializer.DeserializeValue(type, jsonnode);
						if (list.Count > i)
						{
							list[i] = obj;
						}
						else
						{
							list.Add(obj);
						}
					}
					return list;
				}
				if (!typeof(IDictionary).IsAssignableFrom(rType))
				{
					if (rType == typeof(AnimationCurve))
					{
						if (rValue.Value.Length > 0)
						{
							AnimationCurve animationCurve = new AnimationCurve();
							string[] array = rValue.Value.Split(';', StringSplitOptions.None);
							for (int j = 0; j < array.Length; j++)
							{
								string[] array2 = array[j].Split('|', StringSplitOptions.None);
								if (array2.Length == 5)
								{
									int num = 0;
									float num2 = 0f;
									Keyframe keyframe = default(Keyframe);
									if (float.TryParse(array2[0], out num2))
									{
										keyframe.time = num2;
									}
									if (float.TryParse(array2[1], out num2))
									{
										keyframe.value = num2;
									}
									if (int.TryParse(array2[2], out num))
									{
										keyframe.tangentMode = num;
									}
									if (float.TryParse(array2[3], out num2))
									{
										keyframe.inTangent = num2;
									}
									if (float.TryParse(array2[4], out num2))
									{
										keyframe.outTangent = num2;
									}
									animationCurve.AddKey(keyframe);
								}
							}
							return animationCurve;
						}
					}
					else if (rType == typeof(Keyframe))
					{
						return new Keyframe(rValue["time"].AsFloat, rValue["value"].AsFloat, rValue["inTangent"].AsFloat, rValue["outTangent"].AsFloat);
					}
					return JSONSerializer.Deserialize(rValue.ToString());
				}
				if (!ReflectionHelper.IsGenericType(rType))
				{
					return null;
				}
				Type type2 = rType.GetGenericArguments()[0];
				Type type3 = rType.GetGenericArguments()[1];
				IDictionary dictionary = Activator.CreateInstance(rType) as IDictionary;
				JSONArray asArray2 = rValue.AsArray;
				for (int k = 0; k < asArray2.Count; k++)
				{
					JSONNode jsonnode2 = asArray2[k];
					foreach (string text4 in jsonnode2.AsObject.Dictionary.Keys)
					{
						object obj2 = JSONSerializer.DeserializeValue(type2, text4);
						object obj3 = JSONSerializer.DeserializeValue(type3, jsonnode2[text4]);
						if (dictionary.Contains(obj2))
						{
							dictionary[obj2] = obj3;
						}
						else
						{
							dictionary.Add(obj2, obj3);
						}
					}
				}
				return dictionary;
			}
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0001B674 File Offset: 0x00019874
		private static bool IsSimpleType(Type rType)
		{
			return rType == typeof(string) || rType == typeof(int) || rType == typeof(float) || rType == typeof(bool) || rType == typeof(Vector2) || rType == typeof(Vector3) || rType == typeof(Vector4) || rType == typeof(Quaternion) || rType == typeof(HumanBodyBones) || rType == typeof(Transform);
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x0001B74C File Offset: 0x0001994C
		public static string GetFullPath(Transform rTransform)
		{
			string text = "";
			Transform transform = rTransform;
			while (transform != null)
			{
				if (text.Length > 0)
				{
					text = "/" + text;
				}
				text = transform.name + text;
				transform = transform.parent;
			}
			return text;
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0001B798 File Offset: 0x00019998
		public static string ReplaceFirst(string rText, string rSearch, string rReplace)
		{
			int num = rText.IndexOf(rSearch);
			if (num < 0)
			{
				return rText;
			}
			return rText.Substring(0, num) + rReplace + rText.Substring(num + rSearch.Length);
		}

		// Token: 0x04000247 RID: 583
		public const string RootObjectID = "[OOTII_ROOT]";

		// Token: 0x04000248 RID: 584
		public static GameObject RootObject;
	}
}

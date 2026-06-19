using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assets
{
	// Token: 0x02000168 RID: 360
	public static class ReflectionsEXT
	{
		// Token: 0x06000A98 RID: 2712 RVA: 0x00023BE8 File Offset: 0x00021DE8
		public static Type GetUnderlyingType(this MemberInfo member)
		{
			MemberTypes memberType = member.MemberType;
			if (memberType <= MemberTypes.Field)
			{
				if (memberType == MemberTypes.Event)
				{
					return ((EventInfo)member).EventHandlerType;
				}
				if (memberType == MemberTypes.Field)
				{
					Type fieldType = ((FieldInfo)member).FieldType;
					if (fieldType.IsArray)
					{
						return fieldType.GetElementType();
					}
					if (fieldType.IsGenericType)
					{
						return fieldType.GetGenericArguments().First<Type>();
					}
					return fieldType;
				}
			}
			else
			{
				if (memberType == MemberTypes.Method)
				{
					return ((MethodInfo)member).ReturnType;
				}
				if (memberType == MemberTypes.Property)
				{
					Type propertyType = ((PropertyInfo)member).PropertyType;
					if (propertyType.IsArray)
					{
						return propertyType.GetElementType();
					}
					if (propertyType.IsGenericType)
					{
						return propertyType.GetGenericArguments().First<Type>();
					}
					return propertyType;
				}
			}
			throw new ArgumentException("Input MemberInfo must be if type EventInfo, FieldInfo, MethodInfo, or PropertyInfo");
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x00023C9C File Offset: 0x00021E9C
		public static bool IsCollection(this MemberInfo member)
		{
			MemberTypes memberType = member.MemberType;
			if (memberType == MemberTypes.Field)
			{
				return typeof(ICollection).IsAssignableFrom(((FieldInfo)member).FieldType);
			}
			if (memberType != MemberTypes.Method)
			{
				return memberType == MemberTypes.Property && typeof(ICollection).IsAssignableFrom(((PropertyInfo)member).PropertyType);
			}
			return typeof(ICollection).IsAssignableFrom(((MethodInfo)member).ReturnType);
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x00023D14 File Offset: 0x00021F14
		public static FieldInfo[] GetFieldsFlattenHierarchy(this Type type, BindingFlags bindingAttr)
		{
			List<FieldInfo> list = type.GetFields(bindingAttr).ToList<FieldInfo>();
			if (type.BaseType != null && type.BaseType != ReflectionsEXT.objectType)
			{
				list.AddRange(type.BaseType.GetFieldsFlattenHierarchy(bindingAttr));
			}
			return list.ToArray();
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x00023D68 File Offset: 0x00021F68
		public static PropertyInfo[] GetPropertiesFlattenHierarchy(this Type type, BindingFlags bindingAttr)
		{
			List<PropertyInfo> list = type.GetProperties(bindingAttr).ToList<PropertyInfo>();
			while (type.BaseType != null && type.BaseType != ReflectionsEXT.objectType)
			{
				list.AddRange(type.BaseType.GetPropertiesFlattenHierarchy(bindingAttr));
			}
			return list.Distinct<PropertyInfo>().ToArray<PropertyInfo>();
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x00023DC4 File Offset: 0x00021FC4
		public static MemberInfo GetMemberFlattenHierarchy(this Type type, string name, BindingFlags bindingAttr)
		{
			MemberInfo[] array = type.GetMember(name, bindingAttr);
			Type type2 = type.BaseType;
			while (array.Length == 0 && type2 != null && type.BaseType != ReflectionsEXT.objectType)
			{
				array = type2.GetMember(name, bindingAttr);
				type2 = type2.BaseType;
			}
			if (array.Length == 0)
			{
				return null;
			}
			return array[0];
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x00023E1C File Offset: 0x0002201C
		public static FieldInfo GetFieldFlattenHierarchy(this Type type, string name, BindingFlags bindingAttr)
		{
			FieldInfo fieldInfo = type.GetField(name, bindingAttr);
			Type type2 = type.BaseType;
			while (fieldInfo == null && type2 != null && type.BaseType != ReflectionsEXT.objectType)
			{
				fieldInfo = type2.GetField(name, bindingAttr);
				type2 = type2.BaseType;
			}
			return fieldInfo;
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x00023E70 File Offset: 0x00022070
		public static PropertyInfo GetPropertyFlattenHierarchy(this Type type, string name, BindingFlags bindingAttr)
		{
			PropertyInfo propertyInfo = type.GetProperty(name, bindingAttr);
			Type type2 = type.BaseType;
			while (propertyInfo == null && type2 != null && type.BaseType != ReflectionsEXT.objectType)
			{
				propertyInfo = type2.GetProperty(name, bindingAttr);
				type2 = type2.BaseType;
			}
			return propertyInfo;
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x00023EC4 File Offset: 0x000220C4
		public static IReadOnlyList<FieldInfo> GetFieldsOptimizado(this Type type, BindingFlags bindingAttr)
		{
			ValueTuple<Type, BindingFlags> valueTuple = new ValueTuple<Type, BindingFlags>(type, bindingAttr);
			FieldInfo[] fields;
			if (!ReflectionsEXT.m_BindedFiledsDeType.TryGetValue(valueTuple, out fields))
			{
				fields = type.GetFields(bindingAttr);
				ReflectionsEXT.m_BindedFiledsDeType.Add(valueTuple, fields);
			}
			return fields;
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x00023F00 File Offset: 0x00022100
		public static IReadOnlyList<PropertyInfo> GettPropertiesOptimizado(this Type type, BindingFlags bindingAttr)
		{
			ValueTuple<Type, BindingFlags> valueTuple = new ValueTuple<Type, BindingFlags>(type, bindingAttr);
			PropertyInfo[] properties;
			if (!ReflectionsEXT.m_BindedPropertiesDeType.TryGetValue(valueTuple, out properties))
			{
				properties = type.GetProperties(bindingAttr);
				ReflectionsEXT.m_BindedPropertiesDeType.Add(valueTuple, properties);
			}
			return properties;
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x00023F3C File Offset: 0x0002213C
		public static FieldInfo GetFieldOptimizado(this Type type, BindingFlags bindingAttr, string name)
		{
			ValueTuple<Type, BindingFlags, string> valueTuple = new ValueTuple<Type, BindingFlags, string>(type, bindingAttr, name);
			FieldInfo fieldFlattenHierarchy;
			if (!ReflectionsEXT.m_FieldDeTypes.TryGetValue(valueTuple, out fieldFlattenHierarchy))
			{
				fieldFlattenHierarchy = type.GetFieldFlattenHierarchy(name, bindingAttr);
				if (fieldFlattenHierarchy != null)
				{
					ReflectionsEXT.m_FieldDeTypes.Add(valueTuple, fieldFlattenHierarchy);
				}
			}
			return fieldFlattenHierarchy;
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x00023F84 File Offset: 0x00022184
		public static PropertyInfo GetPropertyOptimizado(this Type type, BindingFlags bindingAttr, string name)
		{
			ValueTuple<Type, BindingFlags, string> valueTuple = new ValueTuple<Type, BindingFlags, string>(type, bindingAttr, name);
			PropertyInfo propertyFlattenHierarchy;
			if (!ReflectionsEXT.m_PropertyDeTypes.TryGetValue(valueTuple, out propertyFlattenHierarchy))
			{
				propertyFlattenHierarchy = type.GetPropertyFlattenHierarchy(name, bindingAttr);
				if (propertyFlattenHierarchy != null)
				{
					ReflectionsEXT.m_PropertyDeTypes.Add(valueTuple, propertyFlattenHierarchy);
				}
			}
			return propertyFlattenHierarchy;
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x00023FCC File Offset: 0x000221CC
		public static MemberInfo GetMemberOptimizado(this Type type, BindingFlags bindingAttr, string name)
		{
			ValueTuple<Type, BindingFlags, string> valueTuple = new ValueTuple<Type, BindingFlags, string>(type, bindingAttr, name);
			MemberInfo memberInfo;
			if (!ReflectionsEXT.m_MemberDeTypes.TryGetValue(valueTuple, out memberInfo))
			{
				FieldInfo fieldFlattenHierarchy = type.GetFieldFlattenHierarchy(name, bindingAttr);
				PropertyInfo propertyFlattenHierarchy = type.GetPropertyFlattenHierarchy(name, bindingAttr);
				if (fieldFlattenHierarchy != null)
				{
					memberInfo = fieldFlattenHierarchy;
					ReflectionsEXT.m_MemberDeTypes.Add(valueTuple, memberInfo);
				}
				if (propertyFlattenHierarchy != null)
				{
					memberInfo = propertyFlattenHierarchy;
					ReflectionsEXT.m_MemberDeTypes.Add(valueTuple, memberInfo);
				}
			}
			return memberInfo;
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x00024033 File Offset: 0x00022233
		public static FieldInfo GetFieldNestedOptimizado(this Type type, BindingFlags bindingAttr, string ruta, char separador)
		{
			return type.GetFieldNestedOptimizado(bindingAttr, ruta.Split(separador, StringSplitOptions.None));
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x00024044 File Offset: 0x00022244
		public static FieldInfo GetFieldNestedOptimizado(this Type type, BindingFlags bindingAttr, IReadOnlyList<string> ruta)
		{
			if (ruta.Count == 0)
			{
				throw new InvalidOperationException();
			}
			FieldInfo fieldInfo = null;
			for (int i = 0; i < ruta.Count; i++)
			{
				string text = ruta[i];
				fieldInfo = type.GetFieldOptimizado(bindingAttr, text);
				if (!(fieldInfo != null))
				{
					break;
				}
				type = fieldInfo.FieldType;
			}
			return fieldInfo;
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x00024095 File Offset: 0x00022295
		public static T GetMemberNestedOptimizado<T>(this Type type, BindingFlags bindingAttr, string ruta, char separador) where T : MemberInfo
		{
			return type.GetMemberNestedOptimizado(bindingAttr, ruta.Split(separador, StringSplitOptions.None), null);
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x000240A8 File Offset: 0x000222A8
		public static T GetMemberNestedOptimizado<T>(this Type type, BindingFlags bindingAttr, IReadOnlyList<string> ruta, List<MemberInfo> acendencia = null) where T : MemberInfo
		{
			if (ruta.Count == 0)
			{
				throw new InvalidOperationException();
			}
			MemberInfo memberInfo = null;
			for (int i = 0; i < ruta.Count; i++)
			{
				string text = ruta[i];
				memberInfo = type.GetMemberOptimizado(bindingAttr, text);
				if (!(memberInfo != null))
				{
					break;
				}
				if (acendencia != null)
				{
					acendencia.Add(memberInfo);
				}
				if (memberInfo is FieldInfo)
				{
					type = ((FieldInfo)memberInfo).FieldType;
				}
				else
				{
					if (!(memberInfo is PropertyInfo))
					{
						break;
					}
					type = ((PropertyInfo)memberInfo).PropertyType;
				}
			}
			if (acendencia != null)
			{
				acendencia.Remove(memberInfo);
			}
			return memberInfo as T;
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x0002413C File Offset: 0x0002233C
		public static object GetValueNestedOptimizado(this object instance, BindingFlags bindingAttr, string ruta, char separador)
		{
			return instance.GetValueNestedOptimizado(bindingAttr, ruta.Split(separador, StringSplitOptions.None));
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x00024150 File Offset: 0x00022350
		public static object GetValueNestedOptimizado(this object instance, BindingFlags bindingAttr, IReadOnlyList<string> ruta)
		{
			if (ruta.Count == 0)
			{
				throw new InvalidOperationException();
			}
			Type type = instance.GetType();
			int num = 0;
			while (num < ruta.Count && instance != null)
			{
				string text = ruta[num];
				MemberInfo memberOptimizado = type.GetMemberOptimizado(bindingAttr, text);
				if (!(memberOptimizado != null))
				{
					break;
				}
				if (memberOptimizado is FieldInfo)
				{
					FieldInfo fieldInfo = (FieldInfo)memberOptimizado;
					type = fieldInfo.FieldType;
					instance = fieldInfo.GetValue(instance);
				}
				else
				{
					if (!(memberOptimizado is PropertyInfo))
					{
						break;
					}
					PropertyInfo propertyInfo = (PropertyInfo)memberOptimizado;
					type = propertyInfo.PropertyType;
					instance = propertyInfo.GetValue(instance);
				}
				num++;
			}
			return instance;
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x000241DF File Offset: 0x000223DF
		public static PropertyInfo GetPropertyNestedOptimizado(this Type type, BindingFlags bindingAttr, string ruta, char separador)
		{
			return type.GetPropertyNestedOptimizado(bindingAttr, ruta.Split(separador, StringSplitOptions.None));
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x000241F0 File Offset: 0x000223F0
		public static PropertyInfo GetPropertyNestedOptimizado(this Type type, BindingFlags bindingAttr, IReadOnlyList<string> ruta)
		{
			if (ruta.Count == 0)
			{
				throw new InvalidOperationException();
			}
			PropertyInfo propertyInfo = null;
			for (int i = 0; i < ruta.Count; i++)
			{
				string text = ruta[i];
				propertyInfo = type.GetPropertyOptimizado(bindingAttr, text);
				if (!(propertyInfo != null))
				{
					break;
				}
				type = propertyInfo.PropertyType;
			}
			return propertyInfo;
		}

		// Token: 0x04000351 RID: 849
		private static readonly Type objectType = typeof(object);

		// Token: 0x04000352 RID: 850
		private static readonly Dictionary<ValueTuple<Type, BindingFlags>, FieldInfo[]> m_BindedFiledsDeType = new Dictionary<ValueTuple<Type, BindingFlags>, FieldInfo[]>();

		// Token: 0x04000353 RID: 851
		private static readonly Dictionary<ValueTuple<Type, BindingFlags>, PropertyInfo[]> m_BindedPropertiesDeType = new Dictionary<ValueTuple<Type, BindingFlags>, PropertyInfo[]>();

		// Token: 0x04000354 RID: 852
		private static readonly Dictionary<ValueTuple<Type, BindingFlags, string>, FieldInfo> m_FieldDeTypes = new Dictionary<ValueTuple<Type, BindingFlags, string>, FieldInfo>();

		// Token: 0x04000355 RID: 853
		private static readonly Dictionary<ValueTuple<Type, BindingFlags, string>, PropertyInfo> m_PropertyDeTypes = new Dictionary<ValueTuple<Type, BindingFlags, string>, PropertyInfo>();

		// Token: 0x04000356 RID: 854
		private static readonly Dictionary<ValueTuple<Type, BindingFlags, string>, MemberInfo> m_MemberDeTypes = new Dictionary<ValueTuple<Type, BindingFlags, string>, MemberInfo>();
	}
}

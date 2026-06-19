using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200004F RID: 79
	public static class InterpretacionHelper
	{
		// Token: 0x060003AA RID: 938 RVA: 0x0000E90C File Offset: 0x0000CB0C
		public static void InitProperties<T>(Dictionary<string, ValueTuple<PropertyInfo, InterpretacionHelper.PropGetter<T>>> getters, Dictionary<string, ValueTuple<PropertyInfo, InterpretacionHelper.PropSetter<T>>> setters, string sufijo) where T : struct
		{
			getters.Clear();
			setters.Clear();
			PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
			Dictionary<string, PropertyInfo> dictionary = properties.ToDictionary((PropertyInfo p) => p.Name);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (!(propertyInfo.PropertyType != typeof(int)))
				{
					PropertyInfo propertyInfo2;
					try
					{
						propertyInfo2 = dictionary[propertyInfo.Name.Replace(sufijo, "")];
					}
					catch (Exception)
					{
						throw;
					}
					MethodInfo getMethod = propertyInfo.GetGetMethod(true);
					MethodInfo setMethod = propertyInfo.GetSetMethod(true);
					InterpretacionHelper.PropGetter<T> propGetter;
					try
					{
						propGetter = (InterpretacionHelper.PropGetter<T>)Delegate.CreateDelegate(typeof(InterpretacionHelper.PropGetter<T>), getMethod);
					}
					catch (Exception)
					{
						throw;
					}
					InterpretacionHelper.PropSetter<T> propSetter;
					try
					{
						propSetter = (InterpretacionHelper.PropSetter<T>)Delegate.CreateDelegate(typeof(InterpretacionHelper.PropSetter<T>), setMethod);
					}
					catch (Exception)
					{
						throw;
					}
					getters.Add(propertyInfo2.Name, new ValueTuple<PropertyInfo, InterpretacionHelper.PropGetter<T>>(propertyInfo2, propGetter));
					setters.Add(propertyInfo2.Name, new ValueTuple<PropertyInfo, InterpretacionHelper.PropSetter<T>>(propertyInfo2, propSetter));
				}
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000EA50 File Offset: 0x0000CC50
		public static void InitDisplays<T>(Dictionary<string, Dictionary<string, string>> displaysLocalizados)
		{
			displaysLocalizados.Clear();
			foreach (PropertyInfo propertyInfo in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public))
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				displaysLocalizados.Add(propertyInfo.Name, dictionary);
				InterpretacionHelper.InitLocal<T>(propertyInfo, dictionary);
			}
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0000EAA4 File Offset: 0x0000CCA4
		private static void InitLocal<T>(PropertyInfo field, Dictionary<string, string> dicc)
		{
			IEnumerable<TextoLocalizadoAttribute> enumerable;
			try
			{
				enumerable = field.GetCustomAttributes(false).OfType<TextoLocalizadoAttribute>();
			}
			catch (Exception)
			{
				throw;
			}
			foreach (TextoLocalizadoAttribute textoLocalizadoAttribute in enumerable)
			{
				if (!dicc.ContainsKey(textoLocalizadoAttribute.localizationID))
				{
					dicc.Add(textoLocalizadoAttribute.localizationID, textoLocalizadoAttribute.text);
				}
			}
		}

		// Token: 0x02000098 RID: 152
		// (Invoke) Token: 0x060005FB RID: 1531
		public delegate int PropGetter<T>(ref T instance) where T : struct;

		// Token: 0x02000099 RID: 153
		// (Invoke) Token: 0x060005FF RID: 1535
		public delegate void PropSetter<T>(ref T instance, int value) where T : struct;
	}
}

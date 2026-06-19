using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace TValleCustomClases
{
	// Token: 0x02000060 RID: 96
	public class DynamicInstantiation<TParam1, TParam2> : DynamicInstantiationBase<Instantiator<TParam1, TParam2>>
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x0000DD0A File Offset: 0x0000BF0A
		public static DynamicInstantiation<TParam1, TParam2> instance
		{
			get
			{
				if (DynamicInstantiation<TParam1, TParam2>.m_singleton == null)
				{
					DynamicInstantiation<TParam1, TParam2>.m_singleton = new DynamicInstantiation<TParam1, TParam2>();
				}
				return DynamicInstantiation<TParam1, TParam2>.m_singleton;
			}
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000DD22 File Offset: 0x0000BF22
		protected DynamicInstantiation()
		{
			this.m_Cache = new Dictionary<Type, Instantiator<TParam1, TParam2>>();
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x0000DD35 File Offset: 0x0000BF35
		protected override Dictionary<Type, Instantiator<TParam1, TParam2>> cache
		{
			get
			{
				return this.m_Cache;
			}
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0000DD3D File Offset: 0x0000BF3D
		public static object InstantiateType(Type type, TParam1 param1, TParam2 param2)
		{
			return DynamicInstantiation<TParam1, TParam2>.instance.Instantiate(type, param1, param2);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0000DD4C File Offset: 0x0000BF4C
		protected object Instantiate(Type type, TParam1 param1, TParam2 param2)
		{
			Instantiator<TParam1, TParam2> instantiator;
			if (!this.m_Cache.TryGetValue(type, out instantiator))
			{
				instantiator = this.AddToCache(type);
			}
			return instantiator(param1, param2);
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000DD7C File Offset: 0x0000BF7C
		protected override Instantiator<TParam1, TParam2> GetActivator(ConstructorInfo ctor)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TParam1), "param1");
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(TParam2), "param2");
			NewExpression newExpression = Expression.New(ctor, new Expression[] { parameterExpression, parameterExpression2 });
			return (Instantiator<TParam1, TParam2>)Expression.Lambda(typeof(Instantiator<TParam1, TParam2>), newExpression, new ParameterExpression[] { parameterExpression, parameterExpression2 }).Compile();
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0000DDF0 File Offset: 0x0000BFF0
		protected override bool EvaluateConstructor(ConstructorInfo ctor)
		{
			ParameterInfo[] parameters = ctor.GetParameters();
			if (parameters.Length != 2)
			{
				return false;
			}
			ParameterInfo parameterInfo = parameters[0];
			ParameterInfo parameterInfo2 = parameters[1];
			return parameterInfo.ParameterType.IsAssignableFrom(typeof(TParam1)) && parameterInfo2.ParameterType.IsAssignableFrom(typeof(TParam2));
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0000DE42 File Offset: 0x0000C042
		protected override bool EvaluateType(Type type)
		{
			return true;
		}

		// Token: 0x0400009D RID: 157
		private static DynamicInstantiation<TParam1, TParam2> m_singleton;

		// Token: 0x0400009E RID: 158
		private Dictionary<Type, Instantiator<TParam1, TParam2>> m_Cache;
	}
}

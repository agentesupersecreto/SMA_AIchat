using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace TValleCustomClases
{
	// Token: 0x02000062 RID: 98
	public class DynamicInstantiation<TParam1, TParam2, TParam3> : DynamicInstantiationBase<Instantiator<TParam1, TParam2, TParam3>>
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060002FF RID: 767 RVA: 0x0000DE9F File Offset: 0x0000C09F
		public static DynamicInstantiation<TParam1, TParam2, TParam3> instance
		{
			get
			{
				if (DynamicInstantiation<TParam1, TParam2, TParam3>.m_singleton == null)
				{
					DynamicInstantiation<TParam1, TParam2, TParam3>.m_singleton = new DynamicInstantiation<TParam1, TParam2, TParam3>();
				}
				return DynamicInstantiation<TParam1, TParam2, TParam3>.m_singleton;
			}
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0000DEB7 File Offset: 0x0000C0B7
		protected DynamicInstantiation()
		{
			this.m_Cache = new Dictionary<Type, Instantiator<TParam1, TParam2, TParam3>>();
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000301 RID: 769 RVA: 0x0000DECA File Offset: 0x0000C0CA
		protected override Dictionary<Type, Instantiator<TParam1, TParam2, TParam3>> cache
		{
			get
			{
				return this.m_Cache;
			}
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000DED2 File Offset: 0x0000C0D2
		public static object InstantiateType(Type type, TParam1 param1, TParam2 param2, TParam3 param3)
		{
			return DynamicInstantiation<TParam1, TParam2, TParam3>.instance.Instantiate(type, param1, param2, param3);
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000DEE4 File Offset: 0x0000C0E4
		protected object Instantiate(Type type, TParam1 param1, TParam2 param2, TParam3 param3)
		{
			Instantiator<TParam1, TParam2, TParam3> instantiator;
			if (!this.m_Cache.TryGetValue(type, out instantiator))
			{
				instantiator = this.AddToCache(type);
			}
			return instantiator(param1, param2, param3);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0000DF14 File Offset: 0x0000C114
		protected override Instantiator<TParam1, TParam2, TParam3> GetActivator(ConstructorInfo ctor)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TParam1), "param1");
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(TParam2), "param2");
			ParameterExpression parameterExpression3 = Expression.Parameter(typeof(TParam3), "param3");
			NewExpression newExpression = Expression.New(ctor, new Expression[] { parameterExpression, parameterExpression2, parameterExpression3 });
			return (Instantiator<TParam1, TParam2, TParam3>)Expression.Lambda(typeof(Instantiator<TParam1, TParam2, TParam3>), newExpression, new ParameterExpression[] { parameterExpression, parameterExpression2, parameterExpression3 }).Compile();
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0000DFA8 File Offset: 0x0000C1A8
		protected override bool EvaluateConstructor(ConstructorInfo ctor)
		{
			ParameterInfo[] parameters = ctor.GetParameters();
			if (parameters.Length != 3)
			{
				return false;
			}
			ParameterInfo parameterInfo = parameters[0];
			ParameterInfo parameterInfo2 = parameters[1];
			ParameterInfo parameterInfo3 = parameters[2];
			return parameterInfo.ParameterType.IsAssignableFrom(typeof(TParam1)) && parameterInfo2.ParameterType.IsAssignableFrom(typeof(TParam2)) && parameterInfo3.ParameterType.IsAssignableFrom(typeof(TParam3));
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0000E015 File Offset: 0x0000C215
		protected override bool EvaluateType(Type type)
		{
			return true;
		}

		// Token: 0x040000A0 RID: 160
		private static DynamicInstantiation<TParam1, TParam2, TParam3> m_singleton;

		// Token: 0x040000A1 RID: 161
		private Dictionary<Type, Instantiator<TParam1, TParam2, TParam3>> m_Cache;
	}
}

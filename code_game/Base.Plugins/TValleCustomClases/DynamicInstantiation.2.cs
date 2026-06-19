using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace TValleCustomClases
{
	// Token: 0x0200005E RID: 94
	public class DynamicInstantiation<TParam> : DynamicInstantiationBase<Instantiator<TParam>>
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x0000DBB4 File Offset: 0x0000BDB4
		public static DynamicInstantiation<TParam> instance
		{
			get
			{
				if (DynamicInstantiation<TParam>.m_singleton == null)
				{
					DynamicInstantiation<TParam>.m_singleton = new DynamicInstantiation<TParam>();
				}
				return DynamicInstantiation<TParam>.m_singleton;
			}
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000DBCC File Offset: 0x0000BDCC
		protected DynamicInstantiation()
		{
			this.m_Cache = new Dictionary<Type, Instantiator<TParam>>();
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x0000DBDF File Offset: 0x0000BDDF
		protected override Dictionary<Type, Instantiator<TParam>> cache
		{
			get
			{
				return this.m_Cache;
			}
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0000DBE7 File Offset: 0x0000BDE7
		public static object InstantiateType(Type type, TParam param)
		{
			return DynamicInstantiation<TParam>.instance.Instantiate(type, param);
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000DBF8 File Offset: 0x0000BDF8
		protected object Instantiate(Type type, TParam param)
		{
			Instantiator<TParam> instantiator;
			if (!this.m_Cache.TryGetValue(type, out instantiator))
			{
				instantiator = this.AddToCache(type);
			}
			return instantiator(param);
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000DC24 File Offset: 0x0000BE24
		protected override Instantiator<TParam> GetActivator(ConstructorInfo ctor)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TParam), "param");
			NewExpression newExpression = Expression.New(ctor, new Expression[] { parameterExpression });
			return (Instantiator<TParam>)Expression.Lambda(typeof(Instantiator<TParam>), newExpression, new ParameterExpression[] { parameterExpression }).Compile();
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000DC7C File Offset: 0x0000BE7C
		protected override bool EvaluateConstructor(ConstructorInfo ctor)
		{
			ParameterInfo[] parameters = ctor.GetParameters();
			return parameters.Length == 1 && parameters[0].ParameterType.IsAssignableFrom(typeof(TParam));
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000DCAF File Offset: 0x0000BEAF
		protected override bool EvaluateType(Type type)
		{
			return true;
		}

		// Token: 0x0400009A RID: 154
		private static DynamicInstantiation<TParam> m_singleton;

		// Token: 0x0400009B RID: 155
		private Dictionary<Type, Instantiator<TParam>> m_Cache;
	}
}

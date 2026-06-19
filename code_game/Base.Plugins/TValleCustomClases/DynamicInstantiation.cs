using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace TValleCustomClases
{
	// Token: 0x0200005C RID: 92
	public class DynamicInstantiation : DynamicInstantiationBase<Instantiator>
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x0000DAAE File Offset: 0x0000BCAE
		public static DynamicInstantiation instance
		{
			get
			{
				if (DynamicInstantiation.m_singleton == null)
				{
					DynamicInstantiation.m_singleton = new DynamicInstantiation();
				}
				return DynamicInstantiation.m_singleton;
			}
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000DAC6 File Offset: 0x0000BCC6
		protected DynamicInstantiation()
		{
			this.m_Cache = new Dictionary<Type, Instantiator>();
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000DAD9 File Offset: 0x0000BCD9
		public static object InstantiateType(Type type)
		{
			return DynamicInstantiation.instance.Instantiate(type);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000DAE8 File Offset: 0x0000BCE8
		protected object Instantiate(Type type)
		{
			Instantiator instantiator;
			if (!this.m_Cache.TryGetValue(type, out instantiator))
			{
				instantiator = this.AddToCache(type);
			}
			return instantiator();
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060002DC RID: 732 RVA: 0x0000DB13 File Offset: 0x0000BD13
		protected override Dictionary<Type, Instantiator> cache
		{
			get
			{
				return this.m_Cache;
			}
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000DB1C File Offset: 0x0000BD1C
		protected override Instantiator GetActivator(ConstructorInfo ctor)
		{
			NewExpression newExpression = Expression.New(ctor);
			return (Instantiator)Expression.Lambda(typeof(Instantiator), newExpression, Array.Empty<ParameterExpression>()).Compile();
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000DB4F File Offset: 0x0000BD4F
		protected override bool EvaluateConstructor(ConstructorInfo ctor)
		{
			return ctor.GetParameters().Length == 0;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000DB5B File Offset: 0x0000BD5B
		protected override bool EvaluateType(Type type)
		{
			return true;
		}

		// Token: 0x04000097 RID: 151
		private static DynamicInstantiation m_singleton;

		// Token: 0x04000098 RID: 152
		private Dictionary<Type, Instantiator> m_Cache;
	}
}

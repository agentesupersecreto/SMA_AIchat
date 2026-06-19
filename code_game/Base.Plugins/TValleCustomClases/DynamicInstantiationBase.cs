using System;
using System.Collections.Generic;
using System.Reflection;

namespace TValleCustomClases
{
	// Token: 0x0200005B RID: 91
	public abstract class DynamicInstantiationBase<TDelegate> where TDelegate : class
	{
		// Token: 0x060002D0 RID: 720 RVA: 0x0000D9B8 File Offset: 0x0000BBB8
		static DynamicInstantiationBase()
		{
			if (!typeof(TDelegate).IsSubclassOf(typeof(Delegate)))
			{
				throw new InvalidOperationException(typeof(TDelegate).Name + " is not a delegate type");
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060002D1 RID: 721
		protected abstract Dictionary<Type, TDelegate> cache { get; }

		// Token: 0x060002D2 RID: 722
		protected abstract TDelegate GetActivator(ConstructorInfo ctor);

		// Token: 0x060002D3 RID: 723
		protected abstract bool EvaluateConstructor(ConstructorInfo ctor);

		// Token: 0x060002D4 RID: 724
		protected abstract bool EvaluateType(Type type);

		// Token: 0x060002D5 RID: 725 RVA: 0x0000D9F4 File Offset: 0x0000BBF4
		protected virtual TDelegate AddToCache(Type type)
		{
			if (!this.EvaluateType(type))
			{
				throw new InvalidOperationException("Type " + type.Name + " is not a valid Type for DynamicInstantiation: " + base.GetType().Name);
			}
			ConstructorInfo constructor = this.GetConstructor(type);
			TDelegate activator = this.GetActivator(constructor);
			this.cache.Add(type, activator);
			return activator;
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000DA50 File Offset: 0x0000BC50
		protected virtual ConstructorInfo GetConstructor(Type type)
		{
			foreach (ConstructorInfo constructorInfo in type.GetConstructors())
			{
				if (this.EvaluateConstructor(constructorInfo))
				{
					return constructorInfo;
				}
			}
			throw new InvalidOperationException(" No valid constructor found in " + type.Name + ". DynamicInstantiation: " + base.GetType().Name);
		}
	}
}

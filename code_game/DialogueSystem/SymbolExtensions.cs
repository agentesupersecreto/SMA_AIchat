using System;
using System.Linq.Expressions;
using System.Reflection;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200025D RID: 605
	public static class SymbolExtensions
	{
		// Token: 0x06001A24 RID: 6692 RVA: 0x0002C4B8 File Offset: 0x0002A6B8
		public static MethodInfo GetMethodInfo(Expression<Action> expression)
		{
			return SymbolExtensions.GetMethodInfo(expression);
		}

		// Token: 0x06001A25 RID: 6693 RVA: 0x0002C4C0 File Offset: 0x0002A6C0
		public static MethodInfo GetMethodInfo<T>(Expression<Action<T>> expression)
		{
			return SymbolExtensions.GetMethodInfo(expression);
		}

		// Token: 0x06001A26 RID: 6694 RVA: 0x0002C4C8 File Offset: 0x0002A6C8
		public static MethodInfo GetMethodInfo<T, TResult>(Expression<Func<T, TResult>> expression)
		{
			return SymbolExtensions.GetMethodInfo(expression);
		}

		// Token: 0x06001A27 RID: 6695 RVA: 0x0002C4D0 File Offset: 0x0002A6D0
		public static MethodInfo GetMethodInfo(LambdaExpression expression)
		{
			MethodCallExpression methodCallExpression = expression.Body as MethodCallExpression;
			if (methodCallExpression == null)
			{
				throw new ArgumentException("Invalid Expression. Expression should consist of a Method call only.");
			}
			return methodCallExpression.Method;
		}
	}
}

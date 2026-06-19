using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000057 RID: 87
	public class SecondaryModelAttribute : Attribute
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x00007468 File Offset: 0x00005668
		// (set) Token: 0x060002E2 RID: 738 RVA: 0x00007470 File Offset: 0x00005670
		public Type type { get; set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x00007479 File Offset: 0x00005679
		// (set) Token: 0x060002E4 RID: 740 RVA: 0x00007481 File Offset: 0x00005681
		public string member { get; set; }

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x0000748A File Offset: 0x0000568A
		// (set) Token: 0x060002E6 RID: 742 RVA: 0x00007492 File Offset: 0x00005692
		public int index { get; set; } = -1;

		// Token: 0x060002E7 RID: 743 RVA: 0x0000749C File Offset: 0x0000569C
		public static Func<object> GetGetter(SecondaryModelAttribute att, object model)
		{
			if (att == null)
			{
				return null;
			}
			Func<object> func = null;
			if (!string.IsNullOrWhiteSpace(att.member) && att.type != null)
			{
				MemberInfo memberInfo = att.type.GetMember(att.member, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy).FirstOrDefault<MemberInfo>();
				if (memberInfo != null)
				{
					if (memberInfo is PropertyInfo)
					{
						PropertyInfo propertyInfo = memberInfo as PropertyInfo;
						func = (Func<object>)Delegate.CreateDelegate(typeof(Func<object>), model, propertyInfo.GetMethod);
					}
					else if (memberInfo is MethodInfo)
					{
						MethodInfo methodInfo = memberInfo as MethodInfo;
						func = (Func<object>)Delegate.CreateDelegate(typeof(Func<object>), model, methodInfo);
					}
					else
					{
						func = null;
					}
				}
			}
			return func;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00007548 File Offset: 0x00005748
		public static SecondaryModelAttribute.SecondaryModelEstructura GetSecondaryModelEstructura(object model, object secondaryModel = null)
		{
			return SecondaryModelAttribute.GetSecondaryModelEstructura(DibujadorDynamico.instance.GetModelEstructura(model), secondaryModel);
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000755C File Offset: 0x0000575C
		private static SecondaryModelAttribute.SecondaryModelEstructura GetSecondaryModelEstructura(DibujadorDynamico.ModelEstructura modelEstructura, object secondaryModel)
		{
			SecondaryModelAttribute.SecondaryModelEstructura secondaryModelEstructura = new SecondaryModelAttribute.SecondaryModelEstructura();
			secondaryModelEstructura.modelEstructura = modelEstructura;
			secondaryModelEstructura.ownSecondaryModel = modelEstructura.attributes.FirstOrDefault((Attribute a) => a is SecondaryModelAttribute) as SecondaryModelAttribute;
			secondaryModelEstructura.secondaryModelValueGetter = SecondaryModelAttribute.GetGetter(secondaryModelEstructura.ownSecondaryModel, secondaryModel);
			for (int i = 0; i < modelEstructura.children.Count; i++)
			{
				DibujadorDynamico.ModelEstructura modelEstructura2 = modelEstructura.children[i];
				secondaryModelEstructura.children.Add(SecondaryModelAttribute.GetSecondaryModelEstructura(modelEstructura2, secondaryModel));
			}
			return secondaryModelEstructura;
		}

		// Token: 0x0200016F RID: 367
		public class SecondaryModelEstructura
		{
			// Token: 0x0400047D RID: 1149
			public DibujadorDynamico.ModelEstructura modelEstructura;

			// Token: 0x0400047E RID: 1150
			public SecondaryModelAttribute ownSecondaryModel;

			// Token: 0x0400047F RID: 1151
			public Func<object> secondaryModelValueGetter;

			// Token: 0x04000480 RID: 1152
			public List<SecondaryModelAttribute.SecondaryModelEstructura> children = new List<SecondaryModelAttribute.SecondaryModelEstructura>();
		}
	}
}

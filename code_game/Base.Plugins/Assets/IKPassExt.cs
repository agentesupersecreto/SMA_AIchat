using System;

namespace Assets
{
	// Token: 0x020000E6 RID: 230
	public static class IKPassExt
	{
		// Token: 0x06000629 RID: 1577 RVA: 0x00017859 File Offset: 0x00015A59
		public static IKOrderFlag IndexToIKOrder(this int index)
		{
			switch (index)
			{
			case 0:
				return IKOrderFlag.primero;
			case 1:
				return IKOrderFlag.segundo;
			case 2:
				return IKOrderFlag.tercero;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x00017881 File Offset: 0x00015A81
		public static IKLayerFlag LayerToIKLayer(this int layer)
		{
			switch (layer)
			{
			case 0:
				return IKLayerFlag.primero;
			case 1:
				return IKLayerFlag.segundo;
			case 2:
				return IKLayerFlag.tercero;
			case 3:
				return IKLayerFlag.cuarto;
			default:
				throw new ArgumentOutOfRangeException(layer.ToString());
			}
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x000178B0 File Offset: 0x00015AB0
		private static int IKLayerToLayerFlag(this IKLayerFlag layer)
		{
			switch (layer)
			{
			case IKLayerFlag.None:
				break;
			case IKLayerFlag.primero:
				return 0;
			case IKLayerFlag.segundo:
				return 1;
			case IKLayerFlag.primero | IKLayerFlag.segundo:
			case IKLayerFlag.primero | IKLayerFlag.tercero:
			case IKLayerFlag.segundo | IKLayerFlag.tercero:
			case IKLayerFlag.primero | IKLayerFlag.segundo | IKLayerFlag.tercero:
				goto IL_0042;
			case IKLayerFlag.tercero:
				return 2;
			case IKLayerFlag.cuarto:
				return 3;
			default:
				if (layer != IKLayerFlag.todos)
				{
					if (layer != IKLayerFlag.ultimo)
					{
						goto IL_0042;
					}
					return 3;
				}
				break;
			}
			return -1;
			IL_0042:
			throw new ArgumentOutOfRangeException(layer.ToString());
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x00017914 File Offset: 0x00015B14
		public static IKLayerFlag IKLayerFromTo(this int start, int end)
		{
			int num = end + 1 - start;
			IKLayerFlag iklayerFlag = IKLayerFlag.None;
			for (int i = 0; i < num; i++)
			{
				int num2 = start + i;
				iklayerFlag |= num2.LayerToIKLayer();
			}
			return iklayerFlag;
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x00017943 File Offset: 0x00015B43
		public static IKLayerFlag IKLayerFromToLast(this int start)
		{
			return start.IKLayerFromTo(IKLayerFlag.cuarto.IKLayerToLayerFlag());
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x00017951 File Offset: 0x00015B51
		[Obsolete("", true)]
		private static IKPassFlag IndexToIKPass(int index)
		{
			switch (index)
			{
			case 0:
				return IKPassFlag.primero;
			case 1:
				return IKPassFlag.segundo;
			case 2:
				return IKPassFlag.tercero;
			case 3:
				return IKPassFlag.cuarto;
			case 4:
				return IKPassFlag.quinto;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x00017986 File Offset: 0x00015B86
		private static IKPassOrderFlag IndexToIKPassOrder(int index)
		{
			switch (index)
			{
			case 0:
				return IKPassOrderFlag.primero;
			case 1:
				return IKPassOrderFlag.segundo;
			case 2:
				return IKPassOrderFlag.tercero;
			case 3:
				return IKPassOrderFlag.cuarto;
			case 4:
				return IKPassOrderFlag.quinto;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x000179BC File Offset: 0x00015BBC
		public static bool EsParaCurrentIkLayer(this IKLayerFlag paraFlags, int layer)
		{
			int num = (int)layer.LayerToIKLayer();
			return ((int)paraFlags).HasFlag(num);
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x000179D8 File Offset: 0x00015BD8
		public static bool EsParaCurrentIkLayer(this IKLayerFlag paraFlags, IKOrderFlag paraFlags2, ref IKEventData data)
		{
			int num = (int)data.layer.LayerToIKLayer();
			int num2 = (int)data.indexEnLayer.IndexToIKOrder();
			return (((int)paraFlags).HasFlag(num) || (data.esUltimoLayer && ((int)paraFlags).HasFlag(16))) && (((int)paraFlags2).HasFlag(num2) || (data.esUltimoDeLayer && ((int)paraFlags2).HasFlag(8)));
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00017A3C File Offset: 0x00015C3C
		[Obsolete("", true)]
		public static bool EsParaCurrentPass(this IKPassFlag paraFlags, ref IKPassEventData data)
		{
			int num = (int)IKPassExt.IndexToIKPass(data.index);
			return ((int)paraFlags).HasFlag(num) || (data.esUltimo && ((int)paraFlags).HasFlag(32));
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x00017A74 File Offset: 0x00015C74
		public static bool EsParaCurrentPassOrder(this IKPassOrderFlag paraFlags, ref IKPassEventData data)
		{
			int num = (int)IKPassExt.IndexToIKPassOrder(data.index);
			return ((int)paraFlags).HasFlag(num) || (data.esUltimo && ((int)paraFlags).HasFlag(32));
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00017AAC File Offset: 0x00015CAC
		[Obsolete("", true)]
		public static bool EsParaCurrentPass(this IKPass para, ref IKPassEventData data)
		{
			return para == (IKPass)data.index || (data.esUltimo && para == IKPass.ultimo);
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00017AC7 File Offset: 0x00015CC7
		public static bool EsParaCurrentPassOrder(this IKPassOrder para, ref IKPassEventData data)
		{
			return para == (IKPassOrder)data.index || (data.esUltimo && para == IKPassOrder.ultimo);
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x00017AE2 File Offset: 0x00015CE2
		[Obsolete("", true)]
		public static bool EsParaCurrentPass(this IKPass para, ref IKEventData data)
		{
			if (IKPass.ultimo == para)
			{
				return data.esUltimoLayer && data.esUltimoDeLayer;
			}
			return para == (IKPass)data.layer && data.esUltimoDeLayer;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x00017B0A File Offset: 0x00015D0A
		public static bool EsParaCurrentPass(this IKLayer layer, IKOrder order, ref IKEventData data)
		{
			return (layer == (IKLayer)data.layer || (data.esUltimoLayer && layer == IKLayer.ultimo)) && (order == (IKOrder)data.indexEnLayer || (data.esUltimoDeLayer && order == IKOrder.ultimo));
		}
	}
}

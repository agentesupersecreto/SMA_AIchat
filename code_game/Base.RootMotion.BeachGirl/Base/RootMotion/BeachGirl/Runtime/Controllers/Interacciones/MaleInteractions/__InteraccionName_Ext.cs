using System;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones.MaleInteractions
{
	// Token: 0x02000043 RID: 67
	public static class __InteraccionName_Ext
	{
		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060002EB RID: 747 RVA: 0x0000F5E4 File Offset: 0x0000D7E4
		public static int maxPriID
		{
			get
			{
				if (__InteraccionName_Ext.m_maxPriID == null)
				{
					__InteraccionName_Ext.m_maxPriID = new int?(typeof(InteraccionesBasicasDeMale.InteraccionPrimariaName).MaxEnumValue());
				}
				return __InteraccionName_Ext.m_maxPriID.Value;
			}
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000F615 File Offset: 0x0000D815
		public static int GetInteractionID(this InteraccionesBasicasDeMale.InteraccionSegundariaName segundaria)
		{
			return (int)(__InteraccionName_Ext.maxPriID + 1 + segundaria);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000F620 File Offset: 0x0000D820
		public static int GetInteractionID(this InteraccionesBasicasDeMale.InteraccionPrimariaName pri)
		{
			return (int)pri;
		}

		// Token: 0x040001F9 RID: 505
		private static int? m_maxPriID;
	}
}

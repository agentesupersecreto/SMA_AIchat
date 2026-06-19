using System;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x02000020 RID: 32
	public interface IFemaleCharInfo : IFemaleCharInfoPromediable
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000089 RID: 137
		string nombre { get; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600008A RID: 138
		string apellido { get; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600008B RID: 139
		string cup { get; }

		// Token: 0x0600008C RID: 140
		void ActualizarInfo();
	}
}

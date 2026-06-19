using System;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Globales;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000CC RID: 204
	[Serializable]
	public abstract class ByInteraccionEnScenaArg<T, T_SceneBuffStruck> : DisplayableArgumentoDeEfecto<T>, IByInteraccionEnScenaArg, IDisplayableArgumentoDeEfecto where T : ByInteraccionEnScenaArg<T, T_SceneBuffStruck> where T_SceneBuffStruck : struct, IIdentifiableBuff, IValidableBuff, IPrintableBuff, IStackableBuff<T_SceneBuffStruck>, IFloatValuableBuff, IContextValidableBuff
	{
		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x00017C9A File Offset: 0x00015E9A
		public override DisplayableBuffCategory displayableBuffType
		{
			get
			{
				return this.buffOn.category;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x00017CAD File Offset: 0x00015EAD
		public bool byInteraccionEnScenaBuffIsValid
		{
			get
			{
				return this.buffOn.isValid;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x00017CC0 File Offset: 0x00015EC0
		public IIdentifiableBuff buffOnCopy
		{
			get
			{
				return this.buffOn;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00017CCD File Offset: 0x00015ECD
		public bool buffIsOutOfContext
		{
			get
			{
				return !this.buffOn.isContextValid;
			}
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00017CE3 File Offset: 0x00015EE3
		public bool TrySetyInteraccionEnScenaBuffValue(IIdentifiableBuff interaccionEnScenaBuff)
		{
			if (!(interaccionEnScenaBuff is T_SceneBuffStruck))
			{
				return false;
			}
			this.buffOn = (T_SceneBuffStruck)((object)interaccionEnScenaBuff);
			return this.byInteraccionEnScenaBuffIsValid;
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00017D04 File Offset: 0x00015F04
		protected sealed override string GenerateNonLocalizedText(DisplayableBuff buff)
		{
			return this.buffOn.RichPrint(delegate(string id)
			{
				string text;
				string text2;
				string text3;
				MemoriaDeNpc.TryGetNombres(GlobalSingletonV2<MemoriaJson>.instance, id, out text, out text2, out text3);
				if (!string.IsNullOrWhiteSpace(text3))
				{
					return text3;
				}
				return "Forgotten";
			}, this.actualValue ?? this.buffOn.buffValue, ModdingParser.GetLanguage());
		}

		// Token: 0x04000394 RID: 916
		public T_SceneBuffStruck buffOn;

		// Token: 0x04000395 RID: 917
		public float? actualValue;
	}
}

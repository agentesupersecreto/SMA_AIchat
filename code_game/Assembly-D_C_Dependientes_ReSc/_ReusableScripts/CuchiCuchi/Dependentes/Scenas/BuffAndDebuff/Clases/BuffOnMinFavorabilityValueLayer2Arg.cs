using System;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Globales;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000C5 RID: 197
	public class BuffOnMinFavorabilityValueLayer2Arg : DisplayableArgumentoDeEfecto<BuffOnMinFavorabilityValueLayer2Arg>
	{
		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x000066D6 File Offset: 0x000048D6
		public override DisplayableBuffCategory displayableBuffType
		{
			get
			{
				return DisplayableBuffCategory.favorability;
			}
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00016D18 File Offset: 0x00014F18
		protected override string GenerateNonLocalizedText(DisplayableBuff buff)
		{
			string text;
			string text2;
			string text3;
			MemoriaDeNpc.TryGetNombres(GlobalSingletonV2<MemoriaJson>.instance, this.towardID, out text, out text2, out text3);
			return "toward " + (string.IsNullOrWhiteSpace(text3) ? "Forgotten" : text3) + "\nmin. +" + this.value.ToString("0.0");
		}

		// Token: 0x04000385 RID: 901
		public float value;

		// Token: 0x04000386 RID: 902
		public string towardID;
	}
}

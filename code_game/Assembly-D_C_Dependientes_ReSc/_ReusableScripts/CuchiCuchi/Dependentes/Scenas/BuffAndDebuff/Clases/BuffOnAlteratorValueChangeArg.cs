using System;
using System.Reflection;
using Assets.TValle.BeachGirl.MapasDeAlteradores.Runtime;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000AB RID: 171
	public class BuffOnAlteratorValueChangeArg : DisplayableArgumentoDeEfecto<BuffOnAlteratorValueChangeArg>
	{
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000393 RID: 915 RVA: 0x00014284 File Offset: 0x00012484
		public override DisplayableBuffCategory displayableBuffType
		{
			get
			{
				return DisplayableBuffCategory.other;
			}
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00014BE8 File Offset: 0x00012DE8
		protected override string GenerateNonLocalizedText(DisplayableBuff buff)
		{
			MemberInfo memberInfo;
			string text;
			if (DiccionarioDeStrings<DiccionarioDeNombresDeAlteradoresFemeninos>.memberDeNombre.TryGetValue(this.alteradorID, out memberInfo))
			{
				TextoLocalizadoAttribute currentLocalization = DibujadorDynamico.instance.GetCurrentLocalization<LabelLocalizadoAttribute>(memberInfo);
				if (currentLocalization != null && !string.IsNullOrWhiteSpace(currentLocalization.text))
				{
					text = currentLocalization.text;
				}
				else
				{
					text = this.alteradorID;
				}
			}
			else
			{
				text = this.alteradorID;
			}
			string text2 = ((this.index >= 0) ? ("." + ((char)(97 + this.index)).ToString()) : string.Empty);
			return string.Concat(new string[]
			{
				"\"",
				text,
				text2,
				"\" ",
				this.value.ToString("0.00"),
				" Points Added"
			});
		}

		// Token: 0x04000349 RID: 841
		public float value;

		// Token: 0x0400034A RID: 842
		public string alteradorID;

		// Token: 0x0400034B RID: 843
		public int index;
	}
}

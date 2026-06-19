using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.UI;

namespace Assets.TValle.Pro.Entrevista.Runtime.Sobornaje.DialogueSystem
{
	// Token: 0x02000080 RID: 128
	public class RequiereCantidadDePagoPorSexoOral : CustomMonobehaviour
	{
		// Token: 0x0600051A RID: 1306 RVA: 0x0001D1F9 File Offset: 0x0001B3F9
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_memTemp = this.GetComponentEnRoot(false);
			if (this.m_memTemp == null)
			{
				throw new ArgumentNullException("m_memTemp", "m_memTemp null reference.");
			}
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0001D22C File Offset: 0x0001B42C
		public void Requiere(RequiereNumberInputEventArgs args)
		{
			args.requerido = !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_memTemp, null, "OralBribeAsked", false);
		}

		// Token: 0x04000322 RID: 802
		private MemoriaDeCharacterGeneralTemporal m_memTemp;
	}
}

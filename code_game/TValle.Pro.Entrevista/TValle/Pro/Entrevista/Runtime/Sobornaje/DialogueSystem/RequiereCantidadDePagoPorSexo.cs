using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.UI;

namespace Assets.TValle.Pro.Entrevista.Runtime.Sobornaje.DialogueSystem
{
	// Token: 0x0200007E RID: 126
	public class RequiereCantidadDePagoPorSexo : CustomMonobehaviour
	{
		// Token: 0x06000514 RID: 1300 RVA: 0x0001D149 File Offset: 0x0001B349
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_memTemp = this.GetComponentEnRoot(false);
			if (this.m_memTemp == null)
			{
				throw new ArgumentNullException("m_memTemp", "m_memTemp null reference.");
			}
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0001D17C File Offset: 0x0001B37C
		public void Requiere(RequiereNumberInputEventArgs args)
		{
			args.requerido = !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_memTemp, null, "VaginalBribeAsked", false);
		}

		// Token: 0x04000320 RID: 800
		private MemoriaDeCharacterGeneralTemporal m_memTemp;
	}
}

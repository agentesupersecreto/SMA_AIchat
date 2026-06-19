using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.UI;

namespace Assets.TValle.Pro.Entrevista.Runtime.Sobornaje.DialogueSystem
{
	// Token: 0x0200007F RID: 127
	public class RequiereCantidadDePagoPorSexoAnal : CustomMonobehaviour
	{
		// Token: 0x06000517 RID: 1303 RVA: 0x0001D1A1 File Offset: 0x0001B3A1
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_memTemp = this.GetComponentEnRoot(false);
			if (this.m_memTemp == null)
			{
				throw new ArgumentNullException("m_memTemp", "m_memTemp null reference.");
			}
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0001D1D4 File Offset: 0x0001B3D4
		public void Requiere(RequiereNumberInputEventArgs args)
		{
			args.requerido = !MemoriaDeCharacterBase.LeerDeepBoolean(this.m_memTemp, null, "AnalBribeAsked", false);
		}

		// Token: 0x04000321 RID: 801
		private MemoriaDeCharacterGeneralTemporal m_memTemp;
	}
}

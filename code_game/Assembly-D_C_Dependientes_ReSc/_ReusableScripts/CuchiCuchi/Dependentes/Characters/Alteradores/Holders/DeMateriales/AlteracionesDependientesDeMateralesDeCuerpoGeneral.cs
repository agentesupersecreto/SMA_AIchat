using System;
using System.Collections.Generic;
using Assets.Base.BeachGirl.Controladores.Materiales.Runtime;
using Assets.TValle.BeachGirl.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Miscellaneous.Activables;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Alteradores.Holders.DeMateriales
{
	// Token: 0x0200029B RID: 667
	[LabelLocalizado("<i>Materials:</i> Body 3", "US")]
	public class AlteracionesDependientesDeMateralesDeCuerpoGeneral : HolderDeAlteradores<AlteradorToggle>
	{
		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06001159 RID: 4441 RVA: 0x0002956C File Offset: 0x0002776C
		protected override GlobalUpdater.UpdateType updateType
		{
			get
			{
				return GlobalUpdater.UpdateType.lateUpdate1;
			}
		}

		// Token: 0x0600115A RID: 4442 RVA: 0x00051BA0 File Offset: 0x0004FDA0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_pubesController = this.GetComponentEnCharacter(false);
		}

		// Token: 0x0600115B RID: 4443 RVA: 0x00051BB8 File Offset: 0x0004FDB8
		protected override void InstanciarAlteradores(List<AlteradorToggle> resultado)
		{
			if (this.m_pubesController != null)
			{
				this.m_pubes = this.m_pubesController.pubesRenderer.GetComponent<Skin>();
				if (this.m_pubes == null)
				{
					throw new ArgumentNullException("m_pubes", "m_pubes null reference.");
				}
				EnabableDe component = this.m_pubes.GetComponent<EnabableDe>();
				if (component == null)
				{
					throw new ArgumentNullException("enabableDe", "enabableDe null reference.");
				}
				this.m_pubesVisible = component.ObtenerActivableModNotNull(this);
				AlteradorToggle alteradorToggle = new AlteradorToggle(DiccionarioDeNombresDeAlteradoresFemeninos.Toggleador_Pubes, this, delegate(bool v)
				{
					this.m_pubesVisible.valor.valor = v;
				}, () => true, 25f);
				resultado.Add(alteradorToggle);
			}
		}

		// Token: 0x04000CBB RID: 3259
		private ControlladorDeFemalePubesApariencia m_pubesController;

		// Token: 0x04000CBC RID: 3260
		private Skin m_pubes;

		// Token: 0x04000CBD RID: 3261
		private ModificadorDeBool m_pubesVisible;
	}
}

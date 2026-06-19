using System;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes
{
	// Token: 0x020003FA RID: 1018
	public abstract class AgarranteObjeto : ObjetoEstimulanteDeCharacter
	{
		// Token: 0x17000576 RID: 1398
		// (get) Token: 0x0600163A RID: 5690 RVA: 0x0005CBB7 File Offset: 0x0005ADB7
		public IAgarranteCharacter owner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x0600163B RID: 5691 RVA: 0x0005CBBF File Offset: 0x0005ADBF
		public void Init(IAgarranteCharacter Owner)
		{
			this.m_owner = Owner;
		}

		// Token: 0x17000577 RID: 1399
		// (get) Token: 0x0600163C RID: 5692
		public abstract bool agarrando { get; }

		// Token: 0x17000578 RID: 1400
		// (get) Token: 0x0600163D RID: 5693
		public abstract bool agarrandoPhysicsAndAgarrandoUserControl { get; }

		// Token: 0x17000579 RID: 1401
		// (get) Token: 0x0600163E RID: 5694
		public abstract Vector3 currentAgarrandoPosicionCentral { get; }

		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x0600163F RID: 5695
		public abstract Vector3 currentAgarrandoPosicionA { get; }

		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x06001640 RID: 5696
		public abstract Vector3 currentAgarrandoPosicionB { get; }

		// Token: 0x1700057C RID: 1404
		// (get) Token: 0x06001641 RID: 5697
		public abstract Vector3 currentAgarrandoPosicionC { get; }

		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x06001642 RID: 5698
		public abstract Vector3 currentAgarrandoPosicionD { get; }

		// Token: 0x1700057E RID: 1406
		// (get) Token: 0x06001643 RID: 5699
		public abstract Vector3 startAgarrandoPosicion { get; }

		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x06001644 RID: 5700
		public abstract ModificableDeBool puedeAgarrandoPhysicsAND { get; }

		// Token: 0x06001645 RID: 5701
		public abstract bool EstaAgarrando(bool incluirObjectoPhysico, bool incluirSosteniendo, float? userInputToForze);

		// Token: 0x17000580 RID: 1408
		// (get) Token: 0x06001646 RID: 5702 RVA: 0x0005CBC8 File Offset: 0x0005ADC8
		public bool sosteniendo
		{
			get
			{
				return this.m_sosteniendoObj != null;
			}
		}

		// Token: 0x06001647 RID: 5703 RVA: 0x0005CBD6 File Offset: 0x0005ADD6
		public void Sostener(Object obj)
		{
			if (this.m_sosteniendoObj != null)
			{
				this.DejarDeSostener();
			}
			if (obj is ISostenibleObjetoEvents)
			{
				((ISostenibleObjetoEvents)obj).OnSostenido(this);
			}
			this.m_sosteniendoObj = obj;
		}

		// Token: 0x06001648 RID: 5704 RVA: 0x0005CC07 File Offset: 0x0005AE07
		public void DejarDeSostener()
		{
			if (this.m_sosteniendoObj is ISostenibleObjetoEvents)
			{
				((ISostenibleObjetoEvents)this.m_sosteniendoObj).OnSoltado(this);
			}
			this.m_sosteniendoObj = null;
		}

		// Token: 0x040011A9 RID: 4521
		private IAgarranteCharacter m_owner;

		// Token: 0x040011AA RID: 4522
		[SerializeField]
		[ReadOnlyUI]
		private Object m_sosteniendoObj;
	}
}

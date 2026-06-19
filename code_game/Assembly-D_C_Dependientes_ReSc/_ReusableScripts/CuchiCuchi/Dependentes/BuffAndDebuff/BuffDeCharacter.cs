using System;
using Assets.Base.Tiempo.Runtime.Eventos;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff
{
	// Token: 0x020002B6 RID: 694
	[MemoriaRelatedBehaviour]
	public sealed class BuffDeCharacter : EventosUnicosLocales<Character, BuffEvento, BuffEnEspera, BuffAconteciendo>
	{
		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x060011D8 RID: 4568 RVA: 0x000544EE File Offset: 0x000526EE
		protected override IJsonMemoryNode memoria
		{
			get
			{
				return this.m_memoria;
			}
		}

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x060011D9 RID: 4569 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override bool checkEndDateOnLoad
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060011DA RID: 4570 RVA: 0x000544F6 File Offset: 0x000526F6
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_memoriaPermanenteTarget == null)
			{
				throw new ArgumentNullException("m_memoriaPermanente", "m_memoriaPermanente null reference.");
			}
			if (!this.m_memoriaPermanenteTarget.permanente)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x060011DB RID: 4571 RVA: 0x0005452F File Offset: 0x0005272F
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_showingLadingPanel = Singleton<LoadingPanel>.instance.hidingModificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x060011DC RID: 4572 RVA: 0x0005454D File Offset: 0x0005274D
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			ModificadorDeBool showingLadingPanel = this.m_showingLadingPanel;
			if (showingLadingPanel == null)
			{
				return;
			}
			showingLadingPanel.TryRemoverDeOwner(true);
		}

		// Token: 0x060011DD RID: 4573 RVA: 0x00054568 File Offset: 0x00052768
		protected override bool WasMemoryLoaded()
		{
			return base.owner.isMemoryLoaded;
		}

		// Token: 0x060011DE RID: 4574 RVA: 0x00054575 File Offset: 0x00052775
		protected override void OnMemoryLoaded()
		{
			this.m_memoria = MemoriaDeCharacterBase.LeerDeep(this.m_memoriaPermanenteTarget, "Buff", true);
		}

		// Token: 0x060011DF RID: 4575 RVA: 0x0005458E File Offset: 0x0005278E
		protected override BuffEvento ProducirInstanciaDesdeMemoria(IJsonMemoryNode eventoMem, string eventoID)
		{
			return Activator.CreateInstance(new SerializableType(eventoMem.FindData("type"))) as BuffEvento;
		}

		// Token: 0x060011E0 RID: 4576 RVA: 0x000545AF File Offset: 0x000527AF
		protected override void ShowLoadingPanel(string msg)
		{
			if (!string.IsNullOrWhiteSpace(msg))
			{
				Singleton<LoadingPanel>.instance.nextUserText = Singleton<LoadingPanel>.instance.defaultText + msg;
			}
			this.m_showingLadingPanel.valor.valor = false;
		}

		// Token: 0x060011E1 RID: 4577 RVA: 0x000545E4 File Offset: 0x000527E4
		protected override void HideLoadingPanel()
		{
			this.m_showingLadingPanel.valor.valor = true;
		}

		// Token: 0x04000D0E RID: 3342
		public const string MemID = "Buff";

		// Token: 0x04000D0F RID: 3343
		private IJsonMemoryNode m_memoria;

		// Token: 0x04000D10 RID: 3344
		[SerializeField]
		private MemoriaDeCharacterBase m_memoriaPermanenteTarget;

		// Token: 0x04000D11 RID: 3345
		[SerializeReference]
		private ModificadorDeBool m_showingLadingPanel;
	}
}

using System;
using System.Collections;
using Assets.Productos.Juegos.Reception.Scripts.Genetica.Eventos;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.XRays;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.XRays
{
	// Token: 0x02000099 RID: 153
	[Obsolete("", true)]
	[RequireComponent(typeof(XRaysParaFemaleCharacter))]
	public class EnableXRaysSiNivelAlcanzado : CustomMonobehaviour
	{
		// Token: 0x0600030A RID: 778 RVA: 0x00010DE1 File Offset: 0x0000EFE1
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_XRaysParaFemaleCharacter = base.GetComponent<XRaysParaFemaleCharacter>();
			this.m_checker = new CoroutineCapsule(this.CheckRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00010E1A File Offset: 0x0000F01A
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_nivelBocaAlzanzado = this.m_XRaysParaFemaleCharacter.canShowBocaAND.ObtenerModificadorNotNull(this);
			this.m_nivelPelvisAlzanzado = this.m_XRaysParaFemaleCharacter.canShowPelvisAND.ObtenerModificadorNotNull(this);
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00010E50 File Offset: 0x0000F050
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			ModificadorDeBool nivelPelvisAlzanzado = this.m_nivelPelvisAlzanzado;
			if (nivelPelvisAlzanzado != null)
			{
				nivelPelvisAlzanzado.TryRemoverDeOwner(true);
			}
			ModificadorDeBool nivelBocaAlzanzado = this.m_nivelBocaAlzanzado;
			if (nivelBocaAlzanzado == null)
			{
				return;
			}
			nivelBocaAlzanzado.TryRemoverDeOwner(true);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00010E7E File Offset: 0x0000F07E
		private IEnumerator CheckRutine()
		{
			yield return new WaitForSeconds(Random.value * 3f);
			WaitForSeconds w = new WaitForSeconds(33f);
			for (;;)
			{
				if (!Singleton<PiscinasDeEventosDeEntrevista>.IsInScene)
				{
					this.m_nivelPelvisAlzanzado.valor.valor = (this.m_nivelBocaAlzanzado.valor.valor = true);
				}
				else
				{
					float num = (float)Singleton<PiscinasDeEventosDeEntrevista>.instance.GetNivelIgnorandoInicial();
					if (num >= this.nivelParaBoca)
					{
						this.m_nivelBocaAlzanzado.valor.valor = true;
					}
					else
					{
						this.m_nivelBocaAlzanzado.valor.valor = false;
					}
					if (num >= this.nivelParaPelvis)
					{
						this.m_nivelPelvisAlzanzado.valor.valor = true;
					}
					else
					{
						this.m_nivelPelvisAlzanzado.valor.valor = false;
					}
				}
				yield return w;
			}
			yield break;
		}

		// Token: 0x04000154 RID: 340
		public float nivelParaBoca = 999f;

		// Token: 0x04000155 RID: 341
		public float nivelParaPelvis = 999f;

		// Token: 0x04000156 RID: 342
		[ReadOnlyUI]
		[SerializeField]
		private ModificadorDeBool m_nivelBocaAlzanzado;

		// Token: 0x04000157 RID: 343
		[ReadOnlyUI]
		[SerializeField]
		private ModificadorDeBool m_nivelPelvisAlzanzado;

		// Token: 0x04000158 RID: 344
		private XRaysParaFemaleCharacter m_XRaysParaFemaleCharacter;

		// Token: 0x04000159 RID: 345
		private CoroutineCapsule m_checker;
	}
}
